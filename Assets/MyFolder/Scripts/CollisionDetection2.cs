using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection2 : MonoBehaviour
{
    GameObject obj_R;
    GameObject obj_L;

    // Start is called before the first frame update
    void Start()
    {
        obj_L = (GameObject)Resources.Load("Broken_Cube_Left");
        obj_R = (GameObject)Resources.Load("Broken_Cube_Right");

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        Debug.Log(CollisionDetection.out_flag);
        if (CollisionDetection.out_flag)
        {
            if (collision.gameObject.tag == "HandLeft" || collision.gameObject.tag == "HandRight")
            {
                if (transform.parent.gameObject.tag == "Left")
                {
                    Instantiate(obj_L, gameObject.transform.position, Quaternion.identity);
                    Destroy(transform.parent.gameObject);
                }
                else if (transform.parent.gameObject.tag == "Right")
                {
                    Instantiate(obj_R, gameObject.transform.position, Quaternion.identity);
                    Destroy(transform.parent.gameObject);
                }
            }
        }
    }
}
