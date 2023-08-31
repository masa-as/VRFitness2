using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class AnimationManagerByTime : MonoBehaviour
{
    private int _noteID = 0;

    private List<Note> _notes = new List<Note>();

    //プレイしてるかどうかの確認
    private bool _isPlaying = true;

    private Animator animator;

    public GameObject unitychan;

    void Start()
    {
        animator = GetComponent<Animator>();
        unitychan = GameObject.Find("unitychan");
        _notes = GameManager._notes;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlaying)
        {
            SearchNote();
        }
    }
    private void SearchNote()
    {
        float elapsedTime = GameManager._elapsedTime;
        //ノーツを最後まで生成したらゲーム終了
        if (_noteID < _notes.Count)
        {
            Debug.Log("test2");
            Debug.Log(_notes[_noteID].Lane);
            Debug.Log(_notes[_noteID].Timing);
            Debug.Log(elapsedTime);

            /* ノーツ生成ロジック
             * 保持してるタイミング情報は楽曲再生時間でのジャストなので
             * アニメーションする用のオフセット分を引いて早めに生成する
             * 規模が大きくなった時のために時間は他の場所で管理するのがいい
             */
            if (_notes[_noteID].Timing + 4.0f < elapsedTime)
            {
                Debug.Log(_notes[_noteID].Lane);
                switch (_notes[_noteID].Lane)
                {
                    case 0:
                        transform.DORotate(new Vector3(0, 77, 0), 1f);
                        animator.SetTrigger("Jab");
                        break;
                    case 1:
                        animator.SetTrigger("Hook");
                        break;
                    case 3:
                        transform.DORotate(new Vector3(0, 0, 0), 1f);
                        animator.SetTrigger("Straight");
                        break;
                    case 5:
                        animator.SetTrigger("Upper");
                        break;
                }
                _noteID++;

            }
        }
        else
        {
            GameEnd();
            _isPlaying = false;
        }
    }

    private void GameEnd()
    {
        //無駄にノーツ探索させないためにフラグをたたむ
        _isPlaying = false;
    }
}
