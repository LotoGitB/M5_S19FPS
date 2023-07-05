using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementCtrl : MonoBehaviour
{
  public float movementSpeed = 12;
  public float multSpeed = 1.5f;
  public float gravity = -9.81f;
  public float highInJump = 3f;
  public Transform groundCheck;
  public LayerMask floorMask;

  public UnityEvent OnJump;

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

    bool isSprint = Input.GetKey(KeyCode.LeftShift);

    cc.Move(move * (isSprint ? movementSpeed * multSpeed : movementSpeed) * Time.deltaTime);

    isGrounded = Physics.CheckSphere(groundCheck.position, 0.5f, floorMask);

    if (Input.GetButtonDown("Jump") && isGrounded)
    {
      velocity.y = Mathf.Sqrt(highInJump * -2 * gravity);
      isGrounded = false;
      OnJump.Invoke();
      // //Función para disparar
      // GunCtrl scritGunCtrl = GameObject.Find("Gun").GetComponent<GunCtrl>();
      // scritGunCtrl.Disparo();
      // //Funcion para desactivar el objeto 1
      // GameObject tanque1 = GameObject.Find("Oil_tank_v1 (3)");
      // tanque1.GetComponent<MeshRenderer>().enabled = !tanque1.GetComponent<MeshRenderer>().enabled;
      // //Funcion para desactivar el objeto 2
      // GameObject tanque2 = GameObject.Find("Oil_tank_v1 (4)");
      // tanque2.GetComponent<MeshRenderer>().enabled = !tanque2.GetComponent<MeshRenderer>().enabled;
    }

    velocity.y += gravity * Time.deltaTime;
    cc.Move(velocity * Time.deltaTime);
  }


}
