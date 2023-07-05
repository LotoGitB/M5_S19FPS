using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeOfGun
{
  pistol,
  magnum,
  machinegun,
  rifle
}

[System.Serializable]
public class GunValues
{
  public TypeOfGun gunType;
  public float fireRate;
  public int ammoCapacity;
  public float damage;
  public float reloadTime;
}
