using Autofac;
using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Book
            builder.RegisterType<StudentManager>().As<IStudentService>();



            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>();
   
            builder.RegisterType<DepartmentRepository>().As<IDepartmentRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();

            //Category
            //builder.RegisterType<CategoryManager>().As<ICategoryService>();
            //builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();

            //User
            //builder.RegisterType<UserManager>().As<IUserService>();
            //builder.RegisterType<UserRepository>().As<IUserRepository>();

        }
    }
}
