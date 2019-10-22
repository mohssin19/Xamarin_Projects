using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Net;
using System.IO;

namespace LuckyNumber
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]


    public class MainActivity : AppCompatActivity
    {
        static List<string> idea = new List<string>();
        static int currentIdea;



        // Variables of controls declared

        EditText ideaText;
        Button rollButton;
        ListView listView;
        TextView textView2;
        Button addButton, testButton;





        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Setting UI ID's to variables

            ideaText = (EditText)FindViewById(Resource.Id.ideaText1);
            rollButton = (Button)FindViewById<TextView>(Resource.Id.rollButton);
            addButton = (Button)FindViewById<TextView>(Resource.Id.addButton);
            testButton = (Button)FindViewById<TextView>(Resource.Id.TestButton);


            textView2 = (TextView)FindViewById<TextView>(Resource.Id.textView2);

            // Command to auto add event handler
            rollButton.Click += RollButton_Click;
            addButton.Click += AddButton_Click;
            testButton.Click += TestButton_Click;

            // Rename App
            SupportActionBar.Title = "Random Ideas Generator App";


        }

        private void TestButton_Click(object sender, EventArgs e)
        {

            Random random = new Random();

            using (var webCon = new WebClient())
            {
                var webData = webCon.DownloadString("https://raw.githubusercontent.com/philanderson888/data/master/RandomThoughts.dat");
                var lines = webData.Split('\n');
                var myRandomLine = lines[random.Next(0, lines.Length - 1)];

                List<string> thoughtsData = new List<string>();
                thoughtsData.Add(myRandomLine);
                textView2.Text = (myRandomLine).ToString();


                textView2.Text = myRandomLine;

            }








        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (ideaText.Text != "")
            {
                idea.Add(ideaText.Text.ToString());
                ideaText.Text = "";
            }
            
        }

        private void RollButton_Click(object sender, System.EventArgs e)
        {
            Random random = new Random();

            int newIdea = random.Next(0, idea.Count);
            while (currentIdea == newIdea)
            {
                newIdea = random.Next(0, idea.Count);
            }

            currentIdea = newIdea;

           string randomIdea = idea[currentIdea];
           textView2.Text = randomIdea;

        }
    }
}