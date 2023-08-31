using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject obj;
    // private float _repeatSpan = 1;    //繰り返す間隔
    [SerializeField] public static float _elapsedTime = 0;   //経過時間

    [SerializeField]
    private string _csvPath;
    private List<Note> _notes = new List<Note>();

    private int _noteID = 0;

    //レーンごとに飛ばすオブジェクトを変えるので、その分保持
    [SerializeField]
    private GameObject[] _items;

    //楽曲再生用、一番大事
    private AudioSource _source;

    //プレイしてるかどうかの確認
    private bool _isPlaying = true;


    // Start is called before the first frame update
    void Start()
    {
        Load();
    }



    // Update is called once per frame    
    private void FixedUpdate()
    {
        _elapsedTime += Time.deltaTime;     //時間をカウントする
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
            if (_notes[_noteID].Timing < _elapsedTime)
            {
                GenerateNote(_notes[_noteID]);
                _noteID++;
            }
        }
        else
        {
            GameEnd();
            _isPlaying = false;
        }
    }

    /// <summary>
    /// ノーツを生成する
    /// </summary>
    /// <param name="note">該当ノーツクラスを転送してくる</param>
    private void GenerateNote(Note note)
    {
        //生成と同時に初期化
        Instantiate(_items[note.Lane]);
    }

    private void GameEnd()
    {
        //無駄にノーツ探索させないためにフラグをたたむ
        _isPlaying = false;
        StartCoroutine(GoResult());
    }

    public static IEnumerator GoResult()
    {
        //指定された時間待つ
        yield return new WaitForSeconds(8f);

        SceneManager.LoadScene("Result");
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
