using Android.Content;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;
using CoolBeans.Droid.MvxDroidAdaptation;
using CoolBeans.Services;
using MLearning.Droid.AsyncStorage;

namespace CoolBeans.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
            Mvx.RegisterSingleton<IAsyncStorageService>(new DroidAsyncStorageService());
            

        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var presenter = new MvxPagePresenter();
            Mvx.RegisterSingleton<IMvxPageNavigationHost>(presenter);
            return presenter;
        }
    }
}