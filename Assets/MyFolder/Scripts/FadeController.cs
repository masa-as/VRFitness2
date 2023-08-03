using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
  float fadeSpeed = 0.05f;        //透明度が変わるスピードを管理
  float red, green, blue, alfa;   //パネルの色、不透明度を管理

  public bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
  public bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ

  Image fadeImage;                //透明度を変更するパネルのイメージ

  //シーン遷移のための型
  private string afterScene;

  void Start()
  {
    fadeImage = GetComponent<Image>();
    red = fadeImage.color.r;
    green = fadeImage.color.g;
    blue = fadeImage.color.b;
    alfa = fadeImage.color.a;
  }

  void Update()
  {
    if (isFadeIn)
    {
      FadeIn();
    }

    if (isFadeOut)
    {
      FadeOut();
    }
  }

  public void fadeOutStart(string nextScene)
  {
    isFadeOut = true;
    afterScene = nextScene;
  }

  public void FadeIn()
  {
    fadeImage.enabled = true;
    alfa -= fadeSpeed;                //a)不透明度を徐々に下げる
    SetAlpha();                      //b)変更した不透明度パネルに反映する
    if (alfa <= 0)
    {                    //c)完全に透明になったら処理を抜ける
      isFadeIn = false;
      fadeImage.enabled = false;    //d)パネルの表示をオフにする
    }
  }

  public void FadeOut()
  {
    fadeImage.enabled = true;  // a)パネルの表示をオンにする
    alfa += fadeSpeed;         // b)不透明度を徐々にあげる
    SetAlpha();               // c)変更した透明度をパネルに反映する
    if (alfa >= 1)
    {             // d)完全に不透明になったら処理を抜ける
      isFadeOut = false;
      SceneManager.LoadScene(afterScene);
    }
  }

  void SetAlpha()
  {
    fadeImage.color = new Color(red, green, blue, alfa);
  }
}
