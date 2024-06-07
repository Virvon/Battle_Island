using System.Collections;
using UnityEngine;

public class FXDestoy : MonoBehaviour
{
    [SerializeField] private float _delay = 3f;

    private void Start()
    {
        StartCoroutine(Destroyer());
    }

    private IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(_delay);

        Destroy(gameObject);
    }
}
