using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMusicBox : MonoBehaviour
{
    GameObject obj;
    [SerializeField] public float speed = 0.08f;


    void Start()
    {
        obj = (GameObject)Resources.Load("Explosion7");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(0, 0, speed);
        if (transform.position.z >= 5)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("当たった!");
            Instantiate(obj, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}