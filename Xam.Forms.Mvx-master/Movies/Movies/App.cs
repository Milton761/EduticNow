using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using CoolBeans.Services;
using CoolBeans.ViewModels;
using Core.Session;
using System.Diagnostics;

namespace CoolBeans
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //var service = new MLearningAzureService(new WAMSRepositoryService());
            //Mvx.RegisterSingleton<IMLearningService>(service);
            /*
            Debug.WriteLine("__________________________________GO");
            string username = "aocsa";
            int user_id = 1;
            bool isloged = SessionService.HasLoggedIn(out username, out user_id);
            */


            Debug.WriteLine("__________________________________DONEE_________________");

            

			RegisterAppStart<LoginViewModel>();
        }
    }
}