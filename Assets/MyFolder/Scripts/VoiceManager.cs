using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class VoiceManager : MonoBehaviour
{
    [SerializeField]
    private string _csvPath;

    private int _noteID = 0;

    private List<Note> _notes = new List<Note>();

    //プレイしてるかどうかの確認
    private bool _isPlaying = true;

    public List<AudioClip> voices = new List<AudioClip>();

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Load();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(voices[7]);

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
        // Debug.Log(_notes.Count);
        // Debug.Log(_noteID);
        // Debug.Log(_elapsedTime);
        //ノーツを最後まで生成したらゲーム終了
        if (_noteID < _notes.Count)
        {
            /* ノーツ生成ロジック
             * 保持してるタイミング情報は楽曲再生時間でのジャストなので
             * アニメーションする用のオフセット分を引いて早めに生成する
             * 規模が大きくなった時のために時間は他の場所で管理するのがいい
             */
            if (_notes[_noteID].Timing + 3.5f < elapsedTime)
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

    private void Load()
    {
        //譜面データの中身を引っ張ってくる
        var csv = Resources.Load(_csvPath) as TextAsset;
        var reader = new StringReader(csv.text);

        //ロード
        while (reader.Peek() > -1)
        {
            /* 譜面データの中身は1行が1ノーツ
             * 1列目がタイミング情報
             * 2列めがレーン情報
             * ノーツを新規宣言してそれぞれデータを入れたあとに
             * ノーツリストに追加してループを出る
             */
            string row = reader.ReadLine();
            string[] values = row.Split(',');
            var n = new Note();
            n.Timing = float.Parse(values[0]);
            n.Lane = int.Parse(values[1]);

            _notes.Add(n);

        }
    }
}
