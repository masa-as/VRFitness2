using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlideMusicBox : MonoBehaviour
{
    GameObject obj_R;
    GameObject obj_L;

    public GameObject StartMarker, StartOut, StartOut2, End;


    public Vector3[] path;
    public Vector3[] path2;

    void Start()
    {
        obj_R = (GameObject)Resources.Load("Broken_Cube_Right");
        obj_L = (GameObject)Resources.Load("Broken_Cube_Left");

        Vector3[] path_L = new Vector3[]
        {
            StartMarker.transform.position,
            StartOut.transform.position,
            End.transform.position
            // new Vector3(2, 1, 2.5f),new Vector3(0,1,6)
        };

        Vector3[] path_R = new Vector3[]
        {
            StartMarker.transform.position,
            StartOut2.transform.position,
            End.transform.position
            // new Vector3(2, 1, 2.5f),new Vector3(0,1,6)
        };

        if (gameObject.tag == "Right")
        {
            transform.DOPath(
                    path_R,
                    5f,
                    PathType.CatmullRom)
                        .SetLookAt(0.05f, Vector3.forward)
                        .SetLink(gameObject);
        }
        else if (gameObject.tag == "Left")
        {
            transform.DOPath(
                    path_L,
                    5f,
                    PathType.CatmullRom)
                        .SetLookAt(0.05f, Vector3.forward)
                        .SetLink(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // float present_Location = (Time.time * speed) / distance_two;
        // transform.Translate(0, 0, speed);
        // transform.position = Vector3.Slerp(new Vector3(0,1,0), new Vector3(0,1,5.5f), 10.0f);
        if (transform.position.z >= 5.5f)
        {
            Destroy(gameObject);
        }
    }

    public static IEnumerator Vibrate(float duration = 0.1f, float frequency = 0.1f, float amplitude = 0.1f, OVRInput.Controller controller = OVRInput.Controller.Active)
    {
        //コントローラーを振動させる
        OVRInput.SetControllerVibration(frequency, amplitude, controller);

        //指定された時間待つ
        yield return new WaitForSeconds(duration);

        //コントローラーの振動を止める
        OVRInput.SetControllerVibration(0, 0, controller);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("当たった!");
        if (gameObject.tag == "Right")
        {
            Instantiate(obj_R, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (gameObject.tag == "Left")
        {
            Instantiate(obj_L, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        // if (collision.gameObject.tag == "Right")
        // {
        //     StartCoroutine(Vibrate(duration: 0.02f, controller: OVRInput.Controller.RTouch));
        // }
        // else if (collision.gameObject.tag == "Left")
        // {
        //     StartCoroutine(Vibrate(duration: 0.03f, controller: OVRInput.Controller.LTouch));
        // }
    }
}