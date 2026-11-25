using NUnit.Framework;
using UnityEngine;
/// <summary>
/// ターゲット（ボール）を発射する処理
/// </summary>
public class ShootTarget : MonoBehaviour
{
    [SerializeField]
    private Collider targetFactory;
    [SerializeField]
    private TargetManager targetManager;
    [SerializeField]
    private GameObject targetPrefab;
    [SerializeField]
    private float createTime;
    [SerializeField]
    private float maxTarget;
    [SerializeField]
    private float shootForce;

    private float elapsedTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        //ターゲット発射
        if(targetManager.targetList.Count < maxTarget && elapsedTime >= createTime)
        {
            elapsedTime = 0.0f;
            GameObject target = Instantiate(targetPrefab, targetFactory.transform);
            targetManager.targetList.Add(target);
            target.GetComponent<Rigidbody>().AddForce(this.transform.up * shootForce, ForceMode.Impulse);
        }
    }
}
