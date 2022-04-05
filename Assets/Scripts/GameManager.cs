using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int PlayerLives = 3;
    private float GameTimer = 0;
    private float GameTimerGoal = 30;

    private int totalScore = 0;
    private int pirogiValue = 10;
    private int currentPirogis = 0;
    private int pirogiPickup = 1; // let us talk about how much pirogis you should get from crashing into pirogiwagon


    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
    }

    // Method to keep track of pirogis in possession
    public void IncreasePirogi()
    {
        currentPirogis += pirogiPickup;
    }
    public int GetTotalPirogis()
    {
        return currentPirogis;
    }
    
    //Method to decrease pirogi amount on delivery/sale
    public void DecreasePirogi()
    {
        if (currentPirogis <=0)
            return;

        currentPirogis--;
    }

    // Method to increase score counter from pirogi delivery
    public void ScoreIncrease()
    {
        totalScore += pirogiValue;
    }
    public int GetTotalScore()
    {
        return totalScore;
    }

    // Update is called once per frame
    void Update()
    {   
        //test for decreasing pirogi value
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            DecreasePirogi();
            Debug.Log(GetTotalPirogis());
        }

        //test for picking up pirogis
        // if (Input.GetKeyDown(KeyCode.LeftControl))
        // {
        //    AddPirogi();
        //     Debug.Log(GetTotalPirogis());
        // }

        // test for score counter
        // if (Input.GetKeyDown(KeyCode.AltGr))
        // {
        //     ScoreIncrease();
        //     Debug.Log(GetTotalScore());
        // }

        if (PlayerLives <= 0) //Lose State
        {
            //Show Debrief Menu for Losing
            //Stop Level Generation
            //Prevent Respawn
            //Pause Game?
        }

        if (GameTimer >= GameTimerGoal)
        {
            //Show Debrief Menu for Winning
            //Stop Level Generation
            //Prevent Respawn
            //Pause Game?
        }
        else
        {
            GameTimer = GameTimer + Time.deltaTime;
            //Debug.Log(GameTimer);
        }
    }

    public void TakeDamage()
    {
        PlayerLives -= 1;
    }

    public int GetPlayerLives() // UI Manager will see this
    {
        return PlayerLives;
    }
}