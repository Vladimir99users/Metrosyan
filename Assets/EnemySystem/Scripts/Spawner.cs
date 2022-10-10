using UnityEngine;
using System;
public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _drawPosition;
    [SerializeField][Range(0f,100f)] public int _rangeSpawnEnemy = 10;
    [SerializeField] private int _quantityEnemies = 2;
    [SerializeField] private LayerMask _groundMask;

    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_drawPosition.position,_rangeSpawnEnemy);
    }
    private void Start()
    {
        if(_enemy is null) Debug.LogError("Spawner = нет объекта для спауна");
        for(int i = 0; i < _quantityEnemies;i++)
        {
            Vector3 spawnPosition = RandomCirclePositionEnemy();
            spawnPosition.y = YGroundPosition(spawnPosition);
            var enemy = Instantiate(_enemy,spawnPosition,Quaternion.identity) as Enemy;
            enemy.Init(enemy.transform);
        }
    }

    private Vector3 RandomCirclePositionEnemy()
    {
         System.Random _rand = new System.Random();
          
            Vector3 positionSpawn = new Vector3
                (_rand.Next((int)_drawPosition.position.x + 1,_rangeSpawnEnemy + (int)_drawPosition.position.x),
                 transform.position.y,
                _rand.Next((int)_drawPosition.position.z + 1,_rangeSpawnEnemy + (int)_drawPosition.position.z)
                );
        return positionSpawn;
    }

    private float YGroundPosition(Vector3 position)
    {
        Ray ray = new Ray(position,-Vector3.up);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _groundMask))
        {
            var signPosition = hit.point;
            return signPosition.y;
        }
        return 0;
    }

}
