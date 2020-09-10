using System;

using AdMobSample.Droid;

using Android.Content;
using Android.Gms.Ads;
using Android.Media;

[assembly: Xamarin.Forms.Dependency(typeof(InterstitialAdAndroid))]
namespace AdMobSample.Droid
{
    class InterstitialAdAndroid : AdListener, IInterstitialAd
    {
        public event EventHandler AdReceived;

        Android.Gms.Ads.InterstitialAd _ad;
        Context context = Android.App.Application.Context;
        int prevVolumn = 0;

        public void Show()
        {
            //var context = Android.App.Application.Context;
            Android.Gms.Ads.InterstitialAd ad = new Android.Gms.Ads.InterstitialAd(context);
            ad.AdUnitId = "ca-app-pub-4681470946279796/3704231820";

            _ad = ad;
            OnAdLoaded();
            ad.AdListener = this;

            var requestbuilder = new AdRequest.Builder();
            ad.LoadAd(requestbuilder.Build());
        }

        public override void OnAdClosed()
        {
            UnMmuteSound();
        }

        public override void OnAdLoaded()
        {
            base.OnAdLoaded();
            MuteSound();

            if (_ad.IsLoaded)
                _ad.Show();
        }

        private void UnMmuteSound()
        {
            AudioManager aManager = (AudioManager)context.GetSystemService(Context.AudioService);
            //if (aManager.IsStreamMute(Stream.Music))
            //{
            //    aManager.SetStreamVolume(Stream.Music, prevVolumn, VolumeNotificationFlags.ShowUi);
            //}
            aManager.SetStreamMute(Stream.Music, false);
        }
        private void MuteSound()
        {
            AudioManager aManager = (AudioManager)context.GetSystemService(Context.AudioService);
            prevVolumn = aManager.GetStreamVolume(Stream.Music);
            aManager.SetStreamMute(Stream.Music, true);
        }
    }
}