using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Anim;
    private Rigidbody rb;
    private CharacterController character_controller;
    public float speed = 3f, gravity = -10f, jumpforce = 2f;
    private Vector3 playerinput, velocity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        character_controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        playerinput = Vector3.zero;
        playerinput += transform.forward * Input.GetAxis("Vertical");
        playerinput += transform.right * Input.GetAxis("Horizontal");
        if (character_controller.isGrounded)
        {
            velocity.y = -1f;
            if(Input.GetKey("space"))
            {
                Anim.SetTrigger("Jump");
                velocity.y = jumpforce;
            }
        }
        else
        {
            velocity.y -= gravity*-1f*Time.deltaTime;
        }
        character_controller.Move(playerinput*speed*Time.deltaTime);
        character_controller.Move(velocity*Time.deltaTime);
        Anim.SetFloat("X",Input.GetAxis("Horizontal"));
        Anim.SetFloat("Y",Input.GetAxis("Vertical"));
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

}
