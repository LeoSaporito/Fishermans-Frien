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
    Vector2 playerPosition;
    public Vector2 directionalInput;

    void Start()
    {

    }
    void Update()
    {
        playerPosition = transform.position;

        switch (currentState)
        {
            case MovementState.MovingHorizontal:
                playerPosition.x += moveSpeed * Time.deltaTime * directionalInput.x;
                break;
            case MovementState.MovingVertical:
                playerPosition.y += moveSpeed * Time.deltaTime * directionalInput.y;
                break;
            case MovementState.Idle:
                break;
        }

        transform.position = playerPosition;
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
