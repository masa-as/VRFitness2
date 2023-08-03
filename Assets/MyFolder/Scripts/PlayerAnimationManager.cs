using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
  /// <summary> キャラのアニメーション管理 </summary>
  public Animator _CharacterAnimator = null;
  /// <summary>
  /// 待機アニメーションに切り替える
  /// </summary>
  public void SetIdleAnimation()
  {
    _CharacterAnimator.Play("BasicMotions@Idle01", 0);
  }
  /// <summary>
  /// 歩きアニメーションに切り替える
  /// </summary>
  public void SetWalkAnimation()
  {
    _CharacterAnimator.Play("BasicMotions@Walk01", 0);
  }
  /// <summary>
  /// 走りアニメーションに切り替える
  /// </summary>
  public void SetRunAnimation()
  {
    _CharacterAnimator.Play("BasicMotions@Run01", 0);
  }
}