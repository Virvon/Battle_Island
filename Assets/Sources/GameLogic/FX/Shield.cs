using System.Collections;
using UnityEngine;

namespace BattleIsland.GameLogic.FX
{
    public class Shield : MonoBehaviour
    {
        [SerializeField] private float _shieldTime;
        [SerializeField] private GameObject _shieldFX;

        private Coroutine _coroutine;

        public bool IsActive { get; private set; }

        public void Activate()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(ShieldCreater(_shieldTime));
        }

        private IEnumerator ShieldCreater(float delay)
        {
            var shield = Instantiate(_shieldFX, transform.position, Quaternion.identity, transform);
            IsActive = true;

            yield return new WaitForSeconds(delay);

            Destroy(shield);
            IsActive = false;
        }
    }
}