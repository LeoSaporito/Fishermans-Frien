using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCasting : MonoBehaviour
{
    public bool isRodOut;
    public bool isRodIn;

    public GameObject hook;
    private GameObject hookSpawned;

    public float hookCastingDuration;
    public float hookCastingProgress;
    public float hookSpeed;

    private Vector2 startPosition;
    private Vector2 endPosition;
    public Vector2 currentPosition;

    public float currentPower;
    public float maxPower;
    public float castingSpeed;

    public bool isCasting;

    public Coroutine hookCastingCoroutine;

    public Animator playerCastAnimator;
    void Start()
    {
        isRodIn = true;
    }

    void Update()
    {
        if (isCasting)
        {
            currentPower += Time.deltaTime * castingSpeed;

            currentPower = Mathf.Clamp(currentPower, 0f, maxPower);
        }
    }

    public void OnCast(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            isCasting = true;
            currentPower = 0f;
        }

        if (context.canceled)
        {
            isRodOut = !isRodOut;
            isRodIn = !isRodIn;

            isCasting = false;

            playerCastAnimator.SetBool("IsRodOut", isRodOut);
            playerCastAnimator.SetTrigger("Cast");
        }
    }

    public void AnimationEvent_SpawnHook()
    {
        hookSpawned = Instantiate(hook, transform.position, Quaternion.identity);

        hookCastingProgress = 0f;
        hookCastingCoroutine = StartCoroutine(HookCastingUpdate());
    }

    public IEnumerator HookCastingUpdate()
    {
        startPosition = transform.position;
        endPosition = startPosition + Vector2.down * currentPower;

        while (hookCastingProgress < hookCastingDuration)
        { 
            hookCastingProgress += Time.deltaTime;
            float hookCastedTime = currentPower / hookCastingDuration;

            hookSpawned.transform.position = Vector2.Lerp(startPosition, endPosition, hookCastedTime);
            
            yield return null;
        }
    }
}
