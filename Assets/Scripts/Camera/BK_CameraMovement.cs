using UnityEngine;
using UnityEngine.InputSystem;

public class BK_CameraMovement : MonoBehaviour
{
    public float movSpeed;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            transform.Translate(new Vector3(
                                 -Input.GetAxisRaw("Mouse X") * Time.deltaTime * movSpeed,
                                 0.0f,
                                 -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * movSpeed), Space.Self);

        }
    }
}
