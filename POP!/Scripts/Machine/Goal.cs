using System.Collections;
using TMPro;
using UnityEngine;
/// <summary>
/// ターゲット（ボール）がゴールに当たった処理
/// </summary>
public class Goal : MonoBehaviour
{
    [SerializeField, Tooltip("毎秒回転する角度")]
    private float degree = -20.0f;
    [SerializeField]
    private bool root = false;
    [SerializeField]
    private int point = 10;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private Timer timer;

    [SerializeField, Header("Blink")]
    private Material materialWhenBlink;
    private Material originalMaterial;
    [SerializeField]
    private MeshRenderer ownMeshRenderer;
    private bool materialChangeFlag = false;
    [SerializeField]
    private float blinkInterval = 0.2f;     //点滅の間隔（秒）
    [SerializeField]
    private float blinkTimer = 2.0f;          //点滅のタイマー

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalMaterial = ownMeshRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (root)
        {
            this.transform.Rotate(Vector3.up * degree * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(timer.currentTime <= 0.0f) { return; }

        if(other.CompareTag("Target"))
        {
            Target target = other.GetComponent<Target>();
            if (!target || !(target.isThrowed)) return;
            if(target.isGoaled) return;

            string textString = scoreText.text;
            int currentScore = int.Parse(textString);
            currentScore += point;
            scoreText.text = currentScore.ToString();
            target.isGoaled = true;

            StartCoroutine("Blinking");
        }
    }

    IEnumerator Blinking()
    {
        float elapsed = 0f;

        while (elapsed < blinkTimer)
        {
            materialChangeFlag = !materialChangeFlag;

            ownMeshRenderer.material =
                materialChangeFlag ? materialWhenBlink : originalMaterial;

            yield return new WaitForSeconds(blinkInterval);

            elapsed += blinkInterval;
        }

        ownMeshRenderer.material = originalMaterial;
    }

}


