using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMusicBox : MonoBehaviour
{
    GameObject obj_R;
    GameObject obj_L;
    [SerializeField] public float speed = 0.08f;

    private float distance_two;
    
    void Start()
    {
        obj_R = (GameObject)Resources.Load("Broken_Cube_Right");
        obj_L = (GameObject)Resources.Load("Broken_Cube_Left");

        distance_two = Vector3.Distance(new Vector3(0,1,0), new Vector3(0,1,5.5f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // float present_Location = (Time.time * speed) / distance_two;
        transform.Translate(0, 0, speed);
        // transform.position = Vector3.Slerp(new Vector3(0,1,0), new Vector3(0,1,5.5f), 10.0f);
        if (transform.position.z >= 5.5f)
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
            Destroy(gameObject);
        }
        else if (gameObject.tag == "Left")
        {
            Instantiate(obj_L, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}