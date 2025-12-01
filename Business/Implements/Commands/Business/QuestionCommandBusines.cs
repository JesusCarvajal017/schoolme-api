using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Commands;
using Entity.Context.Main;
using Entity.Dtos.Business.Question;
using Entity.Enum;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;
using Utilities.Helpers.Validations;

namespace Business.Implements.Commands.Business
{
    public class QuestionCommandBusines : BaseCommandsBusiness<Question, QuestionDto>, ICommandQuestionServices
    {
        protected readonly ICommandQuestion _data;


        public QuestionCommandBusines(
            ICommandQuestion data,
            IMapper mapper,
            ILogger<QuestionCommandBusines> _logger,
            IGenericHerlpers helpers,
            AplicationDbContext context
            ) : base(data, mapper, _logger, helpers, context)
        {
            _data = data;
        }

        protected async Task EnsureValid(QuestionDto dto)
        {
            var validationResult = await _helpers.Validate(dto);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ToString()));
                // Puedes asociar property cuando sea 1 a 1; si son varios, deja el mensaje agregado
                throw new ValidationException("dto", errors);
            }
        }

        public override async Task<QuestionDto> CreateServices(QuestionDto dto)
        {
            try
            {
                // 1. Validación general (FluentValidation / helpers)
                await EnsureValid(dto);

                // 2. Validaciones de dominio específicas de Question
                if (!dto.TypeAnswerId.HasValue)
                    throw new ValidationException(nameof(dto.TypeAnswerId), "El tipo de respuesta es obligatorio.");

                if (string.IsNullOrWhiteSpace(dto.Text))
                    throw new ValidationException(nameof(dto.Text), "El texto de la pregunta es obligatorio.");

                var typeId = dto.TypeAnswerId.Value;

                // Verificar que el tipo exista y esté activo
                var typeExists = await _context.TypeAnsware
                    .AnyAsync(t => t.Id == typeId && t.Status == 1);

                if (!typeExists)
                    throw new ValidationException(nameof(dto.TypeAnswerId), "El tipo de respuesta no existe o está inactivo.");

                // ¿Este tipo requiere opciones?
                bool requiresOptions =
                    typeId == (int)TypeAnswareEnum.OptionSingle ||
                    typeId == (int)TypeAnswareEnum.OptionMulti;

                if (requiresOptions)
                {
                    if (dto.Options == null || !dto.Options.Any())
                        throw new ValidationException(nameof(dto.Options), "Las preguntas de opción deben tener al menos una opción.");

                    if (dto.Options.Any(o => string.IsNullOrWhiteSpace(o.Text)))
                        throw new ValidationException(nameof(dto.Options), "Todas las opciones deben tener texto.");
                }

                // 3. Mapear DTO → entidad
                var entity = _mapper.Map<Question>(dto);
                entity.Status = dto.Status == 0 ? 1 : dto.Status;

                Question saved;

                // 4. Decidir si va con opciones o no
                if (requiresOptions && dto.Options != null)
                {
                    var optionEntities = _mapper.Map<List<QuestionOption>>(dto.Options);
                    saved = await _data.InsertWithOptionsAsync(entity, optionEntities);
                }
                else
                {
                    saved = await _data.InsertAsync(entity);
                }

                _logger.LogInformation($"Creando nuevo {typeof(Question).Name}");

                // 5. Mapear de vuelta a DTO
                return _mapper.Map<QuestionDto>(saved);
            }
            catch (ValidationException)
            {
                // Deja pasar las ValidationException tal cual para que el controller las maneje
                throw;
            }
            catch (Exception ex)
            {
                // Aquí puedes loguear cualquier otra excepción
                _logger.LogError(ex, $"Error al crear {typeof(Question).Name} desde DTO");
                throw;
            }
        }

        public override async Task<bool> UpdateServices(QuestionDto dto)
        {
            try
            {
                // ================= VALIDACIONES BÁSICAS =================
                await EnsureValid(dto);

                if (!dto.Id.HasValue)
                    throw new ValidationException("El Id de la pregunta es obligatorio.");

                if (!dto.TypeAnswerId.HasValue)
                    throw new ValidationException("El tipo de respuesta es obligatorio.");

                if (string.IsNullOrWhiteSpace(dto.Text))
                    throw new ValidationException("El texto de la pregunta es obligatorio.");

                var typeId = dto.TypeAnswerId.Value;

                var typeExists = await _context.TypeAnsware
                    .AnyAsync(t => t.Id == typeId && t.Status == 1);

                if (!typeExists)
                    throw new ValidationException("El tipo de respuesta no existe o está inactivo.");

                bool requiresOptions =
                    typeId == (int)TypeAnswareEnum.OptionSingle ||
                    typeId == (int)TypeAnswareEnum.OptionMulti;

                // ================= CARGAR PREGUNTA EXISTENTE =================
                var existing = await _context.Question
                    .Include(q => q.QuestionOptions)
                    .FirstOrDefaultAsync(q => q.Id == dto.Id.Value);

                if (existing == null)
                    throw new ValidationException("La pregunta no existe.");

                // ================= ACTUALIZAR CAMPOS SIMPLES =================
                existing.Text = dto.Text!;
                existing.TypeAnswerId = typeId;
                existing.Status = dto.Status == 0 ? 1 : dto.Status;
                existing.UpdatedAt = DateTime.UtcNow;

                // ================= MANEJO DE OPCIONES =================
                if (requiresOptions)
                {
                    if (dto.Options == null || !dto.Options.Any())
                        throw new ValidationException(nameof(dto.Options), "Las preguntas de opción deben tener al menos una opción.");

                    if (dto.Options.Any(o => string.IsNullOrWhiteSpace(o.Text)))
                        throw new ValidationException(nameof(dto.Options), "Todas las opciones deben tener texto.");

                    // ⬅️ 1. Declaración de dtoIds (siempre antes)
                    var dtoIds = dto.Options
                        .Where(o => o.Id.HasValue)
                        .Select(o => o.Id!.Value)
                        .ToHashSet();

                    // ⬅️ 2. Detectar cuáles borrar del DB
                    var toDelete = existing.QuestionOptions
                        .Where(o => !dtoIds.Contains(o.Id))
                        .ToList();

                    _context.Set<QuestionOption>().RemoveRange(toDelete);

                    // ⬅️ 3. Actualizar las que quedan
                    foreach (var opt in existing.QuestionOptions.Where(o => dtoIds.Contains(o.Id)))
                    {
                        var dtoOpt = dto.Options!.First(o => o.Id == opt.Id);

                        opt.Text = dtoOpt.Text!;
                        opt.Order = dtoOpt.Order ?? opt.Order;
                        opt.Status = dtoOpt.Status;
                        opt.UpdatedAt = DateTime.UtcNow;
                    }

                    // ⬅️ 4. Agregar nuevas sin Id
                    var newOptions = dto.Options
                        .Where(o => !o.Id.HasValue)
                        .Select((dtoOpt, index) => new QuestionOption
                        {
                            QuestionId = existing.Id,
                            Text = dtoOpt.Text!,
                            Order = dtoOpt.Order ?? existing.QuestionOptions.Count + index + 1,
                            Status = dtoOpt.Status,
                            CreatedAt = DateTime.UtcNow
                        });

                    await _context.Set<QuestionOption>().AddRangeAsync(newOptions);
                }
                else
                {
                    // Si ya no es de opciones → desactivar todas las que tenga
                    foreach (var opt in existing.QuestionOptions)
                    {
                        opt.Status = 0;
                        opt.UpdatedAt = DateTime.UtcNow;
                    }
                }

                // ================= GUARDAR CAMBIOS =================
                var affected = await _context.SaveChangesAsync();
                return affected > 0;
            }
            catch
            {
                throw;
            }
        }





    }
}
