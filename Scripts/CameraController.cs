using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 5.0f;
    public float smoothing = 0.1f;
    private Vector3 lastMousePosition;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            Vector3 targetPosition = transform.position - new Vector3(delta.x, delta.y, 0) * speed * Time.deltaTime;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothing);
        }

        lastMousePosition = Input.mousePosition;
    }
}