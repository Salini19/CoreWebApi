using Autofac;
using CoreWebApi.Services;

namespace CoreWebApi
{
    public sealed class AutofacModule : Module
    {
        
            protected override void Load(ContainerBuilder builder)
            {


            // Transient
           
            builder.RegisterType<Methods>().As<IMethods>()
                .InstancePerDependency();


            //// Scoped
            //builder.RegisterType<Methods>().As<IMethods>()
            //        .InstancePerLifetimeScope();

            //// Singleton
       
            //builder.RegisterType<Methods>().As<IMethods>()
            //    .SingleInstance();



        }
        


    }
}
