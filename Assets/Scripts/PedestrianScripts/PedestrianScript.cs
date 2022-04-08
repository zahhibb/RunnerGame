using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianScript : MonoBehaviour
{

    public float speed = 2;

    CharacterController characterController;


    void Start()
    {
        characterController = gameObject.AddComponent<CharacterController>();
        characterController.center = new Vector3(0, 1, 0);
    }

    
    void Update()
    {

        characterController.Move(transform.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            CrashOrSomething();
        }
    }

    public void CrashOrSomething()
    {
        print("Crashed");
    }

}
