using Unity.VisualScripting.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputManagerSO inputManager;
    [SerializeField] private float walkSpeed;

    private Rigidbody2D rb;
    private Vector2 inputVector;

    private void OnEnable()
    {
        inputManager.OnMove += Move;
    }
    private void OnDisable()
    {
        inputManager.OnMove -= Move;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(inputVector.x * walkSpeed, inputVector.y * walkSpeed);
    }

    private void Move(Vector2 ctx)
    {
        inputVector = new Vector2(ctx.x, ctx.y);    
    }

}
