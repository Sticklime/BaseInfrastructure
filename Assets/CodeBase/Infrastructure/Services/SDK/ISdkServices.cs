using System.Threading.Tasks;
using Agava.YandexGames;
using System;
using System.ComponentModel;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.SDK
{
    public interface ISdkServices : IService
    {
        UniTask InitSDK();
  
    }

    public interface ISdkGameReadyServices : ISdkServices
    {
        public void CallGameReady();
    }

    public interface IRawData
    {
        UniTask Save(string jsonData);
        UniTask<string> FetchData();
    }

    public class YandexSdk : ISdkGameReadyServices, IRawData
    {
        public async UniTask InitSDK() => 
            await YandexGamesSdk.Initialize().ToUniTask();
        
        public async UniTask Save(string jsonData)
        {
            bool isLoaded = false;

            PlayerAccount.SetCloudSaveData(jsonData, () => isLoaded = true);

            await UniTask.WaitUntil(() => isLoaded);
        }

        public async UniTask<string> FetchData()
        {
            bool isLoaded = false;
            string jsonData = "";

            PlayerAccount.GetCloudSaveData(awaitData =>
            {
                isLoaded = true;
                jsonData = awaitData;
            });

            await UniTask.WaitUntil(() => isLoaded);

            return jsonData;
        }

        public void CallGameReady() =>
            YandexGamesSdk.GameReady();
    }
}