using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum weaponName
{
  magnum,
  rifle,
  ak47
}

[System.Serializable]
public class WeaponDataModel
{
  public weaponName name;
  public float damage;
  public int ammoAmount;
  public int burstAmmo;
  public float firingRate;
  public float reloadTime;

}
