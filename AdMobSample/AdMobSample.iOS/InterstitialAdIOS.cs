using System;
using System.Threading.Tasks;

using AdMobSample.iOS;

using Google.MobileAds;

using UIKit;

using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(InterstitialAdIOS))]
namespace AdMobSample.iOS
{
    public class InterstitialAdIOS : IInterstitialAd
    {
        public event EventHandler AdReceived;

        Interstitial interstitialAd;

        public async void Show()
        {
            this.interstitialAd = new Interstitial("ca-app-pub-4681470946279796/6918510534");
            this.interstitialAd.LoadRequest(Request.GetDefaultRequest());

            this.interstitialAd.AdReceived += InterstitialAd_AdReceived;

            while (!this.interstitialAd.IsReady)
            {
                await Task.Delay(100);
            }
        }

        private void InterstitialAd_AdReceived(object sender, System.EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => this.interstitialAd.PresentFromRootViewController(UIApplication.SharedApplication.Windows[0].RootViewController));

            AdReceived?.Invoke(null, null);
        }
    }
}