using System.Collections;
using UnityEngine;
using TMPro;

public class SpawnAreaManager : MonoBehaviour
{
    public GameObject[] pieces;
    public Transform[] slots;
    public GameObject gameOverCanvas;
    public GameObject countdownCanvas; 
    public TMP_Text countdownText;  
    private bool isGameOver = false;
    private Coroutine gameOverCoroutine;

    void Start()
    {
        SpawnPieces();
    }

    void Update()
    {
        if (isGameOver) return;
        
        if (AreAllSlotsEmpty())
        {
            SpawnPieces();
        }
        else
        {
            CheckGameOver();
        }
    }

    bool AreAllSlotsEmpty()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].childCount > 0)
                return false;
        }
        return true;
    }

    void SpawnPieces()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            GameObject newPiece = Instantiate(pieces[Random.Range(0, pieces.Length)], slots[i]);
            newPiece.transform.localPosition = Vector3.zero;
            newPiece.transform.localScale = Vector3.one * 0.5f;
        }
    }

    void CheckGameOver()
    {
        if (LineChecker.Instance == null) return;
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].childCount == 0) continue;
            GameObject piece = slots[i].GetChild(0).gameObject;
            if (CanFit(piece))
                return; // At least one piece can fit
        }
        // No pieces can fit 
        if (gameOverCoroutine == null)
        {
            isGameOver = true;
            gameOverCoroutine = StartCoroutine(GameOverRoutine());
        }
    }

    bool CanFit(GameObject piece)
    {
        if (LineChecker.Instance == null) return false;
        Piece pieceComp = piece.GetComponent<Piece>();
        if (pieceComp == null) return false;
        Vector2Int[] shape = pieceComp.ShapesOffsets(piece);
        int gridWidth = LineChecker.Instance.width;
        int gridHeight = LineChecker.Instance.height;
        var grid = LineChecker.Instance.grid;
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                bool fits = true;
                
                foreach (var offset in shape)
                {
                    int gx = x + offset.x;
                    int gy = y + offset.y;
                    // Check bounds and occupancy in one condition
                    if (gx < 0 || gy < 0 || gx >= gridWidth || gy >= gridHeight ||
                        grid[gx, gy] == null || grid[gx, gy].occupied)
                    {
                        fits = false;
                        break;
                    }
                }
                if (fits) return true;
            }
        }
        return false;
    }

    IEnumerator GameOverRoutine()
    {    
        countdownCanvas.SetActive(true);  // show countdown
    for (int i = 5; i > 0; i--)
    {
      countdownText.text = i.ToString();
          yield return new WaitForSeconds(1f);
        }
        countdownCanvas.SetActive(false); 
        gameOverCanvas.SetActive(true);   
    }
    }
