using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region ScriptRefs

    GameManager gameManager;

    #endregion

    public GameObject[] lifeArray;

    public TextMeshProUGUI pirogCount;
    public TextMeshProUGUI scoreCount;
    public TextMeshProUGUI scoreMultiplier;


    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    public void UpdateLifes()
    {

        for (int i = 0; i < lifeArray.Length; i++)
        {
            lifeArray[i].SetActive(false);
        }

        for (int i = 0; i < gameManager.GetPlayerLives(); i++)
        {
            lifeArray[i].SetActive(true);
        }
    }

    public void UpdatePirogCount()
    {
        pirogCount.text = gameManager.GetTotalPirogis().ToString();
    }

    public void UpdateScoreCount()
    {
        scoreCount.text = gameManager.GetTotalScore().ToString();
    }

    public void UpdatePirogMultiplier()
    {
        scoreMultiplier.text = "x" + gameManager.GetTotalPirogMultiplier().ToString();
    }

}