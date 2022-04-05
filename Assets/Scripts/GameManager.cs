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

    //test
    public int score;
    public int displayScore;
    public Text scoreUI;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        score = 0;
        displayScore = 0;
        StartCoroutine(ScoreUpdater());
    }
    private IEnumerator ScoreUpdater()
    {
        while (true)
        {
            if (displayScore < score)
            {
                displayScore++; //Increment the display score by 1
                scoreUI.text = displayScore.ToString(); //write it to the UI
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
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
            Debug.Log(GameTimer);
        }
    }

    public void TakeDamage()
    {
        PlayerLives = -1;
    }

    public int GetPlayerLives() // UI Manager will see this
    {
        return PlayerLives;
    }
}