using System.Linq;
using UnityEngine;

public class StructureManager : MonoBehaviour
{
    public StructurePrefabWeighted[] housesPrefabs;
    public StructurePrefabWeighted[] specialPrefabs;
    public StructurePrefabWeighted[] bigStructuresPrefabs;

    private float[] houseWeights;
    private float[] specialWeights;
    private float[] bigStructureWeights;

    
    public PlacementManager placementManager;

    private void Start()
    {
        houseWeights = housesPrefabs.Select(prefabStats => prefabStats.weight).ToArray();
        specialWeights = specialPrefabs.Select(prefabStats => prefabStats.weight).ToArray();
        bigStructureWeights = bigStructuresPrefabs.Select(prefabStats => prefabStats.weight).ToArray();
    }
    
    public void PlaceHouse(Vector3Int position)
    {
        if (CheckPositionBeforePlacement(position))
        {
            int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, housesPrefabs[randomIndex].prefab, CellType.Structure);
        }
    }

    public void PlaceSpecial(Vector3Int position)
    {
        if (CheckPositionBeforePlacement(position))
        {
            int randomIndex = GetRandomWeightedIndex(specialWeights);
            placementManager.PlaceObjectOnTheMap(position, specialPrefabs[randomIndex].prefab, CellType.Structure);
        }
    }
    
    internal void PlaceBigStructure(Vector3Int position)
    {
        int width = 2;
        int height = 2;
        if(CheckBigStructure(position, width , height))
        {
            int randomIndex = GetRandomWeightedIndex(bigStructureWeights);
            placementManager.PlaceObjectOnTheMap(position, bigStructuresPrefabs[randomIndex].prefab, CellType.Structure, width, height);
        }
    }
    
    private bool CheckBigStructure(Vector3Int position, int width, int height)
    {
        bool nearRoad = false;
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                var newPosition = position + new Vector3Int(x, 0, z);
                
                if (DefaultCheck(newPosition)==false)
                {
                    return false;
                }
                if (nearRoad == false)
                {
                    nearRoad = RoadCheck(newPosition);
                }
            }
        }
        return nearRoad;
    }
    
    private bool CheckPositionBeforePlacement(Vector3Int position)
    {
        if (!DefaultCheck(position))
        {
            return false;
        }

        if (!RoadCheck(position))
        {
            return false;
        }
        
        return true;
    }

    private bool RoadCheck(Vector3Int position)
    {
        if (placementManager.GetNeighboursOfTypeFor(position, CellType.Road).Count <= 0)
        {
            Debug.Log("Must be placed near a road");
            return false;
        }
        return true;
    }

    private bool DefaultCheck(Vector3Int position)
    {
        if (!placementManager.CheckIfPositionInBound(position))
        {
            Debug.Log("This position is out of bounds");
            return false;
        }
        if (!placementManager.CheckIfPositionIsFree(position))
        {
            Debug.Log("This position is not EMPTY");
            return false;
        }
        return true;
    }
    
    private int GetRandomWeightedIndex(float[] weights)
    {
        float sum = 0f;
        for (int i = 0; i < weights.Length; i++)
        {
            sum += weights[i];
        }

        float randomValue = Random.Range(0, sum);
        float tempSum = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            if(randomValue >= tempSum && randomValue < tempSum + weights[i])
            {
                return i;
            }
            tempSum += weights[i];
        }
        return 0;
    }
}
