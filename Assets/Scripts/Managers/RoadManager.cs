using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public PlacementManager placementManager;

    public List<Vector3Int> temporaryPlacementPositions = new List<Vector3Int>();
    public List<Vector3Int> roadPositionsToRecheck = new List<Vector3Int>();

    public GameObject roadStraight;
    public RoadFixer roadFixer;

    public void PlaceRoad(Vector3Int position)
    {
        if (!placementManager.CheckIfPositionInBound(position))
        {
            return;
        }

        if (!placementManager.CheckIfPositionIsFree(position))
        {
            return;
        }
            
        temporaryPlacementPositions.Clear();
        temporaryPlacementPositions.Add(position);
        placementManager.PlaceTemporaryStructure(position, roadStraight, CellType.Road);
        FixRoadPrefabs();
    }

    private void FixRoadPrefabs()
    {
        foreach (var temporaryPosition in temporaryPlacementPositions)
        {
            roadFixer.FixRoadAtPosition(placementManager, temporaryPosition);
            var neighbours = placementManager.GetNeighboursOfTypeFor(temporaryPosition, CellType.Road);
            foreach (var roadPosition in neighbours)
            {
                roadPositionsToRecheck.Add(roadPosition);
            }
        }
        foreach (var positionToFix in roadPositionsToRecheck)
        {
            roadFixer.FixRoadAtPosition(placementManager, positionToFix);
        }
    }
}
