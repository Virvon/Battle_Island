using BattleIsland.GameLogic.Store;
using BattleIsland.Infrastructure.Bootstrap;
using BattleIsland.Infrastructure.View;
using BattleIsland.Input;
using UnityEngine;

namespace BattleIsland.GameLogic.Spawner
{
    public class LearningPlayerSpawner : MonoBehaviour
    {
        private const float SkinYPositionOffset = -1;

        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private PlayerView _playerPrefab;
        [SerializeField] private WeaponsSpawner _weaponSpawner;
        [SerializeField] private JoystickHandler _joystickHandler;
        [SerializeField] private DesktopInput _desktopInput;
        [SerializeField] private CameraView _camera;

        private DirectionInput DirectionInput => GameInit.Platform == Platform.Mobile ?
            _joystickHandler : _desktopInput;

        private void Start()
        {
            PlayerView player = InstantiatePlayer();
            InsantiateSkin(player);
            InitPlayer(player);
            _camera.Init(player);
            _weaponSpawner.CreateWeapon(player);
        }

        private PlayerView InstantiatePlayer()
        {
            return Instantiate(
                _playerPrefab,
                _spawnPoint.position,
                Quaternion.identity,
                transform);
        }

        private void InsantiateSkin(PlayerView player)
        {
            Instantiate(
                SkinStore.SelectSkin,
                player.transform.position + new Vector3(0, SkinYPositionOffset, 0),
                player.transform.rotation, player.transform);
        }

        private void InitPlayer(PlayerView player)
        {
            DirectionInput.gameObject.SetActive(true);
            DirectionInput.Init(player);
            player.Init(DirectionInput);
        }
    }
}