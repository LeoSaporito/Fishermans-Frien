using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCasting : MonoBehaviour
{
    public bool isRodOut;
    public bool isRodIn;
    void Start()
    {
        isRodIn = true;
    }

    void Update()
    {
        if (isRodOut)
        { 
        
        }
    }

    public void OnCast(InputAction.CallbackContext context)
    {
        isRodOut = !isRodOut;
        isRodIn = !isRodIn;
    }
}
