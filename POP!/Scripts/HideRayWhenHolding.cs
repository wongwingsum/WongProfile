using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactors.Visuals;

public class HideRayWhenHolding : MonoBehaviour
{
    [SerializeField]
    private XRBaseInteractor interactor;
    [SerializeField]
    private LineRenderer lineVisual;

    private void Awake()
    {
        interactor = GetComponent<XRBaseInteractor>();

        interactor.selectEntered.AddListener(OnGrabbed);
        interactor.selectExited.AddListener(OnReleased);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        //lineVisual.gameObject.SetActive(false);
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        lineVisual.gameObject.SetActive(true);
    }
}
