using UnityEngine;

public class WeaponAnimationsController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Shoot()
    {
        _animator.SetBool("IsIdle", false);
    }

    public void ComeBack()
    {
        _animator.SetBool("IsIdle", true);
    }
}
