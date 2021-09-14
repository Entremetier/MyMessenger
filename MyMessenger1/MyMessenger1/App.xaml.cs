using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyMessenger1
{
    public partial class App : Application
    {
        public const string MessageListKey = "MessageList";

        public const string VersionKey = "version";

        //Die aktuelle Version
        public const string Version = "1.0.0";

        public App()
        {
            InitializeComponent();

            CheckVersion();

            MainPage = new NavigationPage(new MainPage());
        }

        private void CheckVersion()
        {
            if (Application.Current.Properties.ContainsKey(VersionKey))
            {
                //Prüfen ob es die aktuelle Version ist
                string oldVersion = Application.Current.Properties[App.VersionKey] as string;
                if (oldVersion != Version)
                {
                    //Hier kann man z.B. Datenbank-Upgrades machen, abhängig von der alten Version
                    Application.Current.Properties.Clear();

                    //Aktuelle Version schreiben
                    Application.Current.Properties[App.VersionKey] = App.Version;
                }
            }
            else
            {
                //Von meiner aktuellen Applikation, die Eigenschaft (der VersionKey) ist gleich die Version der Klasse App
                Application.Current.Properties[App.VersionKey] = App.Version;

                //Im Speicher speichern
                Application.Current.SavePropertiesAsync();
            }
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
