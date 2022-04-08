using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class SepareteRestart : MonoBehaviour
{
    public GameObject[] goldStars;


    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI pirogiText;

    void Start()
    {
        //if(goldStars.Length > 0)
        //{
        //    for (int i = 0; i < goldStars.Length; i++)
        //    {
        //        goldStars[i].SetActive(false);
        //    }
        //}
        
    }

    void Update()
    {
        
    }

    public void ActivateStars(int starAmount, int scoreAmount, int pirogAmount)
    {
        SetEndScore(scoreAmount);
        SetEndPirogi(pirogAmount);
        for (int i = 0; i < starAmount; i++)
        {
            print("Helllooooooooo");
            goldStars[i].SetActive(true);
        }
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SetEndScore(int incomingScore)
    {
        scoreText.text = incomingScore.ToString();
    }

    public void SetEndPirogi(int incomingPirog)
    {
        pirogiText.text = incomingPirog.ToString();
    }
}
