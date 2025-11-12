using Entity.ConfigModels.global;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Security
{
    public class FormConfig : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.ToTable("form", schema: "security");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired();
            builder.Property(p => p.Path)
                .HasColumnName("path")
                .HasColumnType("text");

            builder.Property(p => p.Order)
               .HasColumnName("order")
               .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("description")
                .HasColumnType("text")
                .IsRequired();

            builder.MapBaseModel();

            builder.HasData(

                 // REPORTES
                 new Form { Id = 27, Name = "Panel", Description = "Informacion estadisticas del sistema", Path = "panel", Order = 1 },

                 // ADMINISTRACIÓN
                 new Form { Id = 1, Name = "Todos", Description = "Vista de todos los registros administrativos", Path = "todos", Order = 1 },
                 new Form { Id = 2, Name = "Administrativos", Description = "Gestión de personal administrativo", Path = "administrativos", Order = 2 },
                 new Form { Id = 3, Name = "Docentes", Description = "Gestión de docentes", Path = "docentes", Order = 3 },
                 new Form { Id = 4, Name = "Niños", Description = "Gestión de estudiantes", Path = "ninos", Order = 4 },
                 new Form { Id = 5, Name = "Acudientes", Description = "Gestión de acudientes", Path = "acudientes", Order = 5 },

                 // ACADÉMICO
                 new Form { Id = 6, Name = "Aulas", Description = "Gestión de aulas", Path = "aulas", Order = 1 },
                 new Form { Id = 7, Name = "Agrupación", Description = "Gestión de agrupaciones", Path = "agrupación", Order = 2 },
                 new Form { Id = 8, Name = "Director de Grupo", Description = "Asignación de directores de grupo", Path = "directorGrupo", Order = 3 },
                 new Form { Id = 9, Name = "Carga Académica", Description = "Gestión de carga académica", Path = "cargaAcademica", Order = 4 },

                 // AGENDA
                 new Form { Id = 10, Name = "Composición", Description = "Gestión de composiciones", Path = "composicion", Order = 1 },
                 new Form { Id = 11, Name = "Agendas", Description = "Gestión de agendas", Path = "agendas", Order = 2 },
                 new Form { Id = 12, Name = "Asignación", Description = "Asignación de agendas", Path = "asignacion", Order = 3 },

                 // CONFIGURACIÓN
                 new Form { Id = 13, Name = "Grados", Description = "Gestión de grados", Path = "grados", Order = 1 },
                 new Form { Id = 14, Name = "Grupos", Description = "Gestión de grupos", Path = "grupos", Order = 2 },
                 new Form { Id = 15, Name = "Tipo Identificación", Description = "Gestión de tipos de identificación", Path = "tipoIdentificacion", Order = 3 },
                 new Form { Id = 16, Name = "EPS", Description = "Gestión de EPS", Path = "eps", Order = 4 },
                 new Form { Id = 17, Name = "Municipios", Description = "Gestión de municipios", Path = "municipio", Order = 5 },
                 new Form { Id = 18, Name = "RH", Description = "Gestión de tipos de sangre", Path = "rh", Order = 6 },

                 // SEGURIDAD
                 new Form { Id = 19, Name = "Roles", Description = "Gestión de roles de usuario", Path = "roles", Order = 1 },
                 new Form { Id = 20, Name = "Permisos", Description = "Gestión de permisos", Path = "permisos", Order = 2 },
                 new Form { Id = 21, Name = "Módulos", Description = "Gestión de módulos", Path = "modulos", Order = 3 },
                 new Form { Id = 22, Name = "Formularios", Description = "Gestión de formularios", Path = "formularios", Order = 4 },
                 new Form { Id = 23, Name = "Asignación Roles", Description = "Asignación de roles a usuarios", Path = "asignacionRoles", Order = 5 },
                 new Form { Id = 24, Name = "Asignación Módulos", Description = "Asignación de módulos a roles", Path = "asiganacionModulos", Order = 6 },
                 new Form { Id = 25, Name = "Asignación de Permisos", Description = "Asignación de permisos a roles", Path = "asignacionPermisos", Order = 7 },
                 new Form { Id = 26, Name = "Usuarios", Description = "Gestión de usuarios", Path = "usuarios", Order = 8 }
             );

        }
    }
}
