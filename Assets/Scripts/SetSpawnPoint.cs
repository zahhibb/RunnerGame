using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawnPoint : MonoBehaviour
{
    GameManager gameManager;
    LevelGeneration levelGenerator;

    bool triggered = false;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        levelGenerator = GameObject.FindGameObjectWithTag("levelGen").GetComponent<LevelGeneration>();
        
    }

    void Start()
    {
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !triggered)
        {
            triggered = false;
            gameManager.SetSpawnPoint(transform.position);
            levelGenerator.SpawnBlock();
        }
    }
}
