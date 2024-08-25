using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtributeLearner : MonoBehaviour
{
    [Header("Настройки сервера")]
    [SerializeField, Range(1, 100)] float _playersMaxCount;
    [SerializeField, Multiline(2)] string _playerGreeting;
    [SerializeField, Multiline(1)] string _playerName;
    [Space(10)]
    [Tooltip("Определяет в каком интервале автоматически сохраняется сервер")]
    [SerializeField, Range(1, 24)] int _saveIntervalInHours;

    [Header("Поля")]
    [SerializeField] GameObject _enemyPrefab;

    private List<Transform> _spawnPoints = new List<Transform>();

    [ContextMenu(nameof(Spawn))]
    private void Spawn()
    {
        foreach (Transform spawnPoint in _spawnPoints)
        {
            Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    [ContextMenu(nameof(FindSpawnPoints))]
    private void FindSpawnPoints()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");

        foreach (GameObject spawnPoint in spawnPoints)
        {
            _spawnPoints.Add(spawnPoint.transform);
        }
    }
}
