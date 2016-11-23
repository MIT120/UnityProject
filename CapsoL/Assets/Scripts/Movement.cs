using UnityEngine;
using System.Collections;


[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movement : MonoBehaviour 
{
    Animator anim;
    bool isWalking = true;
    public AudioClip RunSound;
    public AudioClip walkSound;
    AudioSource audioWalk;
    AudioSource audioRun;
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;


    void Awake()
    {
        target = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {


   
        Walking();
        Move();
        Jumping();
   



    }
    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }

    }

    void Walking()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isWalking = !isWalking;
            anim.SetBool("Walk", isWalking);
            //audioWalk.PlayOneShot(walkSound, 0.3f);
        }
   
    }
    void Move()
    {
      
        if (anim.GetBool("Walk"))
        {
            anim.SetFloat("MoveZ", Mathf.Clamp(Input.GetAxis("MoveZ"), -.25f, .25f));
            anim.SetFloat("MoveX", Mathf.Clamp(Input.GetAxis("MoveX"), -.25f, .25f));
            
        }
        else
        {
            anim.SetFloat("MoveZ", Input.GetAxis("MoveZ"));
            anim.SetFloat("MoveX", Input.GetAxis("MoveX"));
            
            //audioRun.PlayOneShot(RunSound,0.7f);
            
        }
      
    }
     public void DoorOpen(bool isDoorOpen)
    {
        if (isDoorOpen)
        {
            anim.Play("Opening_Door_Outwards");
        }
      
    }
 





}
