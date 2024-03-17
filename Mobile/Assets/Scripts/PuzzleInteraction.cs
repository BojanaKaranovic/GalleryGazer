using UnityEngine;

public class PuzzleInteraction : MonoBehaviour
{
    private static float MAX_TIME = 1f;

    private GameObject playerCamera;
    private float gazeDetectionTime = MAX_TIME;
    private bool isPickedUp = false;

    private void Awake()
    {
        playerCamera = GameObject.FindGameObjectWithTag("Player");
        Input.gyro.enabled = true;
    }

    private void Update()
    {
        if (isPickedUp)
        {
            gazeDetectionTime -= Time.deltaTime;
            if (gazeDetectionTime <= 0)
            {
                
                FollowPlayerView();
            }
            if (IsShakingHead())
            {
                DropPuzzlePiece();
            }
        }
    }

    private void DropPuzzlePiece()
    {
        
        isPickedUp = false;
        gazeDetectionTime = MAX_TIME;
    }
    private void FollowPlayerView()
    {
        transform.position = playerCamera.GetComponentInChildren<Camera>().transform.position + playerCamera.GetComponentInChildren<Camera>().transform.forward * 13f;
    }

    public void OnPointerEnter()
    {
        Gaze(true);
    }

    public void OnPointerExit()
    {
        Gaze(false);
        gazeDetectionTime = MAX_TIME;
    }

    public void Gaze(bool isGazing)
    {
        if (isGazing && !this.GetComponent<PuzzlePiece>().IsInCorrectPosition())
        {
            isPickedUp = true;
        }
        else
        {
            isPickedUp = false;
        }
    }

    private bool IsShakingHead()
    {
        float shakeThreshold = 1.5f;
        
        return Input.gyro.rotationRate.magnitude > shakeThreshold;
    }
}