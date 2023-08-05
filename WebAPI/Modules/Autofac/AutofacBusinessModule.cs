using Autofac;
using Business.Abstracts;
using Business.Concretes;
using Core.UnitOfWork;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.UnitOfWork;
using Module = Autofac.Module;

namespace WebAPI.Modules.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(BaseService<>)).As(typeof(IBaseService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();  //IUnitofWork ü gördüğünde UnitOfWork ü nesne örneği al


            //Book
            builder.RegisterType<StudentManager>().As<IStudentService>();
            builder.RegisterType<CourseManager>().As<ICourseService>();
            builder.RegisterType<DepartmentManager>().As<IDepartmentService>();

            //Repo
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>();
            builder.RegisterType<StudentCourseRepository>().As<IStudentCourseRepository>();


        }
    }
}
