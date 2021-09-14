using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyMessenger1
{
    public partial class App : Application
    {
        public const string MessageListKey = "MessageList";

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
