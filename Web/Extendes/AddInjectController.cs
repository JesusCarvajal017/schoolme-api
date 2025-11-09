using Business.Implements.Auth;
using Business.Implements.Bases;
using Business.Implements.Commands.Security;
using Business.Implements.Notification;
using Business.Implements.Querys.Business;
using Business.Implements.Querys.Security;
using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Data.Implements.Auth;
using Data.Implements.Commands;
using Data.Implements.Commands.Security;
using Data.Implements.Querys;
using Data.Implements.Querys.Business;
using Data.Implements.Querys.Parameters;
using Data.Implements.Querys.Security;
using Data.Implements.View;
using Data.Infrastructure.Interceptors;
using Data.Interfaces.Group.Commands;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Security.UserRol;
using Entity.Model.Business;
using Entity.Model.Paramters;
using Entity.Model.Security;
using StackExchange.Redis;
using Utilities.Helpers.Validations;
using Utilities.Helpers.Validations.implemets;
using Utilities.Jwt;
using Utilities.Redis.Implement;
using Utilities.Redis.Interface;
using Utilities.SignalR.Interfaces;

namespace Web.Extendes
{
    public static class AddInjectController
    {
        public static IServiceCollection AddInject(this IServiceCollection services)
        {

            // ============================ Inyecciones genericas ============================ 

            // Coommand === Data
            services.AddScoped(
                  typeof(IQuerys<>),
                  typeof(BaseGenericQuerysData<>)
            );

            services.AddScoped(
                typeof(ICommands<>),
                typeof(BaseGenericCommandsData<>)
            );

            // servicios === business
            services.AddScoped(
                  typeof(IQueryServices<,>),
                  typeof(BaseQueryBusiness<,>)
                );
            services.AddScoped(
                typeof(ICommandService<,>),
                typeof(BaseCommandsBusiness<,>)
            );

            // ============================  inyecciones concretas ============================ 

            // ================ QUERYS ================

            // QUERY DATA 
            services.AddScoped(
                typeof(IQuerys<RolFormPermission>),
                typeof(RolFormPermissionQueryData)
            );

            services.AddScoped(
                typeof(IQuerys<ModuleForm>),
                typeof(ModuleFormQueryData)
            );

            services.AddScoped(
                typeof(IQuerys<GroupDirector>),
                typeof(GroupDirectorQueryData)
            );

            services.AddScoped(
                typeof(IQuerys<User>),
                typeof(UserQueryData)
            );

            services.AddScoped(
                typeof(IQuerys<Groups>),
                typeof(GroupsQueryData)
            );

            services.AddScoped(
             typeof(IQuerys<Teacher>),
             typeof(TeacherQueryData)
            );

            services.AddScoped(
             typeof(IQuerys<Tutition>),
             typeof(TutitionQueryData)
            );

            services.AddScoped(typeof(IQuerys<Student>), typeof(StudentQueryData));
            services.AddScoped(typeof(IQuerys<Teacher>), typeof(TeacherQueryData));
            services.AddScoped(typeof(IQuerys<Attendants>), typeof(AttendansQueryData));


            // muncipality
            services.AddScoped<IQuerysMunicipality, MunicipalityQueryData>();
            services.AddScoped<IQueryMunicipalityServices, MunicipalityQueryBusiness>();

            // person
            services.AddScoped<IQuerysPerson, PersonQueryData>();
            services.AddScoped<IQueryPersonServices, PersonQueryBusiness>();

            // Academic load
            services.AddScoped<IQuerysAcademicLoad, AcademimcLoadQueryData>();
            services.AddScoped<IQueryAcLoadServices, AcLoadQueryBusiness>();


            // user - rol
            services.AddScoped<IQuerysUserRol, UserRolQueryData>();
            services.AddScoped<IQueryUserRolServices, UserRolQueryBusiness>();

            // attendans
            services.AddScoped<IQuerysAttendas, AttendansQueryData>();
            services.AddScoped<IQueryAttendansServices, AttendansQueryBusiness>();

            // ================ COMMANDS ================
            services.AddScoped(
                typeof(ICommands<User>),
                typeof(UserCommandData)
            );


            // user
            services.AddScoped<ICommandUser, UserCommandData>();
            services.AddScoped<ICommandUserServices, UserCommandBusines>();

            //Person
            services.AddScoped<ICommanPerson, PersonCommandData>();
            services.AddScoped<ICommandPersonServices, PersonCommandBusines>();

            //services.AddScoped();
            services.AddScoped<AuthBusiness>();
            services.AddScoped<LoginData>();
            services.AddScoped<GenerateToken>();

            services.AddScoped<IGenericHerlpers, GenericHelpers>();
  
            services.AddScoped<LogginDbCommandsInterceptor>();
            services.AddScoped<ViewData>();




            // ================================================================================
            //                               servicios de terceros                     
            // ================================================================================

            // servicio de redis
            services.AddScoped<IPasswordResetStore, PasswordResetStoreRedis>();
            services.AddSingleton<IRedisConnection, RedisConnection>();

            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var cfg = sp.GetRequiredService<IConfiguration>();
                var cs = cfg.GetConnectionString("Redis")
                         ?? throw new InvalidOperationException("Falta ConnectionStrings:Redis");

                return ConnectionMultiplexer.Connect(cs);
            });

            // servicio de notificacion
            services.AddScoped<INotificationsService, NotificationServices>();



            return services;

        }
    }
}
