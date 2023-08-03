using UnityEngine;

public class TimerScript : MonoBehaviour
{
  public float elapsedTime;
  bool counter_flag = true;

  void Update()
  {
    //Spaceキーで計測開始、停止を切り替え
    if (Input.GetKey(KeyCode.Escape))
    {
      counter_flag = !counter_flag;
    }

    if (counter_flag == true)
    {
      elapsedTime += Time.deltaTime;
      // Debug.Log("計測中： " + (elapsedTime).ToString());
    }
  }
}
