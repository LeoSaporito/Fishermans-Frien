using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public PlayerMovement playerMovementScript;
    public Animator playerAnimator;

    void Start()
    {
        playerMovementScript = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (playerMovementScript.currentState == PlayerMovement.MovementState.MovingVertical)
        {
            playerAnimator.SetFloat("MoveY", playerMovementScript.directionalInput.y);
        }
        if (playerMovementScript.currentState == PlayerMovement.MovementState.MovingHorizontal)
        {
            playerAnimator.SetFloat("MoveX", playerMovementScript.directionalInput.x);
        }
        if (playerMovementScript.currentState == PlayerMovement.MovementState.Idle)
        {
            playerAnimator.SetFloat("MoveY", playerMovementScript.directionalInput.y);
            playerAnimator.SetFloat("MoveX", playerMovementScript.directionalInput.x);
        }
    }
}
