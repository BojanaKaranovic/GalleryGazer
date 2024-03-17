using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private Vector3 correctPosition;

    public void SetCorrectPosition(Vector3 position)
    {
        correctPosition = position;
    }

    public bool IsInCorrectPosition()
    {
        
        float threshold = 0.2f;
        if(Mathf.Abs( transform.localPosition.y - correctPosition.y) < threshold && Mathf.Abs(transform.localPosition.z - correctPosition.z) < threshold) {
            
            return true; }
        return false;
    }

    public void MoveToCorrectPosition() {
        transform.localPosition = correctPosition;

    }
}
