using System.Collections;
using UnityEngine;

namespace FlappyRunner.Enemies
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _obstaclePrefab = null;
        [SerializeField] private Transform[] _spawnPoints = null;
        [SerializeField] private float _startSpawnTime = 1;
        [SerializeField] private float _minSpawnTime = 0.65f;
        [SerializeField] private float _decreaseTime = 0.05f;

        private float _spawnTime = 1;
        private int _lastPoint = default;

        private void Update()
        {
            if(_spawnTime <= 0)
            {
                for(int i = 0; i < 2; i++)
                {
                    int point = GetRandomPoint();
                    Instantiate(_obstaclePrefab, _spawnPoints[point].position, Quaternion.identity);
                }

                _spawnTime = _startSpawnTime;

                if(_startSpawnTime > _minSpawnTime) _startSpawnTime -= _decreaseTime;
            }
            else _spawnTime -= Time.deltaTime;            
        }

        private int GetRandomPoint()
        {
            int num = _lastPoint;

            while(num == _lastPoint)
            {
                num = Random.Range(0, _spawnPoints.Length);
            }
            _lastPoint = num;

            return num;
        }
    }
}