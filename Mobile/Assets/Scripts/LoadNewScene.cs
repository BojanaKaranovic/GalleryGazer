using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    private string newSceneName = "Puzzle";

    private bool isGazing = false;
    private Camera mainCamera;


    private static float MAX_TIME = 2f;
    private float gazeDetectionTime = MAX_TIME;

    private void Start()
    {
        mainCamera = Camera.main;
    }
    private void Update()
    {
        if (isGazing)
        {
            gazeDetectionTime -= Time.deltaTime;

            if (gazeDetectionTime <= 0)
            {
                RaycastHit hit;

                if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit))
                {
                    var targetObject = hit.transform.gameObject;
                    var targetMaterial = targetObject.GetComponent<Renderer>().material;

                    Texture2D targetTexture = targetMaterial.mainTexture as Texture2D;

                    GalleryImageSelection.Instance.selectedImage = targetTexture;
                    GalleryImageSelection.Instance.materialName= targetMaterial.name.Split(" ")[0];
                    Debug.Log(GalleryImageSelection.Instance.materialName);
                    
                    LoadScene();
                }
            }
            
        }
    }

    private void LoadScene()
    {
        if (!string.IsNullOrEmpty(newSceneName))
        {
            
            if (SystemInfo.supportsVibration)
            {
                Handheld.Vibrate();
            }
            SceneManager.LoadScene(newSceneName);

            isGazing = false;
        }
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
