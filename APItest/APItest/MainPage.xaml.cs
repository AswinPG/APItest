using APItest.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace APItest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {


        Data data;
        Datas dat;
        string v = "gjhvjh";
        Data data1;
        int i = 0;
        Data data2;
        public MainPage()
        {
            InitializeComponent();


            

            LoadContent();
        }

        public async void LoadContent()
        {


            //Datas datasList = new Datas()
            //{
            //    datas =
            //    {
            //        new Data()
            //        {
            //            Description="njknjk",
            //            Heading="jkbjk",
            //            Name="njnjk",
            //            PostedOn="njkn",
            //            Status="njnjk"
            //        },
            //        new Data()
            //        {
            //            Description="njknjk",
            //            Heading="jkbjk",
            //            Name="njnjk",
            //            PostedOn="njkn",
            //            Status="njnjk"
            //        },
            //        new Data()
            //        {
            //            Description="njknjk",
            //            Heading="jkbjk",
            //            Name="njnjk",
            //            PostedOn="njkn",
            //            Status="njnjk"
            //        }
            //    }
            //};

            //Datas datasList2 = new Datas()
            //{
            //    datas =
            //    {
            //        new Data()
            //        {
            //            Description="njknjk",
            //            Heading="jkbjk",
            //            Name="njnjk",
            //            PostedOn="njkn",
            //            Status="njnjk"
            //        },
            //        new Data()
            //        {
            //            Description="njknjk",
            //            Heading="jkbjk",
            //            Name="njnjk",
            //            PostedOn="njkn",
            //            Status="njnjk"
            //        },
            //        new Data()
            //        {
            //            Description="njknjk",
            //            Heading="jkbjk",
            //            Name="njnjk",
            //            PostedOn="njkn",
            //            Status="njnjk"
            //        }
            //    }
            //};

            //var X = datasList.datas[0];


            //datasList.datas.Add(datasList2.datas[0]);


            string url = "https://us-central1-tuto-ff870.cloudfunctions.net/ForumDisplay1";

            HttpResponseMessage responseMessage = null;
            HttpResponseMessage responseMessage1 = null;

            //HttpContent httpContent = new FormUrlEncodedContent(data);

            Req req = new Req()
            {
                Status = "Discussion",
                PostedOn = "first"
            };

            //HttpContent httpContent = new FormUrlEncodedContent(req);

            var json = JsonConvert.SerializeObject(req);

            try
            {
                //responseMessage = await APIHelper.APIClient.GetAsync(url);
                responseMessage1 = await APIHelper.APIClient.PostAsJsonAsync(url, req);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            //HttpResponseMessage responseMessage = await APIHelper.APIClient.GetAsync(url);


            //var content = responseMessage.Content.ReadAsStringAsync();



            //data = await responseMessage.Content.ReadAsAsync<Data>();
            //data2 = await responseMessage1.Content.ReadAsAsync<Data>();
            var x = await responseMessage1.Content.ReadAsStringAsync();
            dat = await responseMessage1.Content.ReadAsAsync<Datas>();

            Datas datas67 = new Datas();

            var testvar = await responseMessage1.Content.ReadAsStringAsync();
            Newtonsoft.Json.JsonConvert.PopulateObject(testvar, datas67);
            
        }



        //public void Addcontent()
        //{
        //    i++;
        //    data1 = new Data() { message = "Added" + i.ToString(), strings = new List<string> { "Aswin" + i.ToString(), "Haris" + i.ToString(), "Arshu" + i.ToString() } };
        //}





        private async void Button_Clicked(object sender, EventArgs e)
        {

            //Addcontent();
            //await LoadContent();
            //Message.Text = data2.message;
            //st1.Text = data2.strings[0];
            //st2.Text = data2.strings[1];
            //st3.Text = data2.strings[2];
        }
    }
    public class Data
    {
        public string Description { get; set; }
        public string Heading { get; set; }
        public string Name { get; set; }
        public string PostedOn { get; set; }
        public string Status { get; set; }

    }


    public class Questions
    {
        public string docID { get; set; }
        public Data q { get; set; }
    }


    public class Datas
    {
        public List<Questions> Questions { get; set; }
    }
    public class Req
    {
        public string Status { get; set; }
        public string PostedOn { get; set; }
    }
    
}
