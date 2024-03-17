using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{
    private bool isGazing = false;

    private static float MAX_TIME = 1f;
    private float gazeDetectionTime = MAX_TIME;
    [SerializeField] private Light pointLight;

    private int colorIndex = 0;
    private Color[] colors = { Color.white, Color.red, Color.yellow, Color.blue };

    

    private void Update()
    {
        if (isGazing)
        {
            gazeDetectionTime -= Time.deltaTime;

            if (gazeDetectionTime <= 0)
            {
                Change();
                isGazing = false;
            }
        }
    }

    private void Change()
    {

        colorIndex = (colorIndex + 1) % colors.Length;
        pointLight.color = colors[colorIndex];
    }

    public void OnPointerEnter()
    {
        isGazing = true;
    }

    public void OnPointerExit()
    {
        isGazing = false;
        gazeDetectionTime = MAX_TIME;
    }
}
