using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject colliderPrefab;
     private int collidersToSpawn = 20;
     private float spawnLimitXLeft = (float)25.5;
    private float spawnLimitXRight = 41;
    private float spawnLimitZLeft =(float) 38.5;
    private float spawnLimitZRight = 28;
    private float spawnPosY = 1;
     void Start()
    {
        SpawnObstacles();
    }
     void SpawnObstacles ()
     {
         for (int i = 0; i < collidersToSpawn; i++)
         {
             Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY,
                 Random.Range(spawnLimitZRight, spawnLimitZLeft));
             Instantiate(colliderPrefab, spawnPos, colliderPrefab.transform.rotation);
         }
     }
    

}
