using System;

namespace AdMobSample
{
    /// <summary>
    /// 전면광고 인테페이스입니다.
    /// </summary>
    public interface IInterstitialAd
    {
        /// <summary>
        /// 광고 표시 이후 이벤트 입니다.
        /// (광고 표시 이후 처리할 내용이 있는 경우 사용합니다.)
        /// </summary>
        event EventHandler AdReceived;

        /// <summary>
        /// 광고를 표시합니다.
        /// </summary>
        void Show();
    }
}
