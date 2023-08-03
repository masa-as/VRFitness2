using UnityEngine;

public class CharacterControllerByKey : MonoBehaviour
{

  public Animator _CharacterAnimator = null;

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(KeyCode.UpArrow))
    {
      transform.position = new Vector3(0f, 0f, transform.position.z + 0.01f);
      _CharacterAnimator.Play("WalkForward", 0);
    }
    if (Input.GetKey(KeyCode.DownArrow))
    {
      transform.position = new Vector3(0f, 0f, transform.position.z - 0.01f);
      _CharacterAnimator.Play("WalkBackward", 0);
    }
    if (Input.GetKey(KeyCode.Space))
    {
      _CharacterAnimator.Play("Punch", 0);
    }
  }
}
