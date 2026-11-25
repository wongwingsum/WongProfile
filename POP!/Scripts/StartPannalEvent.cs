using UnityEngine;

public class StartPannalEvent : MonoBehaviour
{
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private ShootTarget shootTarget;

    private void Awake()
    {
        GetComponent<Animator>().enabled = false;

        timer.enabled = false;
        shootTarget.enabled =false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAnimation()
    {
        GetComponent<Animator>().enabled = true;
    }

    void StartGame()
    {
        timer.enabled = true;
        shootTarget.enabled = true;
    }
}
