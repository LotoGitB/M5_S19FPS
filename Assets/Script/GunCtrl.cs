using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCtrl : MonoBehaviour
{
  public Transform gunSpawnPoint;
  public GameObject bulletPrefab;
  public float shootForce;
  public Camera myCamera;
  
  // Update is called once per frame
  void Update()
  {
    if (Input.GetButtonDown("Fire1"))
    {
      float cameraX = Screen.width / 2;
      float cameraY = Screen.height / 2;
      var ray = myCamera.ScreenPointToRay(new Vector3(cameraX, cameraY, 0));

      GameObject b = Instantiate(bulletPrefab, gunSpawnPoint.position, Quaternion.identity);
      b.GetComponent<Rigidbody>().AddForce(ray.direction * shootForce, ForceMode.Impulse);
    }
  }
}
