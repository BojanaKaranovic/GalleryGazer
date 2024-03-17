using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private static float MAX_TIME = 2f;

    [SerializeField] private Color inactiveColor = Color.gray;
    [SerializeField] private Color gazeColor = Color.cyan;
    [SerializeField] private GameObject playerCamera;

    private float gazeDetectionTime = MAX_TIME;
    private MeshRenderer meshRenderer;
    private bool isColorChanging = false;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        meshRenderer.material.color = inactiveColor;
    }

    private void Update()
    {
        if (isColorChanging)
        {
            meshRenderer.material.color = Color.Lerp(inactiveColor, gazeColor, (MAX_TIME - gazeDetectionTime));
            gazeDetectionTime -= Time.deltaTime;

            if (gazeDetectionTime <= 0)
            {
                isColorChanging = false;
                TeleportPlayerToLocation(transform.position);
                meshRenderer.material.color = inactiveColor;
            }
        }
    }

    private void TeleportPlayerToLocation(Vector3 position)
    {
        playerCamera.transform.position = new Vector3(position.x, playerCamera.transform.position.y, position.z);
    }

    public void OnPointerEnter()
    {
        Gaze(true);
    }

    public void OnPointerExit()
    {
        Gaze(false);
    }

    public void Gaze(bool isGazing)
    {
        if (isGazing)
        {
            isColorChanging = true;
        }
        else
        {
            gazeDetectionTime = MAX_TIME;
            isColorChanging = false;
            meshRenderer.material.color = inactiveColor;
        }
    }
}
