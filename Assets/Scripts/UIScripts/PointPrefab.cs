using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointPrefab : MonoBehaviour
{
    public TextMeshProUGUI pointText;
    float timeElapsed;
    float lerpDuration = 3;
    Color32 baseColor;
    float startFade = 100;
    int fadeSpeed = 60;

    void Start()
    {
        baseColor = pointText.color;
        startFade = baseColor.a;
    }

    void Update()
    {
        if (startFade == 0)
        {
            Destroy(gameObject);
        }
        startFade -= Mathf.CeilToInt(fadeSpeed * Time.deltaTime);
        pointText.color = new Color32(baseColor.r, baseColor.g, baseColor.b, (byte)startFade);
        Vector3 endPos = new Vector3(transform.position.x, -500, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, endPos, 0.1f * Time.deltaTime);
    }

    public void SetPoints(int pointAmount)
    {
        pointText.text = "+" + pointAmount.ToString();
    }
}
