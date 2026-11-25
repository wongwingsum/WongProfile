using UnityEngine;
/// <summary>
/// ターゲット（ボール）回収処理
/// </summary>

public class TargetCollector : MonoBehaviour
{
    [SerializeField]
    private float force = 5.0f;
    [SerializeField]
    private Collider destroyCollider;
    [SerializeField]
    private TargetManager targetManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //消す判定当たった場合
        if (destroyCollider.bounds.Intersects(other.bounds))
        {
            targetManager.targetList.Remove(other.gameObject);
            Destroy(other.gameObject);
            return;
        }

        if (other.CompareTag("Target"))
        {
            Rigidbody targetRb = other.GetComponent<Rigidbody>();
            if (targetRb == null) return;

            Vector3 direction = this.transform.position - other.gameObject.transform.position;

            targetRb.AddForce(direction.normalized * force, ForceMode.Force);
        }
    }
}
