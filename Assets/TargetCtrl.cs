using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCtrl : MonoBehaviour
{
  private TargetSpawn ts;
  private void Start()
  {
    ts = FindObjectOfType<TargetSpawn>();
  }
  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.CompareTag("Bullet"))
    {
      ts.NextTarget();
      //gameObject.SetActive(false);
    }
  }
}
