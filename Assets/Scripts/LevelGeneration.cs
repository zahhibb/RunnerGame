using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject chunk;

    public List<GameObject> chunks = new List<GameObject>();

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

        chunks.Add(Instantiate(chunk, Vector3.forward * nextChunkDistance, Quaternion.identity));
        if (chunks.Count > 6)
        {
            Destroy(chunks[0]);
            chunks.RemoveAt(0);
        }
        chunkCounter++;
    }

    public void ChoseRandomChunk()
    {

    }
}
