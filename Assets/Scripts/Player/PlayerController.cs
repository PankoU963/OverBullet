
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Camera mainCamera;

    private Rigidbody2D rb;
    public float moveSpeed = 5f;

    public InputActionReference move;
    public InputActionReference aim;
    public InputActionReference jump;

    private Vector2 moveDirection;

    private Vector2 aimDirection;
    Vector3 mouseWorldPos;
    Vector2 direction;
    private float angle;

    public BoxCollider2D floor;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        moveDirection = move.action.ReadValue<Vector2>();
        aimDirection = aim.action.ReadValue<Vector2>();
        Aim();
        
    }
    
    void FixedUpdate()
    {
        
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, 0);    
    }

    
    private void Aim()
    {
        
        mouseWorldPos = mainCamera.ScreenToWorldPoint(aimDirection);
        mouseWorldPos.z = 0f;
        direction = mouseWorldPos - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void Jump()
    {
        
    }
    
}
