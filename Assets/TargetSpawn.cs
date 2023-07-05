using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
  public GameObject[] targets;
  private int actualIndex = 0;
  // Start is called before the first frame update
  void Start()
  {
    targets = GameObject.FindGameObjectsWithTag("Target");
    // actualIndex = targets.Length - 1;
    foreach (GameObject target in targets)
    {
      target.SetActive(false);
    }
    NextTarget();
  }

  public void NextTarget()
  {
    targets[actualIndex].SetActive(false);

    actualIndex--;
    if (actualIndex < 0)
    {
      actualIndex = targets.Length - 1;
    }

    targets[actualIndex].SetActive(true);
  }
}
