using System.Threading.Tasks;
using Agava.YandexGames;
using System;

namespace CodeBase.Infrastructure.Services.SDK
{
    public interface ISdkServices : IService
    {
        Task InitSDK();
        Task Save();
        Task<string> LoadProgress();
    }

    public interface ISdkGameReadyServices : ISdkServices
    {
        public void CallGameReady();
    }

    public class YandexSdk : ISdkGameReadyServices
    {
        private string _json = "";

        public async Task InitSDK() => 
            await Task.Run(() => YandexGamesSdk.Initialize());

        public async Task Save() => 
            await Task.Run(() => PlayerAccount.SetCloudSaveData(_json));

        public async Task<string> LoadProgress()
        {
            await Task.Run(() =>  PlayerAccount.GetCloudSaveData(GetJson));
            
            return _json;
        }

        public void CallGameReady() => 
            YandexGamesSdk.GameReady();

        private void GetJson(string json) =>
            _json = json;
    }
}