using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator playerAnimator;

    public PlayerMovement playerMovementScript;
    public PlayerCasting playerCastingScript;

    public Vector2 input;

    public bool isMoving;
    public bool isRodOut;
    public bool isRodIn;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input = playerMovementScript.directionalInput;
        isMoving = input != Vector2.zero;
        isRodOut = playerCastingScript.isRodOut;
        isRodIn = playerCastingScript.isRodIn;

        if (playerAnimator)
        {
            if (isMoving)
            {
                playerAnimator.SetFloat("MoveX", input.x);
                playerAnimator.SetFloat("MoveY", input.y);
                playerAnimator.SetBool("IsMoving", isMoving);
            }
            else
            {
                playerAnimator.SetBool("IsMoving", isMoving = false);
            }

            if (!isMoving && playerCastingScript.isRodOut)
            {
                playerAnimator.SetBool("IsRodOut", playerCastingScript.isRodOut);
                playerAnimator.SetBool("IsRodIn", playerCastingScript.isRodIn);

            }
        }
    }
}
