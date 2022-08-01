using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public int width;
    public int height;
    private GridCellLayout placementGridCellLayout;
    private Dictionary<Vector3Int, StructureModel> temporaryStructureObjects = new Dictionary<Vector3Int, StructureModel>();

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

    internal void PlaceTemporaryStructure(Vector3Int position, GameObject structurePrefab, CellType type)
    {
        placementGridCellLayout.SetGridCellData(position, type);
        StructureModel structure = CreateANewStructureModel(position, structurePrefab, type);
        temporaryStructureObjects.Add(position, structure);
    }

    private StructureModel CreateANewStructureModel(Vector3Int position, GameObject structurePrefab, CellType type)
    {
        GameObject structure = new GameObject(type.ToString());
        structure.transform.SetParent(transform);
        structure.transform.localPosition = position + new Vector3(0.5f , 0, 0.5f);
        var structureModel = structure.AddComponent<StructureModel>();
        structureModel.CreateModel(structurePrefab);
        return structureModel;
    }
    
    internal List<Vector3Int> GetNeighboursOfTypeFor(Vector3Int position, CellType type)
    {
        var neighbourVertices = placementGridCellLayout.GetAdjacentCellsOfType(position.x, position.z, type);
        List<Vector3Int> neighbours = new List<Vector3Int>();
        foreach (var point in neighbourVertices)
        {
            neighbours.Add(new Vector3Int(point.X, 0, point.Y));
        }
        return neighbours;
    }

    public void ModifyStructureModel(Vector3Int position, GameObject newModel, Quaternion rotation)
    {
        if (temporaryStructureObjects.ContainsKey(position))
        {
            temporaryStructureObjects[position].SwapModel(newModel, rotation);
        }
    }
    
    internal CellType[] GetNeighbourTypesFor(Vector3Int position)
    {
        return placementGridCellLayout.GetAllAdjacentCellTypes(position.x, position.z);
    }
}
