using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirogVagn : MonoBehaviour
{
    GameManager gameManager;
    UIManager uiManager;
    SoundManager soundManager;
    Canvas canvas;

    public int scoreAmount = 0;
    public int piroger = 0;

    public GameObject pointsObj;


    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        uiManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIManager>();
        soundManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SoundManager>();
        canvas = GameObject.Find("GameplayUI").GetComponent<Canvas>();
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

            GameObject tempObj = Instantiate(pointsObj, canvas.transform);
            tempObj.GetComponent<PointPrefab>().SetPoints(gameManager.GetTotalPoints());

            gameManager.DeliveredPirogi(gameManager.GetCurrentPirogis());

            soundManager.PirogVagnSound();
            gameManager.ScoreIncrease();
            gameManager.DecreasePirogi();
            uiManager.UpdatePirogCount();
            uiManager.UpdateScoreCount();
        }

        Destroy(gameObject);
    }
}
