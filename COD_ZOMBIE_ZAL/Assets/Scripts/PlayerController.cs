using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Ruch")]
    public float speed = 8f;
    public float acceleration = 10f;
    public float deceleration = 10f;
    
    [Header("Kamera")]
    public Transform playerCamera;
    public float mouseSensitivity = 2f;
    
    [Header("Skakanie")]
    public float jumpForce = 5f;
    public float groundCheckDistance = 0.1f;
    
    private Rigidbody rb;
    private float xRotation;
    private float distToGround;
    private Vector3 currentVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();
        HandleJump();
        HandleMovement();
    }

    void HandleMouseLook()
    {
        if (playerCamera == null) return;
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        transform.Rotate(Vector3.up * mouseX);
        
        xRotation = Mathf.Clamp(xRotation - mouseY, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void HandleMovement()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Vector3 moveDirection = transform.TransformDirection(input.normalized);
        Vector3 targetVelocity = moveDirection * speed;
        
        float lerpSpeed = (input.magnitude > 0.1f) ? acceleration : deceleration;
        currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity, lerpSpeed * Time.deltaTime);
        
        rb.linearVelocity = new Vector3(currentVelocity.x, rb.linearVelocity.y, currentVelocity.z);
    }

    void HandleJump()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        if (!IsGrounded()) return;
        
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround + groundCheckDistance);
    }
}