using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetEventCtrl : MonoBehaviour
{
  public UnityEvent OnTargetDestroy;

  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.CompareTag("Bullet"))
    {
      OnTargetDestroy.Invoke();
    }
  }

}
