
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header ("Basics")]
    public Camera mainCamera;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;

    [Header ("Inputs")]
    public InputActionReference move;
    public InputActionReference aim;
    public InputActionReference jump;

    [Header ("Move")]
    private Vector2 moveDirection;

    [Header ("Aim")]
    private Vector2 aimDirection;
    public GameObject cannon;
    Vector3 mouseWorldPos;
    Vector2 direction;
    private float angle;

    [Header ("Jump")]
    public IsFloor ground;
    public float jumpForce = 5f;
    
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
        Move();

        if (ground.isFloor)
        {
            
            if (jump.action.IsPressed())
            {
                Debug.Log("sexo");
                Jump();
            }
        }
    }
    
    private void Move()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, 0);
    }

    private void Aim()
    {
        
        mouseWorldPos = mainCamera.ScreenToWorldPoint(aimDirection);
        mouseWorldPos.z = 0f;
        direction = mouseWorldPos - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        cannon.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void Jump()
    {
       rb.AddForce(Vector2.up * jumpForce*Time.deltaTime, ForceMode2D.Impulse);
    }

    
    
}
