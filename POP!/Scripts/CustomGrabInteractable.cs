using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class CustomGrabInteractable : MonoBehaviour
{
    private Rigidbody rb;
    private XRGrabInteractable grab;
    [SerializeField] private float throwPowerMultiplier = 1.0f; //  ìäÇ∞ÇÈéûÇÃÉpÉèÅ[í≤êÆ

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grab = GetComponent<XRGrabInteractable>();

        grab.selectExited.AddListener(OnReleased);
    }


    private void OnReleased(SelectExitEventArgs args)
    {
        float power = rb.linearVelocity.magnitude;

        Transform attachTransform =
            args.interactorObject.GetAttachTransform(grab);


        Vector3 throwDir = (
                        attachTransform.forward * 0.4f +
                         Camera.main.transform.forward * 0.6f
                        ).normalized;




        rb.linearVelocity = throwDir * power * throwPowerMultiplier;


    }

}