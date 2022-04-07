using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeTrigger : MonoBehaviour
{
    [Range(0, 1)]
public float Magnitude;

    public ScreenShake screenShake;
   
    // Update is called once per frame
    void Update()
    {
    if (Input.GetMouseButtonDown(0))
    {
       StartCoroutine(screenShake.Shake(.15f, Magnitude));
    }
    }
}
