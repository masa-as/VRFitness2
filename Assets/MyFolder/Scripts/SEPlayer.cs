using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEPlayer : MonoBehaviour
{

  public AudioClip sound1;
  AudioSource audioSource;

  void Start()
  {
    //Componentを取得
    audioSource = GetComponent<AudioSource>();
  }

  void OnClickButton()
  {
    //音(sound1)を鳴らす
    audioSource.PlayOneShot(sound1);
  }
}