using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryImageSelection : MonoBehaviour
{
    public Texture2D selectedImage;
    public string materialName;

    public static GalleryImageSelection Instance { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
