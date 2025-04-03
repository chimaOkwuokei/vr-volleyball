using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class InteractorSwitcher : MonoBehaviour
{
    public XRRayInteractor rayInteractor;  
    public XRDirectInteractor directInteractor;
    public InputActionProperty switchAction; // Action-based input

    private void Update()
    {
        if (switchAction.action.WasPressedThisFrame()) // Action-based input check
        {
            bool isRayActive = rayInteractor.enabled;
            rayInteractor.enabled = !isRayActive;
            directInteractor.enabled = isRayActive;
        }
    }
}
