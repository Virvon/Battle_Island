using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private EnemyView _enemyPrefab;
    [SerializeField] private PlayerView _playerPrefab;
    [SerializeField] private WeaponsSpawner _weaponSpawner;
    [SerializeField] private JoystickHandler _joystickHandler;

    private List<MovementObject> _targets;

    private void Start()
    {
        _targets = new List<MovementObject>();
        CreateEnemys(_spawnPoints);
    }

    private void CreateEnemys(Transform[] spawnPoints)
    {
        List<EnemyView> enemies = new List<EnemyView>();
        int playerSpawnPoint = Random.Range(0, spawnPoints.Length - 1);

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
                InitPlayer(player);
                character = player;
            }

            
            _weaponSpawner.CreateWeapon(character);
            _targets.Add(character);
        }

         InitEnemys(enemies);
    }

    private void InitEnemys(List<EnemyView> enemies)
    {
        for(var i = 0; i < enemies.Count; i++)
        {
            MovementObject[] targets = _targets.Where(target => target != enemies[i]).ToArray();

            enemies[i].Init(targets);
        }
    }

    private void InitPlayer(PlayerView player)
    {
        player.Init(_joystickHandler);
    }
}
