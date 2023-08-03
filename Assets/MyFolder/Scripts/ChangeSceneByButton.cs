using UnityEngine;

public class ChangeSceneByButton : MonoBehaviour
{
  GameObject alpha0;
  public string SceneName;

  void Start()
  {
    alpha0 = GameObject.Find("alpha0");
  }

  public void OnClickButton()
  {
    // alpha0を参照する
    FadeController fadeController = alpha0.GetComponent<FadeController>();
    fadeController.fadeOutStart(SceneName);

  }
  void Update()
  {

  }
}
