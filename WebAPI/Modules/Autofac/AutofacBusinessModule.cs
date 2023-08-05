using Autofac;
using Business.Abstracts;
using Business.Concretes;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Module = Autofac.Module;

namespace WebAPI.Modules.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //Manager
            builder.RegisterType<StudentManager>().As<IStudentService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseManager>().As<ICourseService>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentManager>().As<IDepartmentService>().InstancePerLifetimeScope();
            builder.RegisterType<UserManager>().As<IUserService>().InstancePerLifetimeScope();

            //Repo
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>();
            builder.RegisterType<StudentCourseRepository>().As<IStudentCourseRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<DepartmentRepository>().As<IDepartmentRepository>();


            //Authentication
            builder.RegisterType<AuthManager>().As<IAuthService>().InstancePerLifetimeScope();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().InstancePerLifetimeScope();
        }
    }
}
