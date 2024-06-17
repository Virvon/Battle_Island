using System;
using Agava.YandexGames;

namespace Assets.Sources.Advertisement
{
    public static class Advertisement
    {
        public static event Action<bool> QuickAdClosed;
        public static event Action<string> QuickAdErrored;
        public static event Action Rewarded;
        public static event Action VideoAdClosed;
        public static event Action AdOpened;

        public static void ShowQuickAd() =>
            InterstitialAd.Show(onOpenCallback: AdOpened, onCloseCallback: QuickAdClosed, onErrorCallback: QuickAdErrored);

        public static void ShowVideoAd() =>
            VideoAd.Show(onOpenCallback: AdOpened, onRewardedCallback: Rewarded, onCloseCallback: VideoAdClosed);
    }
}