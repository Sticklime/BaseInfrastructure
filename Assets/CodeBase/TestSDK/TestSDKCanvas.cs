using System.Collections.Generic;
using System.Linq;
using CodeBase.Infrastructure.Services.AdServices;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.TestSDK.Button;
using UnityEngine;

namespace CodeBase.TestSDK
{
    public class TestSDKCanvas : MonoBehaviour
    {
        [SerializeField] private List<SaveButton> _saveButtons;
        [SerializeField] private List<ShowAdButton> _adButtons;

        public void Construct(ISaveLoadService saveLoadService, SaveLimit saveLimit, IAdsServices adsServices)
        {
            foreach (SaveButton saveButton in _saveButtons)
                saveButton.Construct(saveLoadService, saveLimit);

            foreach (ShowAdButton showAdButton in _adButtons)
                showAdButton.Construct(adsServices);
        }

        public void OnValidate()
        {
            _saveButtons = GetComponentsInChildren<SaveButton>().ToList();
            _adButtons = GetComponentsInChildren<ShowAdButton>().ToList();
        }
    }
}