using UnityEngine;

namespace BattleIsland.GameLogic.Store
{
    public class SkinItem : Item
    {
        [SerializeField] private GameObject _skinPrefab;
        [SerializeField] Skin _skin;

        public GameObject Skin => _skinPrefab;

        private void OnEnable() => Deactivate();

        public override void Activate(Vector3 position)
        {
            _skin.gameObject.SetActive(true);
            _skin.transform.position = position;
        }

        public override void Deactivate()
        {
            _skin.gameObject.SetActive(false);
        }
    }
}