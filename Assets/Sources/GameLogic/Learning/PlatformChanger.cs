using BattleIsland.Infrastructure;
using UnityEngine;

namespace BattleIsland.GameLogic.Learning
{
    public class PlatformChanger : MonoBehaviour
    {
        [SerializeField] private GameObject _mobileLearning;
        [SerializeField] private GameObject _DesktopLearning;

        private void Awake()
        {
            GameObject destroyLearning = GameInit.Platform == Platform.Desktop ? _mobileLearning : _DesktopLearning;

            Destroy(destroyLearning);
        }
    }
}