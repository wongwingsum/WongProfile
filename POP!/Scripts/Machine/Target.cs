using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Target : MonoBehaviour
{
    private Collider ownCollider;
    private Rigidbody ownRigidbody;
    public string muzzleTag;
    //投げる関連
    [SerializeField, Header("投げられた判定のカウント")]
    private const float isThrowedTime = 0.5f;
    private float isThrowedCount = 0.0f;
    public bool isThrowed = false;
    public bool isGoaled = false;
    //マテリアル関連
    [SerializeField]
    private Material materialWhenHold;
    private Material originalMaterial;
    [SerializeField]
    private MeshRenderer ownMeshRenderer;
    [SerializeField, Header("投げる強さの倍率")]
    private float throwForceMultiplier = 1.2f;

    private XRBaseInteractable interactable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ownCollider = GetComponent<Collider>();
        ownRigidbody = GetComponent<Rigidbody>();
        interactable = GetComponent<XRBaseInteractable>();
        originalMaterial = ownMeshRenderer.material;
        interactable.selectEntered.AddListener(OnHold);
        interactable.selectExited.AddListener(OnRelease);
    }



    // Update is called once per frame
    void Update()
    {
        if(isThrowed)
        {
            isThrowedCount+=Time.deltaTime;
            if (isThrowedCount >= isThrowedTime)
            {
                isThrowed = false;
                isThrowedCount = 0.0f;
                ownMeshRenderer.material = originalMaterial;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(muzzleTag))
        {
            ownCollider.isTrigger = false;
        }
    }

    private void OnHold(SelectEnterEventArgs args)
    {
        ownMeshRenderer.material = materialWhenHold;
    }


    private void OnRelease(SelectExitEventArgs args)
    {
        isThrowed = true;
    }
}
