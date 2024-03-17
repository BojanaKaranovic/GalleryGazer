using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PuzzleCreator : MonoBehaviour
{
    [SerializeField] private int rows = 3;
    [SerializeField] private int cols = 3;

    private GalleryImageSelection gallerySelection;

    public static event Action PuzzlePiecesCreated;

    
    private void Start()
    {
        CreatePuzzlePieces();

    }

    void CreatePuzzlePieces()
    {
        Texture2D originalTexture = GalleryImageSelection.Instance.selectedImage;
        originalTexture.wrapMode = TextureWrapMode.Clamp;
            originalTexture.filterMode = FilterMode.Point;
            Color[] pixels = originalTexture.GetPixels();

            int pieceWidth = originalTexture.width / cols;
            int pieceHeight = originalTexture.height / rows;

            bool sign = false;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
            {
                int startX = col * pieceWidth;
                int startY = row * pieceHeight;

                Texture2D puzzlePiece = new Texture2D(pieceWidth, pieceHeight);

                puzzlePiece.SetPixels(originalTexture.GetPixels(startX, startY, pieceWidth, pieceHeight));

                puzzlePiece.Apply();

                Material puzzleMaterial = new Material(Shader.Find("Standard"));
                puzzleMaterial.mainTexture = puzzlePiece;

                
                CreatePiece(sign, row, col, puzzleMaterial);
                sign = !sign;
            }
        }

            GameObject board = GameObject.CreatePrimitive(PrimitiveType.Cube);
            board.transform.parent = transform;
            board.transform.localPosition = new Vector3(-0.8f, 0, 0);
            board.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            board.GetComponent<Renderer>().material.color = Color.black;
            board.AddComponent<BoxCollider>();
            GetComponent<Renderer>().enabled = false;
            PuzzlePiecesCreated?.Invoke();
        
    }

    private void CreatePiece(bool sign, int row, int col, Material puzzleMaterial)
    {
        GameObject puzzlePieceObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        puzzlePieceObject.name = "PuzzlePiece_" + row + "_" + col;
        puzzlePieceObject.transform.parent = transform;
        float posX = 1f;
        float posY = sign ? row * -1 + Random.Range(-2, 2) / 2f : row + Random.Range(-2, 2) / 2f;
        float posZ = sign ? col * -1 + Random.Range(-2, 2) : col + Random.Range(-2, 2);

        puzzlePieceObject.transform.localPosition = new Vector3(posX, posY / 2f, posZ / 2f);

        puzzlePieceObject.transform.localRotation = Quaternion.identity;
        puzzlePieceObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        puzzlePieceObject.layer = LayerMask.NameToLayer("Interactive");

        PuzzlePiece puzzlePieceScript = puzzlePieceObject.AddComponent<PuzzlePiece>();

        Vector3 correctPosition = CalculateCorrectPosition(row, col);
        puzzlePieceScript.SetCorrectPosition(correctPosition);

        puzzlePieceObject.AddComponent<PuzzleInteraction>();

        puzzlePieceObject.GetComponent<Renderer>().material = puzzleMaterial;
    }

    Vector3 CalculateCorrectPosition(int row, int col)
    {
        float puzzlePieceSize = 0.5f;

        float correctY = row * (puzzlePieceSize + 0) - 0.5f;
        float correctZ = col * (puzzlePieceSize + 0) - 0.5f;

        return new Vector3(0, correctY, correctZ);
    }
}
