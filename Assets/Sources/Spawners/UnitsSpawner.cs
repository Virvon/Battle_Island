using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class UnitsSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private EnemyView _enemyPrefab;
    [SerializeField] private PlayerView _playerPrefab;
    [SerializeField] private WeaponsSpawner _weaponSpawner;
    [SerializeField] private JoystickHandler _joystickHandler;
    [SerializeField] private CameraView _camera;
    [SerializeField] private GameObject[] _skins;

    private List<MovementObject> _targets;

    public List<MovementObject> Targets => _targets;

    public event Action<MovementObject[]> CreationEnded;

    private void Start()
    {
        _targets = new List<MovementObject>();
        CreateEnemys(_spawnPoints);
    }

    public void DisableEnemies()
    {
        foreach (var target in _targets)
            target.enabled = false;
    }

    private void CreateEnemys(Transform[] spawnPoints)
    {
        List<EnemyView> enemies = new List<EnemyView>();
        int playerSpawnPoint = UnityEngine.Random.Range(0, spawnPoints.Length - 1);

        for (var i = 0; i < spawnPoints.Length; i++)
        {
            MovementObject character;

            if (i != playerSpawnPoint)
            {
                EnemyView enemy = Instantiate(_enemyPrefab, spawnPoints[i].position, Quaternion.identity, transform);
                enemies.Add(enemy);
                character = enemy;
            }
            else
            {
                PlayerView player = Instantiate(_playerPrefab, spawnPoints[i].position, Quaternion.identity, transform);

                Instantiate(Store.SelectSkin, player.transform.position + new Vector3(0, -1, 0), player.transform.rotation, player.transform);
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

    private void InitEnemys(List<EnemyView> enemies)
    {
        for(var i = 0; i < enemies.Count; i++)
        {
            MovementObject[] targets = _targets.Where(target => target != enemies[i]).ToArray();

            enemies[i].Init(targets, _skins[UnityEngine.Random.Range(0, _skins.Length)], 10);
        }
    }

    private void InitPlayer(PlayerView player)
    {
        player.Init(_joystickHandler);
    }
}
