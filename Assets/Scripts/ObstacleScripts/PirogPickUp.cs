using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirogPickUp : MonoBehaviour
{
    GameManager gameManager;
    UIManager uiManager;
    SoundManager soundManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        uiManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIManager>();
        soundManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SoundManager>();
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            OnPickUp();
    }

    public void OnPickUp()
    {
        soundManager.PirogPickSound();
        gameManager.IncreasePirogi();
        uiManager.UpdatePirogCount();
        gameManager.IncreaseMultiplier();
        uiManager.UpdatePirogMultiplier();
        Destroy(gameObject);
    }

}
