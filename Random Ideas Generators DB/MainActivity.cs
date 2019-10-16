using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

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
         Button addButton;

        

             

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Setting UI ID's to variables

            ideaText = (EditText)FindViewById(Resource.Id.ideaText1);
            rollButton = (Button)FindViewById<TextView>(Resource.Id.rollButton);
            addButton = (Button)FindViewById<TextView>(Resource.Id.addButton);

            textView2 = (TextView)FindViewById<TextView>(Resource.Id.textView2);

            // Command to auto add event handler
            rollButton.Click += RollButton_Click;
            addButton.Click += AddButton_Click;

            // Rename App
            SupportActionBar.Title = "Random Ideas Generator App";

            
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


            
            //myAL.Add(ideaText.Text.ToString());

            //foreach (var item in myAL)
            //{
            //    //textView2.Text += item.ToString() +"\n";
            //    textView2.Text = 
            //    ideaText.Text = "";
            //}
            textView2.Text = randomIdea;


        }
    }
}