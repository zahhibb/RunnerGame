using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private SoundManager soundManager;
    public GameObject playerPrefab;
    private int PlayerLives = 3;
    private float GameTimer = 0;
    private float GameTimerGoal = 30;

    private Vector3 spawnPoint;
    private int totalScore = 0;
    private int pirogiValue = 10;
    private int currentPirogis = 0;
    private int pirogMultiplier = 0;
    private int pirogiPickup = 1; // let us talk about how much pirogis you should get from crashing into pirogiwagon
    private bool goalLevelComplete = false;
    private bool goalDeliveredPirogis = false;
    private bool goalNoDamageTaken = false;


    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        soundManager = GetComponent<SoundManager>();
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

        currentPirogis = 0;
    }

    public void IncreaseMultiplier()
    {
        if (currentPirogis != 0)
        {
            pirogMultiplier = (currentPirogis / 10) + 1;
        }
        else
        {
            pirogMultiplier = 1;
        }

    }

    // Method to increase score counter from pirogi delivery
    public void ScoreIncrease()
    {
        //int scoreMulitplier = (10 / currentPirogis) + 1;
        totalScore += (pirogMultiplier * currentPirogis);
    }
    public int GetTotalScore()
    {
        return totalScore;
    }

    public int GetTotalPirogMultiplier()
    {
        return pirogMultiplier;
    }

    public int GetTotalPoints()
    {
        return pirogMultiplier * currentPirogis;
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

        GameTimer = GameTimer + Time.deltaTime;
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

        //if (GameTimer >= GameTimerGoal)
        //{
        //    //Show Debrief Menu for Winning
        //    //Stop Level Generation
        //    //Prevent Respawn
        //    //Pause Game?
        //}
        //else
        //{
        //    GameTimer = GameTimer + Time.deltaTime;
        //    //Debug.Log(GameTimer);
        //}

        if (goalLevelComplete)
        {
            // yield 1 star
        }

        if (goalDeliveredPirogis)
        {
            //yield 1 star
        }

        if (goalNoDamageTaken)
        {
            //yield 1 star
        }
    }

    public void SpawnPlayer()
    {
        //Instantiate(playerPrefab, spawnPoint, Quaternion.identity).GetComponent<PlayerController>().SpawnSafety();
        GameObject pc = Instantiate(playerPrefab, spawnPoint, Quaternion.identity);
        pc.GetComponent<PlayerController>().SpawnSafety();
        soundManager.SetPlayer(pc);
        
    }

    public void SetSpawnPoint(Vector3 spawnPos)
    {
        spawnPoint = spawnPos;
    }

    public void SetGoalLevelComplete()
{
goalLevelComplete = true;
}

public void SetGoalDeliveredPirogis()
{
    goalDeliveredPirogis = true;
}

public void SetGoalNoDamageTaken()
{
    goalNoDamageTaken = true;
}
    public void TakeDamage()
    {
        PlayerLives -= 1;
    }

    public float GetTimer()
    {
        return GameTimer;
    }

    public int GetPlayerLives() // UI Manager will see this
    {
        return PlayerLives;
    }
}