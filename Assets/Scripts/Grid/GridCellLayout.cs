using System.Collections.Generic;
using UnityEngine;

public class GridCellLayout
{
    private GridCellData[,] grid;

    private int gridWidth;
    private int gridHeight;

    public GridCellLayout(int width, int height)
    {
        gridWidth = width;
        gridHeight = height;
        CreateGridData(width, height);
    }

    private void CreateGridData(int width, int height)
    {
        grid = new GridCellData[width, height];

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                SetGridCellData(new Vector3Int(i,0,j), CellType.Empty);
            }
        }
    }

    public GridCellData GetGridCellByPosition(Vector3Int position)
    {
        return grid[position.x, position.z];
    }

    public void SetGridCellData(Vector3Int position, CellType type)
    {
        var point = new Point(position.x, position.z);
        var data = new GridCellData(point.ToString(), point, type);
        grid[position.x, position.z] = data;
    }

    private static bool IsGridCellWalkable(CellType cellType)
    {
        return cellType == CellType.Empty || cellType == CellType.Road;
    }
    
    public List<Point> GetAdjacentCells(Point cell)
    {
        return GetWalkableAdjacentCells((int)cell.X, (int)cell.Y);
    }

    public float GetCostOfEnteringCell(Point cell)
    {
        return 1;
    }

    public List<Point> GetAllAdjacentCells(int x, int y)
    {
        List<Point> adjacentCells = new List<Point>();
        if (x > 0)
        {
            adjacentCells.Add(new Point(x - 1, y));
        }
        if (x < gridWidth - 1)
        {
            adjacentCells.Add(new Point(x + 1, y));
        }
        if (y > 0)
        {
            adjacentCells.Add(new Point(x, y - 1));
        }
        if (y < gridHeight - 1)
        {
            adjacentCells.Add(new Point(x, y + 1));
        }
        return adjacentCells;
    }
    
    public List<Point> GetAdjacentCellsOfType(int x, int y, CellType type)
    {
        List<Point> adjacentCells = GetAllAdjacentCells(x, y);
        for (int i = adjacentCells.Count - 1; i >= 0; i--)
        {
            if (GetGridCellByPosition(new Vector3Int(adjacentCells[i].X, 0,adjacentCells[i].Y)).Type != type)
            {
                adjacentCells.RemoveAt(i);
            }
        }
        return adjacentCells;
    }
    
    /// <summary>
    /// Returns array [Left neighbour, Top neighbour, Right neighbour, Down neighbour]
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public CellType[] GetAllAdjacentCellTypes(int x, int y)
    {
        CellType[] neighbours = { CellType.None, CellType.None, CellType.None, CellType.None };
        
        if (x > 0)
        {
            neighbours[0] = GetGridCellByPosition(new Vector3Int(x - 1, 0, y)).Type;
        }
        if (x < gridWidth - 1)
        {
            neighbours[2] = GetGridCellByPosition(new Vector3Int(x + 1, 0, y)).Type;
        }
        if (y > 0)
        {
            neighbours[3] = GetGridCellByPosition(new Vector3Int(x, 0, y - 1)).Type;
        }
        if (y < gridHeight - 1)
        {
            neighbours[1] = GetGridCellByPosition(new Vector3Int(x, 0, y + 1)).Type;
        }
        return neighbours;
    }

    private List<Point> GetWalkableAdjacentCells(int x, int y)
    {
        List<Point> adjacentCells = GetAllAdjacentCells(x, y);
        for (int i = adjacentCells.Count - 1; i >= 0; i--)
        {
            if (!IsGridCellWalkable(GetGridCellByPosition(new Vector3Int(adjacentCells[i].X, 0, adjacentCells[i].Y)).Type)) 
            {
                adjacentCells.RemoveAt(i);
            }
        }
        return adjacentCells;
    }
}
