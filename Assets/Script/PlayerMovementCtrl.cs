using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCtrl : MonoBehaviour
{
  public float movementSpeed = 12;
  public float gravity = -9.81f;
  public float highInJump = 3f;
  public Transform groundCheck;
  public LayerMask floorMask;
  private CharacterController cc;
  private Vector3 velocity;
  private bool isGrounded = true;
  // Start is called before the first frame update
  void Start()
  {
    cc = gameObject.GetComponent<CharacterController>();
  }

  // Update is called once per frame
  void Update()
  {
    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");

    Vector3 move = (transform.right * x) + (transform.forward * z);
    cc.Move(move * movementSpeed * Time.deltaTime);

    isGrounded = Physics.CheckSphere(groundCheck.position, 0.5f, floorMask);

    if (Input.GetButtonDown("Jump") && isGrounded)
    {
      velocity.y = Mathf.Sqrt(highInJump * -2 * gravity);
      isGrounded = false;
    }

    velocity.y += gravity * Time.deltaTime;
    cc.Move(velocity * Time.deltaTime);
  }


}
