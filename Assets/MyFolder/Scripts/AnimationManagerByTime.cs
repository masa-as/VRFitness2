using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class AnimationManagerByTime : MonoBehaviour
{
    private Animator animator;

    public GameObject unitychan;

    private Vector3 worldAngle;

    void Start()
    {
        animator = GetComponent<Animator>();
        unitychan = GameObject.Find("unitychan");
        worldAngle = unitychan.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = GameManager._elapsedTime;
        if (elapsedTime < 3f)
        {
            {
                animator.SetTrigger("Idle");
            }
        }
        if (3f < elapsedTime && elapsedTime < 6f
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")
            && !animator.IsInTransition(0)
        )
        {
            {
                transform.DORotate(new Vector3(0, 77, 0), 1f);
                // worldAngle.y = 77;
                // unitychan.transform.eulerAngles = worldAngle;
                animator.SetTrigger("Jab");
            }
        }
        if (6f < elapsedTime && elapsedTime < 12f
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("Straight")
            && !animator.IsInTransition(0)
        )
        {
            {
                transform.DORotate(new Vector3(0, 0, 0), 1f);
                // worldAngle.y = 0;
                // unitychan.transform.eulerAngles = worldAngle;
                animator.SetTrigger("Straight");
            }
        }
        if (12f < elapsedTime
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("OneTwo")
            && !animator.IsInTransition(0)
        )
        {
            {
                animator.SetTrigger("OneTwo");
            }
        }
        // if (15f < elapsedTime)
        // {
        //     SceneManager.LoadScene("Result");
        // }
    }
}
