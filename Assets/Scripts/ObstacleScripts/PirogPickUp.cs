using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirogPickUp : MonoBehaviour
{
    GameManager gameManager;
    UIManager uiManager;
    SoundManager soundManager;
    ScreenShakeTrigger screenShake;
    Canvas canvas;
    public GameObject pointObj;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        uiManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIManager>();
        soundManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SoundManager>();
        screenShake = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ScreenShakeTrigger>();
        canvas = GameObject.Find("GameplayUI").GetComponent<Canvas>();
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            OnPickUp(other.gameObject);
            other.transform.GetComponent<PickupEffect>().PlayEffect();
        }
    }

    public void OnPickUp(GameObject player)
    {
        Instantiate(pointObj, canvas.transform);
        player.GetComponentInChildren<ScreenShakeTrigger>().PickUpShake();
        soundManager.PirogPickSound();
        gameManager.IncreasePirogi();
        uiManager.UpdatePirogCount();
        gameManager.IncreaseMultiplier();
        uiManager.UpdatePirogMultiplier();
        Destroy(gameObject);
    }

}
