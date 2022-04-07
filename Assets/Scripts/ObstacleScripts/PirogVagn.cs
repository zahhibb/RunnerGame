using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirogVagn : MonoBehaviour
{
    GameManager gameManager;
    UIManager uiManager;
    SoundManager soundManager;

    public int scoreAmount = 0;
    public int piroger = 0;



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
        {
            HitPirogTruck();
        }
    }

    public void HitPirogTruck()
    {
        //DO everything else before destroying the gameobject
        if(gameManager.GetTotalPirogis() >= 1)
        {
            soundManager.PirogVagnSound();
            gameManager.ScoreIncrease();
            gameManager.DecreasePirogi();
            uiManager.UpdatePirogCount();
            uiManager.UpdateScoreCount();
        }

        Destroy(gameObject);
    }
}
