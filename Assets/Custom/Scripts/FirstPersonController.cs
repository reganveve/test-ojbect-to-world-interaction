using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FPSController : MonoBehaviour {
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float runMultiplier = 2f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float extraGravity = 10f;

    [Header("Look Settings")]
    [SerializeField] private Transform cameraPivot; // new pivot object
    [SerializeField] private float mouseSensitivity = 5f;
    [SerializeField] private Vector2 minMaxPitch = new Vector2(-60, 70);

    private Rigidbody rb;
    private Collider col;
    private Vector2 moveInput;
    private float yaw;
    private float pitch;
    private bool jumpRequested;
    private bool isRun;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.freezeRotation = true;
        
        col = GetComponentInChildren<Collider>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        GetMoveInput();
        GetMouseInput();

        void GetMoveInput() {
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Input.GetButtonDown("Jump")) jumpRequested = true;
        }

        void GetMouseInput() {
            Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
            yaw += mouseInput.x * mouseSensitivity;
            pitch += mouseInput.y * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, minMaxPitch.x, minMaxPitch.y);
        }
    }

    private void FixedUpdate() {
        rb.MoveRotation(Quaternion.Euler(0f, yaw, 0f));
        bool isGrounded = IsGrounded();

        Move();
        Jump();

        Debug.Log(isGrounded);
        //if (!isGrounded) {
            rb.AddForce(Vector3.down * extraGravity, ForceMode.Acceleration);
        //}

        void Move() {
            Vector3 inputDir = new Vector3(moveInput.x, 0f, moveInput.y);
            if (inputDir.sqrMagnitude > 1f) inputDir.Normalize();

            Vector3 moveDir = transform.TransformDirection(inputDir);
            moveDir *= Input.GetKey(KeyCode.LeftShift) ? runMultiplier : 1f;

            rb.velocity = new Vector3(
                moveDir.x * moveSpeed,
                rb.velocity.y,
                moveDir.z * moveSpeed
            );
        }

        void Jump() {
            if (jumpRequested && isGrounded) {
                rb.velocity += Vector3.up * jumpForce;
            }
            
            jumpRequested = false;
        }
    }

    private void LateUpdate() {
        AdjustPitch();

        void AdjustPitch() {
            if (cameraPivot != null) {
                cameraPivot.localEulerAngles = new Vector3(pitch, 0f, 0f);
            }
        }
    }

    private bool IsGrounded() {
        col.enabled = false;

        const float DISTANCE = .33f;
        Vector3 origin = transform.position;
        Ray ray = new Ray(origin, Vector3.down);
        Debug.DrawRay(origin, Vector3.down * DISTANCE, Color.red);
        bool isHit = Physics.Raycast(ray, DISTANCE);

        col.enabled = true;

        return isHit;
    }
}
