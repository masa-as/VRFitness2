using UnityEngine;
using UnityEngine.UI;

public class SoundPresenter : MonoBehaviour
{
  //BGM
  [SerializeField] Text bgmVolumeText;//BGMMenuViewのvolumeTextを取得
  [SerializeField] Slider bgmSlider;//BGMMenuViewのsliderを取得

  //SE
  [SerializeField] Text seVolumeText;//SEMenuViewのvolumeTextを取得
  [SerializeField] Slider seSlider;//SEMenuViewのsliderを取得

  [SerializeField] Text VoiceVolumeText;//volumeTextを取得
  [SerializeField] Slider VoiceSlider;//sliderを取得

  void Start()
  {
    //BGMを再生
    // AudioManager.GetInstance().PlayBGM(0);
  }

  //BGMMenuViewのSliderを動かしたときに呼び出す関数を作成
  public void OnChangedBGMSlider()
  {
    //Sliderの値に応じてBGMを変更
    AudioManager.GetInstance().BGMVolume = bgmSlider.value;
    //volumeTextの値をSliderのvalueに変更
    bgmVolumeText.text = string.Format("{0:0}", bgmSlider.value * 100);
  }

  //SEMenuViewのSliderを動かしたときに呼び出す関数を作成
  public void OnChangedSESlider()
  {
    //Sliderの値に応じてSEを変更
    AudioManager.GetInstance().SEVolume = seSlider.value;
    //volumeTextの値をSliderのvalueに変更
    seVolumeText.text = string.Format("{0:0}", seSlider.value * 100);
  }

  public void OnChangedVoiceSlider()
  {
    //Sliderの値に応じてSEを変更
    AudioManager.GetInstance().VoiceVolume = VoiceSlider.value;
    //volumeTextの値をSliderのvalueに変更
    VoiceVolumeText.text = string.Format("{0:0}", VoiceSlider.value * 100);
  }

  //Buttonを押したときに呼ばれる関数
  public void OnClickedBGMStopButton()
  {
    AudioManager.GetInstance().StopBGM(0);
  }


  //Buttonを押したときに呼ばれる関数
  public void OnClickedBGMButton()
  {
    Debug.Log("bgm");
    AudioManager.GetInstance().PlayBGM(0);
  }


  //Buttonを押したときに呼ばれる関数
  public void OnClickedSEButton()
  {
    Debug.Log("se");
    //SEを再生
    AudioManager.GetInstance().PlaySE(0);
  }
  public void OnClickedVoiceButton()
  {
    Debug.Log("se");
    AudioManager.GetInstance().PlayVoice(0);
  }
}