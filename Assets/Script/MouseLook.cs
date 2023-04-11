using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
  public float sensivity = 100;
  public Transform player;
  private float xRotacion;
  private void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
  }
  void Update()
  {
    float mouseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
    float mouseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

    xRotacion -= mouseY;
    xRotacion = Mathf.Clamp(xRotacion, -90, 90);

    transform.localRotation = Quaternion.Euler(xRotacion, 0, 0);

    player.Rotate(Vector3.up * mouseX);
  }
}
