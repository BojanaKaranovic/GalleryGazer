using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSolved : MonoBehaviour
{
    private PuzzlePiece[] puzzlePieces;

    private bool isPuzzleSolved = false;
    private bool firstTime = true;

    public static PuzzleSolved Instance; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        PuzzleCreator.PuzzlePiecesCreated += FindPuzzlePieces;
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        if (!isPuzzleSolved)
        {
            CheckPuzzleSolved();
        }
    }

    private void FindPuzzlePieces()
    {
        PuzzlePiece[] foundPieces = GameObject.FindObjectsOfType<PuzzlePiece>();
        puzzlePieces = foundPieces;
        
    }

    private void CheckPuzzleSolved()
    {
        int correctPieces = 0;

        foreach (PuzzlePiece piece in puzzlePieces)
        {
            if (piece.IsInCorrectPosition())
            {
                correctPieces++;
                piece.MoveToCorrectPosition();
            }
        }
        if (firstTime) { SetText(); firstTime = false; }
        if (correctPieces == 9)
        {
            isPuzzleSolved = true;

            OnPuzzleSolved();
        }
    }

    private void OnPuzzleSolved()
    {
        Debug.Log("Puzzle Solved!!!!!!");
        if (SystemInfo.supportsVibration)
        {
            Handheld.Vibrate();
        }
        SolvedPuzzleEffect.Instance.PlayPieceSolvedEffect();
    }

    private void SetText()
    {
        Debug.Log(GalleryImageSelection.Instance.materialName);
        if(GalleryImageSelection.Instance.materialName == "Babilon")
        {
            PuzzleUIManager.Instance.TowerOfBabel();
        }
        else if (GalleryImageSelection.Instance.materialName == "KosovkaDevojka")
        {
            PuzzleUIManager.Instance.KosovkaDevojka();
        }
        else if (GalleryImageSelection.Instance.materialName == "Forest")
        {
            PuzzleUIManager.Instance.Forest();
        }
        else if (GalleryImageSelection.Instance.materialName == "Moonlight")
        {
            PuzzleUIManager.Instance.Moonlight();
        }
        else if (GalleryImageSelection.Instance.materialName == "WaterLilly")
        {
            PuzzleUIManager.Instance.WaterLilly();
        }
        else if (GalleryImageSelection.Instance.materialName == "Wave")
        {
            PuzzleUIManager.Instance.Wave();
        }
        else
        {
            Debug.Log("Error");
        }
    }
    
}
