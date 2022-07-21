using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;
    [SerializeField] private float movementSpeed = 5;

    private void Update()
    {
        MoveCamera(new Vector3(InputManager.Instance.CameraMovementVector.x,0, InputManager.Instance.CameraMovementVector.y));
    }

    private void MoveCamera(Vector3 inputVector)
    {
        var movementVector = Quaternion.Euler(0,30,0) * inputVector;
        gameCamera.transform.position += movementVector * Time.deltaTime * movementSpeed;
    }
}