using AdMobSample;
using AdMobSample.iOS;

using CoreGraphics;

using Google.MobileAds;

using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AdBanner), typeof(AdBannerRenderer))]
namespace AdMobSample.iOS
{
    class AdBannerRenderer : ViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                BannerView bannerView = null;

                switch ((Element as AdBanner).Size)
                {
                    case AdBanner.Sizes.Standardbanner:
                        bannerView = new BannerView(AdSizeCons.Banner, new CGPoint(0, 0));
                        break;
                    case AdBanner.Sizes.LargeBanner:
                        bannerView = new BannerView(AdSizeCons.LargeBanner, new CGPoint(0, 0));
                        break;
                    case AdBanner.Sizes.MediumRectangle:
                        bannerView = new BannerView(AdSizeCons.MediumRectangle, new CGPoint(0, 0));
                        break;
                    case AdBanner.Sizes.FullBanner:
                        bannerView = new BannerView(AdSizeCons.FullBanner, new CGPoint(0, 0));
                        break;
                    case AdBanner.Sizes.Leaderboard:
                        bannerView = new BannerView(AdSizeCons.Leaderboard, new CGPoint(0, 0));
                        break;
                    case AdBanner.Sizes.SmartBannerPortrait:
                        bannerView = new BannerView(AdSizeCons.SmartBannerPortrait, new CGPoint(0, 0));
                        break;
                    default:
                        bannerView = new BannerView(AdSizeCons.Banner, new CGPoint(0, 0));
                        break;
                }

                bannerView.AdUnitId = "ca-app-pub-4681470946279796/3043892478";

                foreach (UIWindow uiWindow in UIApplication.SharedApplication.Windows)
                {
                    if (uiWindow.RootViewController != null)
                    {
                        bannerView.RootViewController = uiWindow.RootViewController;
                    }
                }
                var request = Request.GetDefaultRequest();
                bannerView.LoadRequest(request);
                SetNativeControl(bannerView);
            }

        }

    }
}