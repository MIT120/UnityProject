using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

    // Use this for initialization
    
    bool isDoorOpen = false;
    
    Transform playerPosition;
    public GameObject toPlayAnimation;
  
   

    void Start()
    {

        


    }
	// Update is called once per frame
	void Update () 
    {
    
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,1))
            {
                
                print(hit.collider.gameObject.tag);
               
                //print("Name of Door: " + hit.collider.name);
                if (hit.collider.gameObject.tag == "Door" )
                {
                    isDoorOpen = !isDoorOpen;

                    playerPosition = gameObject.GetComponent<Transform>();
                    

                    if (isDoorOpen)
                    {
                        print("ATANAS");
                        //change position
                        toPlayAnimation.GetComponent<Animation>().Play("Door_Open");
                        toPlayAnimation.GetComponent<Animation>().PlayQueued("Door_Close");
                        this.GetComponent<Movement>().DoorOpen(isDoorOpen);
                       
                        this.transform.localPosition = new Vector3(-0.151f, 1.01f, -2.197f);
                        if (!toPlayAnimation.GetComponent<Animation>().IsPlaying("Door_Open")) 
                        {
                            toPlayAnimation.GetComponent<Animation>().Play("Door_Close");
                            isDoorOpen = !isDoorOpen;
                            
                        }

                       
                    }

                    
                   

                    //hit.collider.gameObject.GetComponentInParent<Collider>().gameObject.GetComponentInParent<Animation>().Play();
                    //foreach (AnimationState state in hit.collider.gameObject.GetComponent<Animation>())
                    //{

                    //    state.speed = 1.0f;

                    //}

                    //hit.collider.gameObject.GetComponent<DoorController>().ChangeDoorState();

                }
                //if (hit.collider.CompareTag("Door"))
                //{
                //    hit.collider.GetComponent<Animator>();
                //    anim.SetBool("OpenDoor", true);
                //}
                

            }
        }
	}
}
