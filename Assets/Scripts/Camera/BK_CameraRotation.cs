using UnityEngine;

public class BK_CameraRotation : MonoBehaviour
{
    public float rotSpeed;

    private float yRotation;
    private const float CAM_ANGLE = 35f;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * rotSpeed;

            yRotation += mouseX;

            transform.rotation = Quaternion.Euler(CAM_ANGLE, yRotation, 0);
            transform.parent.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}
