using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;
    [SerializeField] private float movementSpeed = 5;
    
    public void MoveCamera(Vector3 inputVector)
    {
        var movementVector = Quaternion.Euler(0,30,0) * inputVector;
        gameCamera.transform.position += movementVector * Time.deltaTime * movementSpeed;
    }
}