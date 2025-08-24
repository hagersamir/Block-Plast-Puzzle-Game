using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
  public Vector2Int[] shape;  
  public GameObject cellPrefab;
  public float cellSize = 1f;
  public float border = 0.05f;

  // create different shapes from small cells
  [ContextMenu("Create Shape")]
  public void CreateShape()
  {
    foreach (var pos in shape)
    {
      GameObject cell = Instantiate(cellPrefab, transform);
      cell.transform.localPosition = new Vector3(pos.x * cellSize, pos.y * cellSize, 0);
      cell.transform.localScale = Vector3.one * (1f - border);
    }
  }
  
  public Vector2Int[] ShapesOffsets(GameObject piece)
  {
    string pieceName = piece.name.Replace("(Clone)", "");
    switch (pieceName)
    {
      case "LShape":
        return new Vector2Int[] { new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(0, 2), new Vector2Int(0, 1) };
      case "L2Shape":
        return new Vector2Int[] { new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(0, 1), new Vector2Int(2, 0) };
      case "ColShape":
        return new Vector2Int[] { new Vector2Int(0, 0), new Vector2Int(0, 1), new Vector2Int(0, 2), new Vector2Int(0, 3) };
      case "SquareShape":
        return new Vector2Int[] { new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(0, 1), new Vector2Int(1, 1) };
      case "RowShape":
        return new Vector2Int[] { new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(2, 0), new Vector2Int(3, 0) };
      case "ZShape":
        return new Vector2Int[] { new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(1, 1), new Vector2Int(2, 1) };
      case "Z1Shape":
        return new Vector2Int[] { new Vector2Int(0, 1), new Vector2Int(1, 0), new Vector2Int(1, 1), new Vector2Int(2, 0) };
      default:
        return new Vector2Int[] { new Vector2Int(0, 0) };
    }
  }
}
