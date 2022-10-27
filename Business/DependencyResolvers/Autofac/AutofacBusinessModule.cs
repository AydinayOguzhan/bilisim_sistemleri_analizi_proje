using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<DayManager>().As<IDayService>();
            builder.RegisterType<EfDayDal>().As<IDayDal>();

            builder.RegisterType<FoodManager>().As<IFoodService>();
            builder.RegisterType<EfFoodDal>().As<IFoodDal>();

            builder.RegisterType<MoveManager>().As<IMoveService>();
            builder.RegisterType<EfMoveDal>().As<IMoveDal>();

            builder.RegisterType<ReadyToUseDietFoodManager>().As<IReadyToUseDietFoodService>();
            builder.RegisterType<EfReadyToUseDietFoodDal>().As<IReadyToUseDietFoodDal>();

            builder.RegisterType<ReadyToUseDietManager>().As<IReadyToUseDietService>();
            builder.RegisterType<EfReadyToUseDietDal>().As<IReadyToUseDietDal>();

            builder.RegisterType<SubscriptionManager>().As<ISubscriptionService>();
            builder.RegisterType<EfSubscriptionDal>().As<ISubscriptionDal>();

            builder.RegisterType<UserDietManager>().As<IUserDietService>();
            builder.RegisterType<EfUserDietDal>().As<IUserDietDal>();

            builder.RegisterType<UserMoveManager>().As<IUserMoveService>();
            builder.RegisterType<EfUserMoveDal>().As<IUserMoveDal>();

            builder.RegisterType<WorkoutPlanManager>().As<IWorkoutPlanService>();
            builder.RegisterType<EfWorkoutPlanDal>().As<IWorkoutPlanDal>();

            builder.RegisterType<WorkoutPlanMoveManager>().As<IWorkoutPlanMoveService>();
            builder.RegisterType<EfWorkoutPlanMoveDal>().As<IWorkoutPlanMoveDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
