
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public InputAction playerController;

    Vector2 moveDirection = Vector2.zero;

    private void OnEnable()
    {
        playerController.Enable();
    }

    private void OnDisable()
    {
        playerController.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveDirection = playerController.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, 0);
    }
}
