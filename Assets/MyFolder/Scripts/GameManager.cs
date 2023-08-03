using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject obj;
    private float _repeatSpan = 1;    //繰り返す間隔
    private float _timeElapsed;   //経過時間

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame    
    private void FixedUpdate()
    {
        _timeElapsed += Time.deltaTime;     //時間をカウントする
        if (_timeElapsed >= _repeatSpan)
        {
            int rnd_model = Random.Range(0, 2);
            // rnd_model = 1;
            float position_x = 0.0f;
            if (rnd_model == 0)
            {
                obj = (GameObject)Resources.Load("Cube_Left");
                position_x = 0.2f;
            }
            else if (rnd_model == 1)
            {
                obj = (GameObject)Resources.Load("Cube_Right");
                position_x = -0.2f;
            }
            Vector3 instantiate_postion = new Vector3(position_x, 1.0f, 0.0f);

            Instantiate(obj, instantiate_postion, Quaternion.identity);
            _timeElapsed -= _repeatSpan;   //経過時間を減らす

        }
    }
}
