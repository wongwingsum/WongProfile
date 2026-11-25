using System.Text.RegularExpressions;
using UnityEngine;
/// <summary>
/// ターゲット（ボール）を浮かせる処理
/// </summary>
[RequireComponent (typeof(CapsuleCollider))]
public class Wind : MonoBehaviour
{
    [SerializeField, Header("上昇する力")]
    private float risingForce;
    [SerializeField, Header("吸い寄せる力")]
    private float attractForce;

    private CapsuleCollider ownCollider;
    private float maxWindHeight;    //最大風の長さ

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ownCollider = GetComponent<CapsuleCollider> ();
        float maxWindHeight = ownCollider.height;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Target targetController = other.gameObject.GetComponent<Target>();
        if (targetController.isThrowed) { return; }

        Rigidbody target = other.GetComponent<Rigidbody>();
        if (target != null)
        {
    ///上昇力の計算
    
            // 噴射口からの高さを計算する
            Vector3 targetLocalPos = transform.InverseTransformPoint(other.transform.position);

            // カプセルの「一番底（最下点）」からのボールの高さを割り出す
            float targetHeight = targetLocalPos.y + (maxWindHeight / 2.0f);

            // 高さの割合
            // 底にいるときは 1.0（最強）、てっぺんにいるときは 0.0（無風）
            float percent = 1.0f - (targetHeight / maxWindHeight);
            percent = Mathf.Clamp01(percent);

            Vector3 risingVector = ownCollider.transform.up * risingForce * percent;

    ///中心への引力の計算

            // ローカル座標上で、中心軸（Y軸）からどれだけ離れているか（水平距離）を計算
            Vector3 localHorizontalOffset = new Vector3(targetLocalPos.x, 0, targetLocalPos.z);
            float distanceFromAxis = localHorizontalOffset.magnitude; // 中心軸からの距離

            // 引力の方向（ワールド座標に変換）
            Vector3 localAttractDirection = -localHorizontalOffset.normalized;
            Vector3 worldAttractDirection = transform.TransformDirection(localAttractDirection);

            float targetSpeed = target.linearVelocity.magnitude;    //ボールの移動速度
           
            //コアンダ引き寄せ力
            Vector3 attractVector = attractForce * 
                (targetSpeed * targetSpeed / (ownCollider.radius + targetHeight)) * 
                worldAttractDirection;

    ///最終的の力
            target.AddForce(risingVector + attractVector, ForceMode.Force);
        }
    }


}
