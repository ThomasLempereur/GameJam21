using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject enemySpawn;
    [SerializeField] GameObject player;
    [SerializeField] float delay;

    private bool start;

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {
            StartCoroutine(SpawnEnemy());
            start = true;
        }
    }
    public IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject enemy = Instantiate(enemySpawn, transform.position, transform.rotation);
            if (player != null)
            {
                enemy.GetComponentInChildren<EnemyWithoutWayPoint>().SetTraget(player);
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
