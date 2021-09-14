using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace MyMessenger1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static List<Message> MessageList = new List<Message>();
        string[] users = new string[2];

        private int userCount = 0;

        private string getUser()
        {
            userCount++;
            userCount %= 2;

            return users[userCount];
        }

        public MainPage()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey(App.MessageListKey))
            {
                DecideLoadMessage();
            }
        }

        async void DecideLoadMessage()
        {
            bool answer = await DisplayAlert("Frage!", "Nachricht laden?", "Yes", "No");

            if (answer)
            {
                //Generisches object kommt zurück und muss konvertiert werden (as string)
                string jsonString = Application.Current.Properties[App.MessageListKey] as string;

                //Konvertieren des deserialisierten jsonString als List<Message>
                MainPage.MessageList = JsonConvert.DeserializeObject<List<Message>>(jsonString);
            }
        }

        private void BtnStart_Clicked(object sender, EventArgs e)
        {
            //User speichern
            users[0] = EntryUserA.Text;
            users[1] = EntryUserB.Text;

            //Message an Page übergeben
            Message tmpMessage = new Message() { Text = "", Sender = users[1] };
            Navigation.PushAsync(new TextInputPage(tmpMessage, users[0]));
        }

        //Wird aufgerufen wenn die Seite in den Vordergrund kommt
        protected override void OnAppearing()
        {
            //base.OnAppearing();

            if (MessageList.Count > 0)
            {
                Navigation.PushAsync(new TextInputPage(MessageList.LastOrDefault(), getUser()));
            }
        }
    }
}
