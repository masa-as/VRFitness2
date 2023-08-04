using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMusicBox : MonoBehaviour
{
    GameObject obj_R;
    GameObject obj_L;
    [SerializeField] public float speed = 0.08f;


    void Start()
    {
        obj_R = (GameObject)Resources.Load("Broken_Cube_Right");
        obj_L = (GameObject)Resources.Load("Broken_Cube_Left");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(0, 0, speed);
        if (transform.position.z >= 6)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("当たった!");
        if (gameObject.tag == "Right")
        {
            Instantiate(obj_R, gameObject.transform.position, Quaternion.identity);
        }
        else if (gameObject.tag == "Left")
        {
            Instantiate(obj_L, gameObject.transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}