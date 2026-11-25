using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Timer : MonoBehaviour
    {
    [SerializeField]
    public float currentTime = 60.0f;
    public TMP_Text timerText = null;
    [SerializeField]
    private PlayerScore resutlScore;
    [SerializeField]
    private TMP_Text scoreText;
    private bool isFinished = false;

    [SerializeField, Header("Finish Event")]
    private GameObject finishPannal;

    void Awake()
    {
        // テキスト表示
        if (timerText)
        {
            timerText.text = currentTime.ToString("F0");
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (currentTime > 0.0f)
        {
            currentTime -= Time.deltaTime;
            // テキスト表示
            if (timerText)
            {
                timerText.text = currentTime.ToString("F0");
            }

        }
        else if (currentTime < 0.0f) // 0を下回った瞬間1回だけ呼ぶ
        {
            currentTime = 0.0f;
            // テキスト表示
            if (timerText)
            {
                timerText.text = currentTime.ToString("F0");
            }
        }

        // タイマーが0以下になった場合の処理
        if (currentTime <= 0.0f&& !isFinished)
        {
            isFinished = true;
            if (finishPannal)
            {
                finishPannal.SetActive(true);
            }
            if (resutlScore && scoreText)
            {
                resutlScore.score = scoreText.text;
            }
        }
    }
}
