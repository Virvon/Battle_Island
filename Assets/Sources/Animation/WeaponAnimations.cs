using UnityEngine;

namespace BattleIsland.Animation
{
    [RequireComponent(typeof(Animator))]
    public class WeaponAnimations : MonoBehaviour
    {
        private Animator _animator;

        private void Awake() =>
            _animator = GetComponent<Animator>();

        public void Shoot() =>
            _animator.SetBool(AnimationPath.Weapon.IsIdle, false);

        public void ComeBack() =>
            _animator.SetBool(AnimationPath.Weapon.IsIdle, true);
    }
}