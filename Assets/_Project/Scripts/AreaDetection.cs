using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDetection : MonoBehaviour
{

    [SerializeField] private Transform[] spawnPointSkeleton;
    [SerializeField] private Transform[] spawnPointGoblin;
    [SerializeField] private List<GameObject> enemiesSpawn;
    [SerializeField] private PlayerDeathCountArea playerDeathCountArea;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Spawner());
    }

    public IEnumerator Spawner()
    {
        foreach (GameObject enemySpawn in enemiesSpawn)
        {
            yield return new WaitForSeconds(3);
            if (enemySpawn.transform.name == "SkeletonArea Variant")
            {
                for (int i = 0; i < spawnPointSkeleton.Length; i++)
                {
                    GameObject enemy = Instantiate<GameObject>(enemySpawn, spawnPointSkeleton[i].position, spawnPointSkeleton[i].rotation);
                    Vector3 pos = enemy.transform.localPosition;
                    pos.z = 0;
                    enemy.transform.localPosition = pos;
                    enemy.GetComponentInChildren<EnemyWithWayPoint>().SetWayPoints(spawnPointSkeleton);
                    enemy.GetComponentInChildren<EnemyArea>().SetPlayerDeathCountArea(playerDeathCountArea);
                }
            }
            else
            {
                for (int i = 0; i < spawnPointGoblin.Length; i++)
                {
                    GameObject enemy = Instantiate<GameObject>(enemySpawn, spawnPointGoblin[i].position, spawnPointGoblin[i].rotation);
                    Vector3 pos = enemy.transform.localPosition;
                    pos.z = 0;
                    enemy.transform.localPosition = pos;
                    enemy.GetComponentInChildren<EnemyWithWayPoint>().SetWayPoints(spawnPointGoblin);
                    enemy.GetComponentInChildren<EnemyArea>().SetPlayerDeathCountArea(playerDeathCountArea);
                }
            }
        }
    }
}
