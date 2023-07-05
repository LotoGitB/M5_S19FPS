using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
  private void Start() {
    Destroy(gameObject,2f);
  }
  private void OnCollisionEnter(Collision other)
  {
    Debug.Log(other.gameObject.name);
    if (other.gameObject.tag == "Target")
    {
      //Destroy(other.gameObject);
    }
    Destroy(gameObject);
  }
}
