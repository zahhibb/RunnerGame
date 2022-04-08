using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedoMeter : MonoBehaviour
{
    bool goingUp = false;

    float currentTimer = 0;
    float maxTimer = 0;

    void Start()
    {
        maxTimer = Random.Range(1, 4);

    }

    void Update()
    {

        if(currentTimer < maxTimer)
        {
            currentTimer += Time.deltaTime;
        }
        else
        {
            goingUp = !goingUp;
            currentTimer = 0;
        }

        float tickSpeed = Random.Range(10, 100);
        float xAxis = Input.GetAxis("Horizontal");
        if (goingUp)
        {
            //Mathf.Abs(xAxis);
            xAxis -= maxTimer;
        }
        else
        {
            xAxis += maxTimer;

        }

        transform.Rotate(Vector3.forward * tickSpeed * xAxis * Time.deltaTime, Space.Self);
    }
}
