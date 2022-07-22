using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public int width;
    public int height;
    private GridCellLayout placementGridCellLayout;

    private void Start()
    {
        placementGridCellLayout = new GridCellLayout(width, height);
    }

    internal bool CheckIfPositionInBound(Vector3Int position)
    {
        return position.x >= 0 && position.x < width && position.z >=0 && position.z < height;
    }

    internal bool CheckIfPositionIsFree(Vector3Int position)
    {
        return CheckIfPositionIsOfType(position, CellType.Empty);
    }

    private bool CheckIfPositionIsOfType(Vector3Int position, CellType type)
    {
        return placementGridCellLayout.GetGridCellByPosition(position).Type == type;
    }

    internal void PlaceTemporaryStructure(Vector3Int position, GameObject structureObject, CellType type)
    {
        placementGridCellLayout.SetGridCellData(position, type);
        GameObject newStructure = Instantiate(structureObject, position, Quaternion.identity);
    }
}
