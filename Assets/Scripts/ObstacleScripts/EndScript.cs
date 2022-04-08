using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
    SoundManager soundManager;
    GameManager gameManager;
    public GameObject endScreen;
    Canvas canvas;

    private void Awake()
    {
        canvas = GameObject.Find("GameplayUI").GetComponent<Canvas>();
        soundManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SoundManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        //endScreen.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SepareteRestart starAccess = Instantiate(endScreen.GetComponent<SepareteRestart>(), canvas.transform);

            starAccess.ActivateStars(1 + gameManager.GetStarAmount(), gameManager.GetTotalScore(), gameManager.GetDeliveriedPirogi());
            soundManager.PlayWinSound();
            other.GetComponent<PlayerController>().StopPlayer();
        }
    }
}
