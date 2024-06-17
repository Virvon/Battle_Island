using UnityEngine;

namespace Assets.Sources.GameLogic.Store
{
    public class StoresOpener : MonoBehaviour
    {
        [SerializeField] private Store[] _stores;
        [SerializeField] private Store _openOnStart;

        private Store _currentStore;

        private void Start() => Open(_openOnStart);

        public void Open(Store targetStore)
        {
            if (targetStore == _currentStore)
                return;

            if (_currentStore != null)
                _currentStore.Close();

            _currentStore = targetStore;

            _currentStore.Open();
        }
    }
}