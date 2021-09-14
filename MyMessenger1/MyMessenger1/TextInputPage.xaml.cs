using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyMessenger1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextInputPage : ContentPage
    {
        string user;

        public TextInputPage(Message msg, string user)
        {
            InitializeComponent();

            LabelUsername.Text = "Chat mit " + msg.Sender;
            LabelMessage.Text = msg.Text;
            this.user = user;
        }

        public TextInputPage(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void ButtonSend_Clicked(object sender, EventArgs e)
        {
            Message newMessage = new Message()
            { Text = EditorNewMessage.Text, Sender = user };

            MainPage.MessageList.Add(newMessage);

            //Im Dictionary speichern

            //Aus der Message einen Json string machen und als string speichern
            string jsonString = JsonConvert.SerializeObject(MainPage.MessageList);
          
            //Speichert im Arbeitsspeicher
            Application.Current.Properties[App.MessageListKey] = jsonString;

            //Speichert vom Arbeitsspeicher in den richtigen Speicher
            Application.Current.SavePropertiesAsync();

            Navigation.PopAsync();
        }

        async private void ButtonDelete_Clicked(object sender, EventArgs e)
        {
            //Die Liste leeren
            //MainPage.MessageList.Clear();

            //ODER

            MainPage.MessageList = new List<Message>();

            //Den internen Speicher der App löschen, die Nachrichten über den Key da es sich um ein Dictionary handelt
            Application.Current.Properties.Remove(App.MessageListKey);

            //Speichert vom Arbeitsspeicher in den richtigen Speicher
            await Application.Current.SavePropertiesAsync();

            //Zurück zur Startseite, die aktuelle Seite wird vom Stack genommen
            await Navigation.PopAsync();
        }
    }
}