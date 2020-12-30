using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject snowballPrefab;
    public float minDelay, maxDelay;
    public float minX, maxX, minY, maxY;
    // private Transform[] points;
    private float spawnDelay;


    void Start(){
        // points = gameObject.GetComponentsInChildren<Transform>();
        spawnDelay = Random.Range(minDelay, maxDelay);
    }

    void Update(){

        spawnDelay -= Time.deltaTime * GameManager.instance.animalCount;
        if(spawnDelay <= 0f){
            SpawnSnowball();
            spawnDelay = Random.Range(minDelay, maxDelay);
        }
    }

    void SpawnSnowball(){

        // int index = Random.Range(0, points.Length);
        // Vector2 pos = (Vector2)points[index].position;

        Vector2 pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        GameObject snowballGO = Instantiate(snowballPrefab, pos, Quaternion.identity);
        snowballGO.transform.parent = this.transform;
    }
}
