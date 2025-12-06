using Entity.ConfigModels.Business;
using Entity.ConfigModels.Parameters;
using Entity.ConfigModels.Security;
using Entity.Model.Business;
using Entity.Model.Notification;
using Entity.Model.Paramters;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;

namespace Entity.Context.Main
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options ) : base (options)
        {
                    
        }

        // Servicios
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }

        // Modulo de seguridad
        public DbSet<Person> Person { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<UserRol> UserRol { get; set; }
        public DbSet<ModuleForm> ModuleForm { get; set; }
        public DbSet<RolFormPermission> RolFormPermission { get; set; }


        //Modulo de parametros
        public DbSet<Departament> Departament { get; set; }
        public DbSet<Munisipality> Munisipality { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<Eps> Eps { get; set; }
        public DbSet<MaterialStatus> MaterialStatus { get; set; }
        public DbSet<Rh> Rh { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<TypeAnsware> TypeAnsware { get; set; }


        //Modulo de negocio
        public DbSet<DataBasic> DataBasic { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Attendants> Attendants { get; set; }
        public DbSet<Question> Question { get; set; }


        public DbSet<GroupDirector> GroupDirector { get; set; }
        public DbSet<Tutition> Tutition { get; set; }
        public DbSet<CompositionAgendaQuestion> CompositionAgendaQuestion { get; set; }
        public DbSet<AgendaDayStudent> AgendaDayStudent { get; set; }
        public DbSet<StudentAnswer> StudentAnswer { get; set; }

        public DbSet<AcademicLoad> AcademicLoad { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica tu configuración que implementen IEntityTypeConfiguration<T>

            // Prioridad de crecion 1
            modelBuilder.ApplyConfiguration(new DepartamentConfig());
            modelBuilder.ApplyConfiguration(new MunisipalityConfig());
            modelBuilder.ApplyConfiguration(new RhConfig());
            modelBuilder.ApplyConfiguration(new EpsConfig());
            modelBuilder.ApplyConfiguration(new DocumentTypeConfig());
            modelBuilder.ApplyConfiguration(new MaterialStatusConfig());

            // academico parte del negocio
            modelBuilder.ApplyConfiguration(new GradeConfig());
            modelBuilder.ApplyConfiguration(new SubjectConfig());
            modelBuilder.ApplyConfiguration(new TypeAnswareConfig());
            modelBuilder.ApplyConfiguration(new GroupsConfig());


            modelBuilder.ApplyConfiguration(new ModuleConfig());
            modelBuilder.ApplyConfiguration(new FormConfig());
            modelBuilder.ApplyConfiguration(new RolConfig());
            modelBuilder.ApplyConfiguration(new PermissionConfig());
            
            modelBuilder.ApplyConfiguration(new ModuleFormConfig());
            modelBuilder.ApplyConfiguration(new RolFormPermissionConfig());

            // Modulo de parametros
            modelBuilder.ApplyConfiguration(new PersonConfig());

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new UserRolConfig());

            //Actores principales 
            modelBuilder.ApplyConfiguration(new AttendantsConfig());
            modelBuilder.ApplyConfiguration(new TeacherConfig());
            modelBuilder.ApplyConfiguration(new StudentConfig());

            modelBuilder.ApplyConfiguration(new GroupDirectorConfig());
            modelBuilder.ApplyConfiguration(new AcademicLoadConfig());

            // negocio
            modelBuilder.ApplyConfiguration(new QuestionConfig());
            modelBuilder.ApplyConfiguration(new QuestionOptionConfig());
            modelBuilder.ApplyConfiguration(new StudentAnswareConfig());
            modelBuilder.ApplyConfiguration(new StudentAnswareOptionsConfig());


            //Modulo de negocio
            modelBuilder.ApplyConfiguration(new DataBasicConfig());

            modelBuilder.ApplyConfiguration(new AgendaConfig());
            modelBuilder.ApplyConfiguration(new AgendaDayConfig());
            modelBuilder.ApplyConfiguration(new AgendaDayStudentConfig());

            modelBuilder.ApplyConfiguration(new CompositionConfig());

            modelBuilder.ApplyConfiguration(new TeacherObservationConfig());

        }


    }
}
