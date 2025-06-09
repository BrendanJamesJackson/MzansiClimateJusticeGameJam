using UnityEngine;
using Unity.Cinemachine;

public class GodViewCameraController : MonoBehaviour
{
    [Header("Panning")]
    public float panSpeed = 50f;
    public float mousePanSpeed = 0.5f;
    public Vector2 panLimitX = new Vector2(-100,100);
    public Vector2 panLimitZ = new Vector2(-100, 100);
    public float smoothTime = 0.2f;

    [Header("Zooming")]
    public float scrollSpeed = 20f;
    public float zoomSmoothness = 5f;
    public float minY = 0f;
    public float maxY = 1f;

    private float targetY;
    private Vector3 currentVelocity;


    private Vector3 lastMousePosition;
    private bool isDragging = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        HandleKeyboardPanning();
        HandleMouseDragging();
        HandleZooming();
    }

    void HandleKeyboardPanning()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            direction += transform.forward;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            direction -= transform.forward;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            direction -= transform.right;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            direction += transform.right;

        direction.y = 0;
        transform.position += direction.normalized * panSpeed * Time.deltaTime;
        ClampPosition();
    }

    void HandleMouseDragging()
    {
        if (Input.GetMouseButtonDown(1))
        {
            lastMousePosition = Input.mousePosition;
            isDragging = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            Vector3 move = new Vector3(-delta.x * mousePanSpeed, 0, -delta.y * mousePanSpeed);

            Vector3 moveDirection = transform.right * move.x + transform.forward * move.z;
            moveDirection.y = 0;

            transform.position += moveDirection * Time.deltaTime;
            lastMousePosition = Input.mousePosition;

            ClampPosition();
        }
    }

    void HandleZooming()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.001f)
        {
            targetY -= scroll * scrollSpeed;
            targetY = Mathf.Clamp(targetY, minY, maxY);
        }

        Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, 1f / zoomSmoothness);
    }

    void ClampPosition()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, panLimitX.x, panLimitX.y),
            transform.position.y,
            Mathf.Clamp(transform.position.z, panLimitZ.x, panLimitZ.y)
        );
    }
}
