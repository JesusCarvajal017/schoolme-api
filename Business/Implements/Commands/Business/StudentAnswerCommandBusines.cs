using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Commands;
using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Dtos.Business.StudentAnsware;
using Entity.Dtos.Business.StudentAnswareOption;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Commands.Business
{
    public class StudentAnswerCommandBusines : BaseCommandsBusiness<StudentAnswer, StudentAnswareDto>, ICommandStAswareServices
    {
        protected readonly ICommandStudentAnswar _data;
        private readonly IQueryStudentAsware _queryStudentAsware;


        public StudentAnswerCommandBusines(
            ICommandStudentAnswar data,
            IMapper mapper,
            ILogger<StudentAnswerCommandBusines> _logger,
            IGenericHerlpers helpers,
            AplicationDbContext context,
            IQueryStudentAsware query
            ) : base(data, mapper, _logger, helpers, context)
        {
            _data = data;
            _queryStudentAsware = query;
        }


        public async Task RegisterAnswersAsync(RegisterStudentAnswersDto dto, CancellationToken ct = default)
        {
            var entities = new List<StudentAnswer>();

            foreach (var a in dto.Answers)
            {
                var answerEntity = new StudentAnswer
                {
                    AgendaDayStudentId = dto.AgendaDayStudentId,
                    QuestionId = a.QuestionId,
                    ValueText = a.ValueText,
                    ValueBool = a.ValueBool,
                    ValueNumber = a.ValueNumber,
                    ValueDate = a.ValueDate,
                    Status = 1,           // si usas status
                    CreatedAt = DateTime.UtcNow,
                };

                // Opciones seleccionadas (OptionSingle / OptionMulti)
                if (a.OptionIds is not null && a.OptionIds.Any())
                {
                    foreach (var optId in a.OptionIds)
                    {
                        answerEntity.SelectedOptions.Add(new StudentAnswerOption
                        {
                            QuestionOptionId = optId,
                            Status = 1,
                            CreatedAt = DateTime.UtcNow,
                        });
                    }
                }

                entities.Add(answerEntity);
            }

            await _data.RegisterAnswersAsync(entities, ct);
        }

        
        public async Task UpdateAnswersAsync(RegisterStudentAnswersDto dto, CancellationToken ct = default)
        {
            // 1️⃣ Cargar respuestas EXISTENTES (TRACKED)
            var existing = await _data.GetTrackedByAgendaDayStudentAsync(dto.AgendaDayStudentId, ct);

            // 2️⃣ Diccionario por QuestionId
            var existingDict = existing.ToDictionary(x => x.QuestionId, x => x);

            // 3️⃣ Recorrer respuestas nuevas
            foreach (var a in dto.Answers)
            {
                if (!existingDict.TryGetValue(a.QuestionId, out var answerEntity))
                {
                    // 3.1️⃣ No existía → crear y AGREGAR AL CONTEXTO
                    answerEntity = new StudentAnswer
                    {
                        AgendaDayStudentId = dto.AgendaDayStudentId,
                        QuestionId = a.QuestionId,
                        Status = 1,
                        CreatedAt = DateTime.UtcNow,
                    };

                    _data.Add(answerEntity);        // 👈 ESTA ES LA CLAVE
                    existingDict[a.QuestionId] = answerEntity;
                }

                // 3.2️⃣ Actualizar valores
                answerEntity.ValueText = a.ValueText;
                answerEntity.ValueBool = a.ValueBool;
                answerEntity.ValueNumber = a.ValueNumber;
                answerEntity.ValueDate = a.ValueDate;
                answerEntity.UpdatedAt = DateTime.UtcNow;

                // 3.3️⃣ Actualizar opciones seleccionadas
                var oldOptionIds = answerEntity.SelectedOptions
                    .Select(o => o.QuestionOptionId)
                    .ToList();

                var newOptionIds = a.OptionIds ?? new List<int>();

                // Quitar las que ya no están
                var toRemove = answerEntity.SelectedOptions
                    .Where(o => !newOptionIds.Contains(o.QuestionOptionId))
                    .ToList();

                foreach (var rem in toRemove)
                {
                    answerEntity.SelectedOptions.Remove(rem);
                }

                // Agregar nuevas
                var toAdd = newOptionIds
                    .Where(id => !oldOptionIds.Contains(id))
                    .ToList();

                foreach (var id in toAdd)
                {
                    answerEntity.SelectedOptions.Add(new StudentAnswerOption
                    {
                        QuestionOptionId = id,
                        Status = 1,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            // 4️⃣ Guardar cambios
            await _data.SaveChangesAsync(ct);
        }


        public async Task ApplyGlobalAnswersAsync(
        RegisterGlobalStudentAnswersDto dto,
        CancellationToken ct = default)
        {
            // 1️⃣ Buscar todos los estudiantes activos del grupo
            var students = await _context.Students
                .Where(s => s.GroupId == dto.GroupId && s.Status == 1)
                .ToListAsync(ct);

            if (!students.Any())
                return;

            // 2️⃣ Para cada estudiante del grupo...
            foreach (var student in students)
            {
                // 2.1️⃣ Asegurar que exista el AgendaDayStudent
                var ads = await _context.AgendaDayStudent
                    .FirstOrDefaultAsync(x =>
                        x.AgendaDayId == dto.AgendaDayId &&
                        x.StudentId == student.Id,
                        ct);

                if (ads is null)
                {
                    ads = new AgendaDayStudent
                    {
                        AgendaDayId = dto.AgendaDayId,
                        StudentId = student.Id,
                        AgendaDayStudentStatus = 1, // ajusta según tu enum
                        Status = 1,
                        CreatedAt = DateTime.UtcNow
                    };

                    _context.AgendaDayStudent.Add(ads);
                    await _context.SaveChangesAsync(ct); // para obtener ads.Id
                }

                // 2.2️⃣ Reutilizar la lógica de UpdateAnswersAsync
                var perStudentDto = new RegisterStudentAnswersDto
                {
                    AgendaDayStudentId = ads.Id,
                    Answers = dto.Answers
                };

                await UpdateAnswersAsync(perStudentDto, ct);
            }
        }






    }
}
