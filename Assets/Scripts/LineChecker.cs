using System.Collections.Generic;
using UnityEngine;

public class LineChecker : MonoBehaviour
{
  public static LineChecker Instance;
  public GameObject boomPrefab;
  public int width = 8;
  public int height = 10;
  public int score = 0;

  public OccupiedCell[,] grid;

  void Start()
  {
    Instance = this;
    BuildGridLookup();
  }

  void BuildGridLookup()
  {
    grid = new OccupiedCell[width, height];
    foreach (var cell in FindObjectsOfType<OccupiedCell>())
    {
      // parse "Cell_x_y" from name
      string[] parts = cell.name.Split('_');
      int x = int.Parse(parts[1]);
      int y = int.Parse(parts[2]);
      grid[x, y] = cell;
    }
  }

  public void CheckLines()
  {
    List<int> fullRows = new List<int>();
    List<int> fullCols = new List<int>();
    //check rows
    for (int y = 0; y < height; y++)
    {
      bool full = true;
      for (int x = 0; x < width; x++)
      {
        if (!grid[x, y].occupied)
        {
          full = false;
          break;
        }
      }
      if (full) fullRows.Add(y);
    }
    // check cols
    for (int x = 0; x < width; x++)
    {
      bool full = true;
      for (int y = 0; y < height; y++)
      {
        if (!grid[x, y].occupied)
        {
          full = false;
          break;
        }
      }
      if (full) fullCols.Add(x);
    }
    foreach (int y in fullRows) ClearRow(y);
    foreach (int x in fullCols) ClearColumn(x);
  }

  void ClearRow(int row)
  {
    for (int x = 0; x < width; x++)
    {
      BoomEffect(grid[x, row].transform.position);
      grid[x, row].occupied = false;
      grid[x, row].sr.color = new Color(0.11f, 0.08f, 0.08f); // original color 1C1515
    }
    for (int y = row + 1; y < height; y++)
    {
      for (int x = 0; x < width; x++)
      {
        if (grid[x, y].occupied)
        {
          // copy color down (move filled cells down)
          grid[x, y - 1].sr.color = grid[x, y].sr.color;
          grid[x, y - 1].occupied = true;
          // clear old line
          grid[x, y].sr.color = new Color(0.11f, 0.08f, 0.08f);
          grid[x, y].occupied = false;
        }
      }
    }
    if (ScoreManager.Instance != null)
      ScoreManager.Instance.AddScore(50);
  }

  void ClearColumn(int col)
  {
    for (int y = 0; y < height; y++)
    {
      BoomEffect(grid[col, y].transform.position);
      grid[col, y].occupied = false;
      grid[col, y].sr.color = new Color(0.11f, 0.08f, 0.08f);
    }
    if (ScoreManager.Instance != null)
      ScoreManager.Instance.AddScore(100);
  }

  void BoomEffect(Vector3 pos)
{
    if (boomPrefab != null)
    {
        GameObject boom = Instantiate(boomPrefab, pos, Quaternion.identity);
        Destroy(boom, 1.5f); // remove after animation
    }
}
}
