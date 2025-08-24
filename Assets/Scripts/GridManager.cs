using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class GridManager : MonoBehaviour
{
  [Header("Grid Settings")]
  public GameObject cellPrefab; // a simple white square prefab
  public int width = 8;
  public int height = 10;
  public float cellSize = 0.5f;
  public float border = 0.05f;

  private bool[,] occupied;
  private Vector3 startPos;

  [ContextMenu("Create Grid")]
  public void CreateGrid()
  {
    // calculate starting position (so grid is centered)
    Vector3 startPos = new Vector3(
        -(width * cellSize) / 2f + cellSize / 2f,
        -(height * cellSize) / 2f + cellSize / 2f,
        0
    );
    for (int x = 0; x < width; x++)
    {
      for (int y = 0; y < height; y++)
      {
        // position of this cell
        Vector3 pos = startPos + new Vector3(x * cellSize, y * cellSize, 0);
        // create cell
        GameObject cell = Instantiate(cellPrefab, pos, Quaternion.identity, transform);
        cell.name = $"Cell_{x}_{y}";
        // shrink the cell slightly to leave a thin border
        cell.transform.localScale = Vector3.one * (1f - border);
      }
    }
  }
  
  void Start()
{
    occupied = new bool[width, height];
    GetStartPosFromExistingGrid(); // Get position from existing cells
}
  void GetStartPosFromExistingGrid()
{
    // Find the bottom-left cell (Cell_0_0)
    Transform bottomLeftCell = transform.Find("Cell_0_0");
    
    if (bottomLeftCell != null)
    {
        startPos = bottomLeftCell.position;
    }
    else
    {
        // Fallback: calculate from first child
        if (transform.childCount > 0)
        {
            startPos = transform.GetChild(0).position;
        }
    }
}
    
}
