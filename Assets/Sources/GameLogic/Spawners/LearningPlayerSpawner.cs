using BattleIsland.GameLogic.Store;
using BattleIsland.Infrastructure;
using BattleIsland.Infrastructure.View;
using BattleIsland.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleIsland.GameLogic
{
    public class LearningPlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private PlayerView _playerPrefab;
        [SerializeField] private WeaponsSpawner _weaponSpawner;
        [SerializeField] private JoystickHandler _joystickHandler;
        [SerializeField] private DesktopInput _desktopInput;
        [SerializeField] private CameraView _camera;

        private void Start()
        {
            PlayerView player = Instantiate(_playerPrefab, _spawnPoint.position, Quaternion.identity, transform);
            Instantiate(SkinStore.SelectSkin, player.transform.position + new Vector3(0, -1, 0), player.transform.rotation, player.transform);
            InitPlayer(player);
            _camera.Init(player);
            _weaponSpawner.CreateWeapon(player);
        }

        private void InitPlayer(PlayerView player)
        {
            DirectionInput directionInput = GameInit.Platform == Platform.Mobile ? _joystickHandler : _desktopInput;

            directionInput.gameObject.SetActive(true);
            directionInput.Init(player);
            player.Init(directionInput);
        }
    }
}