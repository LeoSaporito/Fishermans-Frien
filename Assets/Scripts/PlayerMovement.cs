using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public enum MovementState
    {
        Idle,
        MovingHorizontal,
        MovingVertical,
    }

    public MovementState currentState;

    public float moveSpeed;
    public Vector2 directionalInput;

    Rigidbody2D rb;

    public PlayerCasting playerCastingScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCastingScript = GetComponent<PlayerCasting>();
    }
    void FixedUpdate()
    {
        switch (currentState)
        {
            case MovementState.MovingHorizontal:
                rb.linearVelocity = new Vector2(moveSpeed * directionalInput.x, 0);
                break;
            case MovementState.MovingVertical:
                rb.linearVelocity = new Vector2(0, moveSpeed * directionalInput.y);
                break;
            case MovementState.Idle:
                rb.linearVelocity = Vector2.zero;
                break;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        directionalInput = context.ReadValue<Vector2>();

        if (directionalInput.x != 0)
        {
            currentState = MovementState.MovingHorizontal;
            directionalInput = new Vector2(Mathf.Sign(directionalInput.x), 0);
        }
        else if (directionalInput.y != 0)
        {
            currentState = MovementState.MovingVertical;
            directionalInput = new Vector2(0, Mathf.Sign(directionalInput.y));
        }
        else
        {
            currentState = MovementState.Idle;
            directionalInput = Vector2.zero;
        }        
    }
}
