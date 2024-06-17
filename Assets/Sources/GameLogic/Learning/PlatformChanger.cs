using Assets.Sources.Infrastructure.Bootstrap;
using UnityEngine;

namespace Assets.Sources.GameLogic.Learning
{
    public class PlatformChanger : MonoBehaviour
    {
        [SerializeField] private GameObject _mobileLearning;
        [SerializeField] private GameObject _desktopLearning;

        private void Awake()
        {
            GameObject destroyLearning = GameInit.Platform == Platform.Desktop ? _mobileLearning : _desktopLearning;

            Destroy(destroyLearning);
        }
    }
}