using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
    public GameObject endScreen;
    Canvas canvas;

    private void Awake()
    {
        canvas = GameObject.Find("GameplayUI").GetComponent<Canvas>();
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
            Instantiate(endScreen, canvas.transform);
            
        }
    }
}
