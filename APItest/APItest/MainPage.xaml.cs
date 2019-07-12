using APItest.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace APItest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {


        Data data;
        Data data1;
        int i = 0;
        Data data2;
        public MainPage()
        {
            InitializeComponent();

            
            data1 = new Data()
            {
                message = "Test",
                strings = new List<string>
                {
                    "Aswin","Haris","Arshu"
                }
            };

            LoadContent();
        }

        public async Task LoadContent()
        {

            

            string url = "https://us-central1-tuto-ff870.cloudfunctions.net/helloWorld";

            HttpResponseMessage responseMessage = null;

            try
            {
                responseMessage = await APIHelper.APIClient.GetAsync(url);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            //HttpResponseMessage responseMessage = await APIHelper.APIClient.GetAsync(url);
            HttpResponseMessage responseMessage1 = await APIHelper.APIClient.PostAsJsonAsync(url, data1);

            var content = responseMessage.Content.ReadAsStringAsync();

            data = await responseMessage.Content.ReadAsAsync<Data>();
            data2 = await responseMessage1.Content.ReadAsAsync<Data>();

            
        }



        public void Addcontent()
        {
            i++;
            data1 = new Data() { message = "Added" + i.ToString(), strings = new List<string> { "Aswin" + i.ToString(), "Haris" + i.ToString(), "Arshu" + i.ToString() } };
        }





        private async void Button_Clicked(object sender, EventArgs e)
        {

            Addcontent();
            await LoadContent();
            Message.Text = data2.message;
            st1.Text = data2.strings[0];
            st2.Text = data2.strings[1];
            st3.Text = data2.strings[2];
        }
    }
    public class Data
    {
        public string message { get; set; }
        public List<string> strings { get; set; }
    }
}
