using System;
using Agava.YandexGames;
using GameAnalyticsSDK;

namespace CodeBase.Infrastructure.Services.AdServices
{
    public class AdsYandexServices : IAdsGameAnalytics
    {
        private const string _defaultValue = "0";
        private const string _clicker = "Clicker";
        
        public void ShowAds(Action callbackOnOpen, Action<bool> onClose)
        {
            InterstitialAd.Show(callbackOnOpen, onClose);
        }

        public void ShowRewardedAds(Action callbackOnOpen, Action onRewarded, Action onClose)
        {
            VideoAd.Show(callbackOnOpen, onRewarded, onClose);
        }

        public void GameAnalytic()
        {
            GameAnalytics.GetRemoteConfigsValueAsString(_clicker, _defaultValue);   
        }
    }

    public interface IAdsServices
    {
        void ShowAds(Action callbackOnOpen, Action<bool> onClose);
        void ShowRewardedAds(Action callbackOnOpen, Action onRewarded, Action onClose);
    }

    public interface IAdsGameAnalytics : IAdsServices
    {
        void GameAnalytic();
    }
}