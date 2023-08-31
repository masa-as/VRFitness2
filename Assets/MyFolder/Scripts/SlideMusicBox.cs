using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlideMusicBox : MonoBehaviour
{
    public GameObject StartMarker, StartOut, StartOut2, End, End2;

    void Start()
    {

        Vector3[] path_L = new Vector3[]
        {
            StartMarker.transform.position,
            StartOut.transform.position,
            End.transform.position
        };

        Vector3[] path_R = new Vector3[]
        {
            StartMarker.transform.position,
            StartOut2.transform.position,
            End.transform.position
        };

        Vector3[] path_after = new Vector3[]
        {
            End.transform.position,
            End2.transform.position
        };

        if (gameObject.tag == "Right")
        {
            transform.DOPath(
                    path_R,
                    5f,
                    PathType.CatmullRom)
                        .SetEase(Ease.Linear)
                        .SetLookAt(0.05f, Vector3.forward)
                        .SetLink(gameObject)
                        .OnComplete(() => transform.DOPath(
                            path_after,
                            1f,
                            PathType.Linear).SetLink(gameObject));
        }
        else if (gameObject.tag == "Left")
        {
            transform.DOPath(
                    path_L,
                    5f,
                    PathType.CatmullRom)
                        .SetEase(Ease.Linear)
                        .SetLookAt(0.05f, Vector3.forward)
                        .SetLink(gameObject)
                        .OnComplete(() => transform.DOPath(
                            path_after,
                            1f,
                            PathType.Linear).SetLink(gameObject));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.z >= 7.5f)
        {
            Destroy(gameObject);
        }
    }
}
