using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGallery : MonoBehaviour
{
    private string newSceneName = "Gallery";

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
                LoadScene();
            }
        }
    }
    private void LoadScene()
    {
        if (!string.IsNullOrEmpty(newSceneName))
        {
            DestroyPuzzlePieces();
            if (SystemInfo.supportsVibration)
            {
                Handheld.Vibrate();
            }
            SceneManager.LoadScene(newSceneName);

            isGazing = false;
        }
    }
    private void DestroyPuzzlePieces()
    {
        PuzzlePiece[] puzzlePieces = GameObject.FindObjectsOfType<PuzzlePiece>();
        foreach (PuzzlePiece puzzlePiece in puzzlePieces)
        {
            Destroy(puzzlePiece.gameObject);
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
