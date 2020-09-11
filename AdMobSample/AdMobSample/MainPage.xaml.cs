using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AdMobSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            IInterstitialAd adInterstitial = DependencyService.Get<IInterstitialAd>();
            adInterstitial.Show();
            adInterstitial.AdReceived += AdInterstitial_AdReceived;
        }

        private void AdInterstitial_AdReceived(object sender, EventArgs e)
        {
            this.adText.Text = "After Ads";
        }
    }
}
