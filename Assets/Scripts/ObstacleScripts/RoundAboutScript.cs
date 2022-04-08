using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundAboutScript : MonoBehaviour
{

    public float rotationSpeed;

    void Start()
    {
        
    }

    void Update()
    {

        transform.Rotate(Vector3.up * -50 * Time.deltaTime, Space.Self);

    }


}
