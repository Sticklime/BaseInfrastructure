using System;

namespace CodeBase.Infrastructure.Services.AdServices
{
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