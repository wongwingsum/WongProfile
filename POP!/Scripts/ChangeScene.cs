using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    public enum SceneName
    {
        None,
        Title,
        Rule,
        Game,
        Result
    }

    [SerializeField]
    private SceneName m_scene = SceneName.None;

    [SerializeField]
    private Image m_fade;
    [SerializeField]
    private bool m_fadeOut;
    [SerializeField]
    private UnityEvent onFadeOutFinished;

    void Start()
    {
        if(m_fadeOut)
        {
            StartCoroutine(FadeOut());
        }
    }
    void Update()
    {

    }

    public void AutoChangeSceneTo()
    {
        if(m_scene == SceneName.None)
        {
            Debug.LogError("Scene is not set.");
            return;
        }
        StartCoroutine(FadeAndLoad(m_scene.ToString()));
    }

    public void ManualChangeSceneTo(string scene)
    {
        StartCoroutine(FadeAndLoad(scene));
    }

    IEnumerator FadeAndLoad(string sceneName)
    {
        yield return StartCoroutine(FadeIn());

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeIn()
    {
        float duration = 1f;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            Color c = m_fade.color;
            c.a = Mathf.Lerp(0f, 1f, t / duration);
            m_fade.color = c;
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        float duration = 1f;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            Color c = m_fade.color;
            c.a = Mathf.Lerp(1f, 0f, t / duration);
            m_fade.color = c;
            yield return null;
        }

        onFadeOutFinished?.Invoke();
    }
}
