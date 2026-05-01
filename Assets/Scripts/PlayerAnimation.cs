using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator playerMovementAnimator;

    public PlayerMovement playerMovementScript;

    public Vector2 input;

    public bool isMoving;
    public bool isNotMoving;

    void Start()
    {
        playerMovementAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input = playerMovementScript.directionalInput;
        isMoving = input != Vector2.zero;

        if (playerMovementAnimator)
        {
            if (isMoving)
            {
                playerMovementAnimator.SetFloat("MoveX", input.x);
                playerMovementAnimator.SetFloat("MoveY", input.y);
                playerMovementAnimator.SetBool("IsMoving", isMoving);
            }
            else
            {
                playerMovementAnimator.SetBool("IsMoving", isMoving = false);
            }
        }
    }
}
