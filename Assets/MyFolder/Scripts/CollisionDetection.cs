using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    GameObject obj_R;
    GameObject obj_L;

    public static bool out_flag = false;

    // Start is called before the first frame update
    void Start()
    {
        obj_L = (GameObject)Resources.Load("Broken_Cube_Left");
        obj_R = (GameObject)Resources.Load("Broken_Cube_Right");

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "HandLeft" || collision.gameObject.tag == "HandRight")
        {
            out_flag = true;
        }
    }
}
