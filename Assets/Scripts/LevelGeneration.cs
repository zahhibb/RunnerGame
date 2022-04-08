using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject chunk;
    public GameObject finalChunk;
    GameManager gameManager;
    

    //Chunk prefabs
    public GameObject[] chunkPrefabs;
    //Chunks that have been spawned
    List<GameObject> placedChunks = new List<GameObject>();

    public float maxTimer = 0;
    public int maxChunkCount = 0;
    int spawnDistance = 50;


    public GameObject[] obstacles;
    public GameObject pirog;
    public GameObject pirogVagn;

    float currenTimer = 0;
    int chunkCounter = 0;

    bool outOfTime = false;
    bool shouldSpawn = true;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
        for (int i = 0; i < 4; i++)
        {
            SpawnBlock();
        }
    }

    void Update()
    {
        //if(currenTimer < maxTimer)
        //{
        //    currenTimer += Time.deltaTime;
        //}
        //else
        //{
        //    SpawnBlock();
        //    currenTimer = 0;
        //}
    }

    public void SpawnBlock()
    {
        if (!shouldSpawn)
            return;
        int nextChunkDistance = chunkCounter * spawnDistance;

        //Chose a random chunk here
        if(gameManager.GetTimer() > 5)
        {
            outOfTime = true;
            placedChunks.Add(Instantiate(finalChunk, Vector3.forward * nextChunkDistance, Quaternion.identity));
            shouldSpawn = false;
        }
        else if(!outOfTime)
            placedChunks.Add(Instantiate(chunkPrefabs[ChoseRandomChunk()], Vector3.forward * nextChunkDistance, Quaternion.identity));

        if (placedChunks.Count > maxChunkCount && !outOfTime)
        {
            placedChunks[0].GetComponentInChildren<ChunkScript>().DestroyObstacles();
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
