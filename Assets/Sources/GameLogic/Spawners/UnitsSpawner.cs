using System;
using System.Linq;
using System.Collections.Generic;
using BattleIsland.Infrastructure.View;
using BattleIsland.Input;
using BattleIsland.GameLogic.Store;
using BattleIsland.Infrastructure.Bootstrap;
using UnityEngine;

namespace BattleIsland.GameLogic.Spawner
{
    public class UnitsSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Enemy.Enemy _enemyPrefab;
        [SerializeField] private PlayerView _playerPrefab;
        [SerializeField] private WeaponsSpawner _weaponSpawner;
        [SerializeField] private NameSpawner _nameSpawner;
        [SerializeField] private JoystickHandler _joystickHandler;
        [SerializeField] private DesktopInput _desktopInput;
        [SerializeField] private CameraView _camera;
        [SerializeField] private GameObject[] _skins;

        private List<MovementObject> _targets;

        public event Action<MovementObject[]> CreationEnded;

        public IReadOnlyList<MovementObject> Targets => _targets;

        private void Start()
        {
            _targets = new List<MovementObject>();
            CreateEnemys(_spawnPoints);
        }

        public void DisableEnemies()
        {
            foreach (var target in _targets)
                target.gameObject.SetActive(false);
        }

        private void CreateEnemys(Transform[] spawnPoints)
        {
            List<Enemy.Enemy> enemies = new List<Enemy.Enemy>();
            int playerSpawnPoint = UnityEngine.Random.Range(0, spawnPoints.Length);

            for (var i = 0; i < spawnPoints.Length; i++)
            {
                MovementObject character;

                if (i != playerSpawnPoint)
                {
                    Enemy.Enemy enemy = Instantiate(_enemyPrefab, spawnPoints[i].position, Quaternion.identity, transform);
                    enemies.Add(enemy);
                    character = enemy;

                    _nameSpawner.CreateName(character);
                }
                else
                {
                    PlayerView player = Instantiate(_playerPrefab, spawnPoints[i].position, Quaternion.identity, transform);

                    Instantiate(SkinStore.SelectSkin, player.transform.position + new Vector3(0, -1, 0), player.transform.rotation, player.transform);
                    InitPlayer(player);
                    character = player;
                    _camera.Init(player);
                }

                _weaponSpawner.CreateWeapon(character);
                _targets.Add(character);
            }

            InitEnemys(enemies);
            CreationEnded?.Invoke(_targets.ToArray());
        }

        private void InitEnemys(List<Enemy.Enemy> enemies)
        {
            for (var i = 0; i < enemies.Count; i++)
            {
                MovementObject[] targets = _targets.Where(target => target != enemies[i]).ToArray();

                enemies[i].Init(targets, _skins[UnityEngine.Random.Range(0, _skins.Length)], 10);
            }
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