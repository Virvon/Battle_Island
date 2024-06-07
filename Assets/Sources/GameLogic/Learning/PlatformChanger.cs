using BattleIsland.Infrastructure;
using UnityEngine;

namespace BattleIsland.GameLogic.Learning
{
    public class PlatformChanger : MonoBehaviour
    {
        [SerializeField] private GameObject _mobileLerning;
        [SerializeField] private GameObject _DesktopLerning;

        private void Awake()
        {
            if (GameInit.Platform == Platform.Desktop)
                Destroy(_mobileLerning);
            else
                Destroy(_DesktopLerning);
        }
    }
}