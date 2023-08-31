using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class VoiceManager : MonoBehaviour
{
    private int _noteID = 0;

    private List<Note> _notes = new List<Note>();

    //プレイしてるかどうかの確認
    private bool _isPlaying = true;

    public List<AudioClip> voices = new List<AudioClip>();

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(voices[7]);
        _notes = GameManager._notes;
    }


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
            /* ノーツ生成ロジック
             * 保持してるタイミング情報は楽曲再生時間でのジャストなので
             * アニメーションする用のオフセット分を引いて早めに生成する
             * 規模が大きくなった時のために時間は他の場所で管理するのがいい
             */
            if (_notes[_noteID].Timing + 4.0f < elapsedTime)
            {
                audioSource.PlayOneShot(voices[_notes[_noteID].Lane]);
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
        StartCoroutine(FinishVoice());
    }

    public IEnumerator FinishVoice()
    {
        //指定された時間待つ
        yield return new WaitForSeconds(2f);
        Debug.Log("voice");
        audioSource.PlayOneShot(voices[6]);
    }
}
