using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractorSwitcher : MonoBehaviour
{
    public XRRayInteractor rayInteractor;  
    public XRDirectInteractor directInteractor;
    public InputHelpers.Button switchButton = InputHelpers.Button.PrimaryButton; // Example: A button on Quest

    private XRController controller;

    void Start()
    {
        controller = GetComponent<XRController>();
    }

    void Update()
    {
        if (controller.inputDevice.IsPressed(switchButton, out bool pressed) && pressed)
        {
            bool isRayActive = rayInteractor.enabled;
            rayInteractor.enabled = !isRayActive;
            directInteractor.enabled = isRayActive;
        }
    }
}
