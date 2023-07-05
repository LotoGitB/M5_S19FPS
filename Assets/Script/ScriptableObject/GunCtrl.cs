using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunCtrl : MonoBehaviour
{
  public WeaponSO myGunSO;
  public Transform gunSpawnPoint;
  public GameObject bulletPrefab;
  public float shootForce;
  public Camera myCamera;
  private float fireRefTime;
  private float reloadRefTime;
  public Slider reloadSlider;
  private int ammoAvailable;
  public TextMeshProUGUI ammoText;

  private void Start()
  {
    fireRefTime = Time.time;
    ammoAvailable = myGunSO.customWeapon.ammoAmount;
    ammoText.text = ammoAvailable.ToString();
    reloadRefTime = Time.time;
    reloadSlider.value = 0;
    reloadSlider.maxValue = myGunSO.customWeapon.reloadTime;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButtonDown("Fire1") && ammoAvailable > 0 && fireRefTime < Time.time && reloadRefTime < Time.time)
    {
      Disparo();
    }

    if (Input.GetKeyDown(KeyCode.E) && reloadRefTime < Time.time)
    {
      reloadRefTime = Time.time + myGunSO.customWeapon.reloadTime;
      ammoAvailable = myGunSO.customWeapon.ammoAmount;
      ammoText.text = ammoAvailable.ToString();
    }

    if (reloadRefTime > Time.time)
    {
      reloadSlider.value = Mathf.Clamp(reloadRefTime - Time.time, 0, reloadRefTime);
    }
  }

  public void Disparo()
  {
    float cameraX = Screen.width / 2;
    float cameraY = Screen.height / 2;
    var ray = myCamera.ScreenPointToRay(new Vector3(cameraX, cameraY, 0));

    GameObject b = Instantiate(bulletPrefab, gunSpawnPoint.position, Quaternion.identity);
    b.GetComponent<Rigidbody>().AddForce(ray.direction * shootForce, ForceMode.Impulse);
    fireRefTime = Time.time + myGunSO.customWeapon.firingRate;
    ammoAvailable--;
    ammoText.text = ammoAvailable.ToString();
  }
}
