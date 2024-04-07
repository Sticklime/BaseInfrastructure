using CodeBase.Infrastructure.Services.AdServices;
using UnityEngine;

namespace CodeBase.TestSDK.Button
{
    public class ShowAdButton : MonoBehaviour
    {
        private IAdsServices _adsServices;

        public void Construct(IAdsServices adsServices)
        {
            _adsServices = adsServices;
        }

        public void ShowAd()
        {
            _adsServices.ShowAds(OnOpen, OnClose);
        }

        public void ShowAdReward()
        {
            _adsServices.ShowRewardedAds(OnOpen, Reward, OnClose);
        }

        private void Reward() { }

        private void OnOpen() { }

        private void OnClose() { }

        private void OnClose(bool isClose) { }
    }
}