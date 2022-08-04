using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RoadManager roadManager;
    public UIController uiController;
    public StructureManager structureManager;


    private void Start()
    {
        uiController.OnRoadPlacement += RoadPlacementHandler;
        uiController.OnHousePlacement += HousePlacementHandler;
        uiController.OnSpecialPlacement += SpecialPlacementHandler;
        uiController.OnBigStructurePlacement += BigStructurePlacementHandler;
    }
    
    private void BigStructurePlacementHandler()
    {
        ClearInputActions();
        InputManager.Instance.OnMouseClick += structureManager.PlaceBigStructure;
    }

    private void SpecialPlacementHandler()
    {
        ClearInputActions();
        InputManager.Instance.OnMouseClick += structureManager.PlaceSpecial;
    }

    private void HousePlacementHandler()
    {
        ClearInputActions();
        InputManager.Instance.OnMouseClick += structureManager.PlaceHouse;
    }

    private void RoadPlacementHandler()
    {
        ClearInputActions();
        InputManager.Instance.OnMouseClick += roadManager.PlaceRoad;
        InputManager.Instance.OnMouseHold += roadManager.PlaceRoad;
        InputManager.Instance.OnMouseUp += roadManager.FinishPlacingRoad;
    }
    
    private void ClearInputActions()
    {
        InputManager.Instance.OnMouseClick = null;
        InputManager.Instance.OnMouseHold = null;
        InputManager.Instance.OnMouseUp = null;
    }
}
