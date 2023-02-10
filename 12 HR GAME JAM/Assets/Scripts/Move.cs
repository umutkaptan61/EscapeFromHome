using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController characterController;
    public Animator animator;
    public Transform cam;
    public AudioSource jumpSounds;
   
    
    public static Vector3 _lastTransform;   //Checkpoint noktasý tespit etmek için


    [Header("Movement")]
    public float speed = 2f;
    public float gravity = -9.1f;
    public float jumpHeight;
    public float jumpHeightNoEnergy;
    public float jumpHeightWithEnergy;

    [Header("Ground Check")]
    public Transform ground_check;
    public float ground_distance = 0.4f;
    public LayerMask ground_mask;
    public bool isGrounded = false;

    [Header("Cam Options")]    
    public float turnSmoothing = 0.1f;

    private float turnSmoothness;
    private Vector3 velocity;
    private bool groundedPlayer;

    private void Start()
    {
        jumpHeight = jumpHeightNoEnergy;       
    }


    private void Update()
    {
        if (GameManager.gameIsPaused == false)   //Bütün updatei içine aldým
        {
            isGrounded = Physics.CheckSphere(ground_check.position, ground_distance, ground_mask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = 0f;
            }

            float h = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(h, 0 ,z);


            if (move.magnitude >= 0.1f)
            {
                //..........................Player Direction.............................

                float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothness, turnSmoothing);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                characterController.Move(moveDirection.normalized * speed * Time.deltaTime);
            }

            animator.SetFloat("speed", move.magnitude);

            //...........................Jump......................................

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                jumpSounds.Play();
                velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }


            velocity.y += gravity * Time.deltaTime;

            characterController.Move(velocity * Time.deltaTime);

            //...........................Falling Animations.............................

            if (isGrounded)
            {
                animator.SetBool("fall", false);
            }

            else
            {
                animator.SetBool("fall", true);
            }

            //..............................Running.....................................

            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("run", true);
                speed = 2.5f;
            }

            else
            {
                animator.SetBool("run", false);
                speed = 1f;
            }



        }
    }
        

}



