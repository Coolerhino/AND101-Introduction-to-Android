using System;
using System.Globalization;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Text;

namespace TipCalculator
{
    [Activity(Label = "TipCalculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        EditText _nettoPriceText;
        Button _calculateTotalButton;
        TextView _taxText;
        TextView _totalText;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            _nettoPriceText = FindViewById<EditText>(Resource.Id.priceNettoText);
            _nettoPriceText.InputType = InputTypes.ClassNumber | InputTypes.NumberFlagDecimal;
            _calculateTotalButton = FindViewById<Button>(Resource.Id.calculatePriceButton);
            _taxText = FindViewById<TextView>(Resource.Id.taxText);
            _totalText = FindViewById<TextView>(Resource.Id.priceBruttoText);

            _calculateTotalButton.Click += (object sender, EventArgs args) =>
           {
               if (TextUtils.IsEmpty(_nettoPriceText.Text))
               {
                   _nettoPriceText.Error = "Input netto price you wish to calculate";
               }
               else
               {
                   var netto = double.Parse(_nettoPriceText.Text, CultureInfo.InvariantCulture); // Without CultureInfo.InvariantCulture any number with dot is not accepted
                   var tax = netto * 0.23;
                   _taxText.Text = $"{tax}";
                   _totalText.Text = $"{netto + tax}";
               }
               //_taxText.Text = tax.ToString();
               //_totalText.Text = String.Format("{0}", (netto + tax));
               // Interpolated string is similar to String.Format, but simplifies its use
           };
        }
    }
}

