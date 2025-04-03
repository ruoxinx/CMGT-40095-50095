using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class FirstPersonCubeController_Collision : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;

    private Rigidbody rb;
    private float rotationX = 0f;
    private float rotationY = 0f;
    private Camera playerCamera;

    void Start()
    {
        // Get Rigidbody and freeze rotation so physics doesn't rotate the object
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        // Try to get the Main Camera; if it doesn't exist, create one
        playerCamera = Camera.main;
        if (playerCamera == null)
        {
            GameObject camObj = new GameObject("Main Camera");
            playerCamera = camObj.AddComponent<Camera>();
            camObj.tag = "MainCamera";
        }

        // Parent the camera to this object and set its local position (eye level)
        playerCamera.transform.SetParent(this.transform);
        playerCamera.transform.localPosition = new Vector3(0, 1.5f, 0);

        // Lock and hide the cursor for first-person control
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Mouse look: update rotation based on mouse movement
        rotationX += Input.GetAxis("Mouse X") * lookSpeed;
        rotationY -= Input.GetAxis("Mouse Y") * lookSpeed;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        // Rotate the body (horizontal rotation) and the camera (vertical rotation)
        transform.localRotation = Quaternion.Euler(0f, rotationX, 0f);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);
    }

    void FixedUpdate()
    {
        // WASD movement using Rigidbody for collision detection
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }
}
