using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirogPickUp : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            OnPickUp();
    }

    public void OnPickUp()
    {
        print("Picked Up");
        Destroy(gameObject);
    }

}
