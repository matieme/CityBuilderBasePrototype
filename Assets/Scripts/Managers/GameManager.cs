using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RoadManager roadManager;

    private void Start()
    {
        InputManager.Instance.OnMouseClick += HandleMouseClick;
        InputManager.Instance.OnMouseHold += HandleMouseClick;
        InputManager.Instance.OnMouseUp += roadManager.FinishPlacingRoad;
    }

    private void HandleMouseClick(Vector3Int position)
    {
        roadManager.PlaceRoad(position);
    }
}
