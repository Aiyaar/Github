using System;
using Github.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Github
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SeasonPage();
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
