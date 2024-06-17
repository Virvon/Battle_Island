using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Advertisement
{
    [RequireComponent(typeof(Button))]
    public class AdButton : MonoBehaviour
    {
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();

            _button.interactable = true;
        }

        public void ShowAd()
        {
            Advertisement.ShowVideoAd();

            _button.interactable = false;
        }
    }
}