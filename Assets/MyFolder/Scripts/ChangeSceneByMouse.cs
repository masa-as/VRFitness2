using UnityEngine;

public class ChangeSceneByMouse : MonoBehaviour
{
  GameObject alpha0;
  public string NextScene;
  public string BeforeScene;

  void Start()
  {
    alpha0 = GameObject.Find("alpha0");
  }

  void Update()
  {
    // 左クリックで次のシーンへ
    if (Input.GetMouseButtonDown(0)||OVRInput.Get(OVRInput.RawButton.A))
    {
      // alpha0を参照する
      FadeController fadeController = alpha0.GetComponent<FadeController>();
      fadeController.fadeOutStart(NextScene);
    }
    // 右クリックで前のシーンへ
    if (Input.GetMouseButtonDown(1)||OVRInput.Get(OVRInput.RawButton.B))
    {
      // 別のオブジェクトを参照する
      FadeController fadeController = alpha0.GetComponent<FadeController>();
      fadeController.fadeOutStart(BeforeScene);
    }
  }
}
