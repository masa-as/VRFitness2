using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    // ポーズした時に表示するUI
    [SerializeField]
    public GameObject pauseUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)|| OVRInput.GetDown(OVRInput.RawButton.X))
        {
            // ポーズUIのアクティブ、非アクティブを切り替え
            pauseUI.SetActive(!pauseUI.activeSelf);

            // ポーズUIが表示されてる時は停止
            if (pauseUI.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
        // ポーズ時にセレクトを押したらタイトルへ
        // if (pauseUI.activeSelf)
        // {
        //     if (Input.GetButtonDown("Select"))
        //     {
        //         SceneManager.LoadScene("title");
        //         Time.timeScale = 1f;
        //     }
        // }
    }
}