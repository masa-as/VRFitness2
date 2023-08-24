using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationController : MonoBehaviour
{
    public static IEnumerator Vibrate(float duration, float frequency = 0.1f, float amplitude = 0.1f, OVRInput.Controller controller = OVRInput.Controller.Active)
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
        if (gameObject.tag == "HandRight")
        {
            StartCoroutine(Vibrate(duration: 0.3f, controller: OVRInput.Controller.RTouch));
        }
        else if (gameObject.tag == "HandLeft")
        {
            StartCoroutine(Vibrate(duration: 0.3f, controller: OVRInput.Controller.LTouch));
        }
    }
}
