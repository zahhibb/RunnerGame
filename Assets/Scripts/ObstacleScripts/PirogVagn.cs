using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirogVagn : MonoBehaviour
{


    public int scoreAmount = 0;
    public int piroger = 0;



    void Start()
    {
        
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

        Destroy(gameObject);
    }

    public void IncreaseMoney()
    {


    }

    public void IncreasePiroger()
    {

        piroger++;

    }
}
