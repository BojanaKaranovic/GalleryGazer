using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMusic : MonoBehaviour
{
    private bool isGazing = false;

    private static float MAX_TIME = 1f;
    private float gazeDetectionTime = MAX_TIME;
    
    private void Update()
    {
        if (isGazing)
        {
            gazeDetectionTime -= Time.deltaTime;

            if (gazeDetectionTime <= 0)
            {
                Change();
                isGazing= false;
            }
        }
    }

    private void Change()
    {
        AudioManager.instance.ChangeSong();
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
