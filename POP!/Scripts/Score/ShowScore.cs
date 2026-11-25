using System.Drawing;
using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    [SerializeField]
    private PlayerScore resultScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(resultScore)
        {
            TMP_Text scoreText = GetComponent<TMP_Text>();
            scoreText.text = resultScore.score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
