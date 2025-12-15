using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class miau : MonoBehaviour
{
    private InputSystem_Actions inputActions; 

    private Vector2 mouseInput;

    [SerializeField] private Transform pivot;

    private Vector2 dir;
    private float angle;



    private void Awake()
    {
        inputActions = new InputSystem_Actions();

        mouseInput = inputActions.Player.Look.ReadValue<Vector2>();
        inputActions.Player.Attack.performed += OnAttack;

    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("ATAQUE!");
    }

    private void Aim()
    {
        pivot.rotation
    }


}
