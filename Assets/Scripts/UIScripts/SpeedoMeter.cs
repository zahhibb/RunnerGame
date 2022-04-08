using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedoMeter : MonoBehaviour
{
    bool goingUp = false;

    float rotationX = 0;

    float currentTimer = 0;
    float maxTimer = 0;

    void Start()
    {
        

    }

    void Update()
    {

        if(currentTimer < maxTimer)
        {
            currentTimer += Time.deltaTime;
        }
        else
        {
            maxTimer = Random.Range(1, 4);
            goingUp = !goingUp;
            currentTimer = 0;
        }

        float tickSpeed = Random.Range(1, 200);
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
        ClampValue();
    }

    public void ClampValue()
    {
        //transform.eulerAngles.y = Mathf.Clamp(transform.eulerAngles.y, -90, 90);
        //transform.eulerAngles.z = Mathf.Clamp(transform.eulerAngles.z, 170, -80);
        rotationX = Mathf.Clamp(transform.eulerAngles.z, 0, 150F);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, rotationX);
    }
}
