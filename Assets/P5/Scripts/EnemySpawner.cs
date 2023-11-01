using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<GameObject> enemies;
    public Transform playerPosition;
    public GameObject enemyPrefab;
    private float spawnCD;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        foreach(Transform t in spawnPoints)
        {
            float distance = Vector3.Distance(t.position, playerPosition.position);
            //Debug.Log(distance);
            if (distance < 20 && enemies.Count < 10 && spawnCD < Time.time)
            {
                enemies.Add(Instantiate(enemyPrefab, t.position, Quaternion.identity));
                spawnCD = Time.time + 5.0f;
            }
        }
    }

    public void EnemiesRemove(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}
