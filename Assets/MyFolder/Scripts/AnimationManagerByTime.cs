using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationManagerByTime : MonoBehaviour
{
    GameObject timer;
    TimerScript timerScript;
    private Animator animator;



    void Start()
    {
        animator = GetComponent<Animator>();
        timer = GameObject.Find("Timer");
        timerScript = timer.GetComponent<TimerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerScript.elapsedTime < 3f
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jab")
            && !animator.IsInTransition(0)
        )
        {
            {
                Debug.Log(Time.deltaTime);
                Debug.Log("ss");
                // transform.Translate(0f, 0f, 0.1f);
                // transform.Translate(0f, 0f, Time.deltaTime * 2.31f);
                animator.SetTrigger("Jab");
            }
        }
        if (3f < timerScript.elapsedTime && timerScript.elapsedTime < 6f
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("Straight")
            && !animator.IsInTransition(0)
        )
        {
            {
                Debug.Log(Time.deltaTime);
                // transform.Translate(0f, 0f, Time.deltaTime * -0.21f);
                animator.SetTrigger("Straight");
            }
        }
        if (6f < timerScript.elapsedTime && timerScript.elapsedTime < 9f
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("OneTwo")
            && !animator.IsInTransition(0)
        )
        {
            {
                // transform.Translate(0f, 0f, Time.deltaTime * -0.01f);
                animator.SetTrigger("OneTwo");
            }
        }
        // if (11.5f < timerScript.elapsedTime)
        // {
        //     SceneManager.LoadScene("Result");
        // }
    }
}
