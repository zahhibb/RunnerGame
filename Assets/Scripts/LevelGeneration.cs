using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject chunk;


    //Chunk prefabs
    public GameObject[] chunkPrefabs;
    //Chunks that have been spawned
    List<GameObject> placedChunks = new List<GameObject>();

    public int spawnDistance = 0;
    public float maxTimer = 0;
    public int maxChunkCount = 0;

    float currenTimer = 0;
    int chunkCounter = 0;

    void Start()
    {
        SpawnBlock();
    }

    void Update()
    {
        if(currenTimer < maxTimer)
        {
            currenTimer += Time.deltaTime;
        }
        else
        {
            SpawnBlock();
            currenTimer = 0;
        }
    }

    public void SpawnBlock()
    {
        int nextChunkDistance = chunkCounter * spawnDistance;

        //Chose a random chunk here
         
        placedChunks.Add(Instantiate(chunkPrefabs[ChoseRandomChunk()], Vector3.forward * nextChunkDistance, Quaternion.identity));
        if (placedChunks.Count > 6)
        {
            placedChunks[0].GetComponent<ChunkScript>().DestroyObstacles();
            Destroy(placedChunks[0]);
            placedChunks.RemoveAt(0);
        }
        chunkCounter++;
    }

    public int ChoseRandomChunk()
    {
        int chunkNumber = Random.Range(0, chunkPrefabs.Length);
        return chunkNumber;
    }

}
