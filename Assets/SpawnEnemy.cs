using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
  public GameObject enemyPrefab;
  // Start is called before the first frame update
  void Start()
  {
    InvokeRepeating("EnemySpawn", 0f, Random.Range(2f, 5f));
  }

  private void EnemySpawn()
  {
    Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
  }
}
