using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RoadManager roadManager;

    private void Start()
    {
        InputManager.Instance.OnMouseClick += HandleMouseClick;
    }

    private void HandleMouseClick(Vector3Int position)
    {
        roadManager.PlaceRoad(position);
    }
}
