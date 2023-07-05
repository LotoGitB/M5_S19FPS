using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PalancaEventCtrl : MonoBehaviour
{
  public UnityEvent OnZoneEnter;
  public UnityEvent OnZoneExit;
  public UnityEvent OnActionPress;

  private bool isInPlace = false;

  private void Update()
  {
    if (isInPlace && Input.GetKeyDown(KeyCode.E))
    {
      OnActionPress.Invoke();
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      isInPlace = true;
      OnZoneEnter.Invoke();
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      isInPlace = false;
      OnZoneExit.Invoke();
    }
  }

}
