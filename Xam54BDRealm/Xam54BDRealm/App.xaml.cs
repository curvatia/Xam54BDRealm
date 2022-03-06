using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam54BDRealm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new Views.Inicio();
            //MainPage = new NavigationPage(new Views.Inicio());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
