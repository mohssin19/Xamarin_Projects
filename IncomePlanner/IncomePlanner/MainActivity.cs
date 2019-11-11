using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace IncomePlanner
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {


        // Declare All Items In XAML View

        EditText workHoursPerDayEditText;
        EditText payRatePerHourEditText;
        EditText taxRateEditText;
        EditText savingsRateEditText;

        TextView workSummaryTextView;
        TextView grossIncomeTextView;
        TextView taxPayableTextView;
        TextView savingsTextView;
        TextView spendingTextView;

        Button btnCalculate;
        RelativeLayout resultLayout;

        bool inputCalculated = false;

        void ConnectViews()
        {
            //option 1 of connecting elements in XAML to C#
            workHoursPerDayEditText = FindViewById<EditText>(Resource.Id.workHoursPerDayEditText);
            taxRateEditText = FindViewById<EditText>(Resource.Id.taxRateEditText);

            //option 2 of connection elements in XAML to C# 
            payRatePerHourEditText = (EditText)FindViewById(Resource.Id.payRatePerHourEditText);
            savingsRateEditText = (EditText)FindViewById(Resource.Id.savingsRateEditText);

            //option 1 AGAIN (TEXTVIEW)
            workSummaryTextView = FindViewById<TextView>(Resource.Id.workSummaryTextView);
            grossIncomeTextView = FindViewById<TextView>(Resource.Id.grossIncomeTextView);

            //option 2 AGAIN (TEXTVIEW)
            taxPayableTextView = (TextView)FindViewById(Resource.Id.taxPayableTextView);
            savingsTextView = (TextView)FindViewById(Resource.Id.savingsTextView);
            spendingTextView = (TextView)FindViewById(Resource.Id.spendingTextView);


            btnCalculate = (Button)FindViewById(Resource.Id.btnCalculate);
            resultLayout = (RelativeLayout)FindViewById(Resource.Id.resultLayout);

            btnCalculate.Click += BtnCalculate_Click;

        }

        private void BtnCalculate_Click(object sender, System.EventArgs e)
        {

            if (inputCalculated)
            {
                inputCalculated = false;
                btnCalculate.Text = "Calculate";
                ClearInput();
                return;
            }

            // Take Inputs from user
            double payRatePerHour = double.Parse(payRatePerHourEditText.Text);
            double workHoursPerDay = double.Parse(workHoursPerDayEditText.Text);
            double taxRate = double.Parse(taxRateEditText.Text);
            double savingRate = double.Parse(savingsRateEditText.Text);

            double annualWorkHoursSummary = workHoursPerDay * 5 * 50; // 52 weeks in a year, leeway of 2 weeks off
            double annualIncome = payRatePerHour * workHoursPerDay * 5 * 50;
            double taxPayable = (taxRate / 100) * annualIncome;
            double annualSaving = (savingRate / 100) * annualIncome;
            double spendableIncome = annualIncome - annualSaving - taxPayable;

            // Display Results of Calculations
            grossIncomeTextView.Text = annualIncome.ToString("#,##") + " GBP"; 
            workSummaryTextView.Text = annualWorkHoursSummary.ToString("#,##") + " HRS";
            taxPayableTextView.Text = taxPayable.ToString("#,##") + " GBP";
            savingsTextView.Text = annualSaving.ToString("#,##") + " GBP";
            spendingTextView.Text = spendableIncome.ToString("#,##") + " GBP";

            resultLayout.Visibility = Android.Views.ViewStates.Visible;
            inputCalculated = true;

            btnCalculate.Text = "Clear Data";
        }



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            ConnectViews();
        }

        void ClearInput() 
        {
            payRatePerHourEditText.Text = "";
            workHoursPerDayEditText.Text = "";
            taxRateEditText.Text = "";
            savingsRateEditText.Text = "";

            resultLayout.Visibility = Android.Views.ViewStates.Invisible;
        }




    }
}