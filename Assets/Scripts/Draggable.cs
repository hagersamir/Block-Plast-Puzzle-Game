

using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 startPos;
    private float startScale;
    private bool dragging = false;
    private SpriteRenderer[] renderers; 

    private List<SpriteRenderer> highlightedCells = new List<SpriteRenderer>();
    private Dictionary<SpriteRenderer, Color> originalColors = new Dictionary<SpriteRenderer, Color>();

    void Start()
    {
        startPos = transform.position;
        startScale = transform.localScale.x;
        renderers = GetComponentsInChildren<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        dragging = true;
        transform.localScale = Vector3.one; // enlarge to grid scale
    }

    void OnMouseDrag()
    {
        if (!dragging) return;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
        HighlightCellsUnderPiece();
    }

    void OnMouseUp()
    {
        if (!dragging) return;
        // Check if highlight matches piece size
        if (highlightedCells.Count == renderers.Length)
        {
            bool allFree = true;
            // Check if any highlighted cell is already occupied
            foreach (var sr in highlightedCells)
            {
                OccupiedCell cell = sr.GetComponent<OccupiedCell>();
                if (cell != null && cell.occupied)
                {
                    allFree = false;
                    break;
                }
            }
            if (allFree)
            {
                // Valid drop: lock cells with piece color
                Color pieceColor = renderers[0].color;
                foreach (var sr in highlightedCells)
                {
                    OccupiedCell cell = sr.GetComponent<OccupiedCell>();
                    if (cell != null)
                    {
                      cell.sr.color = pieceColor;
                      cell.occupied = true; // mark as filled
                      if (ScoreManager.Instance != null)
                      ScoreManager.Instance.AddScore(1);
                    }
                }
                highlightedCells.Clear();
                // trigger line clear check
                if (LineChecker.Instance != null)
                    LineChecker.Instance.CheckLines();
                Destroy(gameObject); // remove piece itself
            }
            else
            {
                // Invalid: overlapping piece
                ResetPiece();
            }
        }
        else
        {
            // Invalid: outside grid
            ResetPiece();
        }
        dragging = false;
    }

    void HighlightCellsUnderPiece()
    {
        ClearHighlights();
        highlightedCells.Clear();
        originalColors.Clear();
        bool allValid = true;
        foreach (var r in renderers)
        {
            Vector2 blockPos = r.transform.position;
            Collider2D hit = Physics2D.OverlapPoint(blockPos);
            if (hit != null && hit.CompareTag("GridCell"))
            {
                OccupiedCell cell = hit.GetComponent<OccupiedCell>();
                if (cell != null)
                {
                    if (cell.occupied) // already filled
                        allValid = false;
                    if (!originalColors.ContainsKey(cell.sr))
                        originalColors[cell.sr] = cell.sr.color; // save cell original color
                    highlightedCells.Add(cell.sr);
                }
            }
            else
            {
                allValid = false; // not on a valid cell
            }
        }
        // Highlight grey if valid, red if invalid
        Color c = allValid ? Color.grey : Color.red;
        foreach (var sr in highlightedCells)
            sr.color = c;
    }

    void ClearHighlights()
    {
        foreach (var cell in highlightedCells)
        {
            if (originalColors.ContainsKey(cell))
                cell.color = originalColors[cell]; // restore original color
        }
        highlightedCells.Clear();
    }

    void ResetPiece()
    {
        transform.position = startPos;
        transform.localScale = Vector3.one * startScale;
        ClearHighlights();
    }
}
