using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyCtrl : MonoBehaviour
{
  private NavMeshAgent agent;
  // Start is called before the first frame update
  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
  }

  // Update is called once per frame
  void Update()
  {
    Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    agent.SetDestination(playerPosition);

  }

  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.CompareTag("Bullet"))
    {
      Destroy(gameObject);
    }
  }
}
