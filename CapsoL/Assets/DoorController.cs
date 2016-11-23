using UnityEngine;
using System.Collections;


[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]

public class DoorController : MonoBehaviour {

    bool doorStatus = false;
    Animation anim;
    void Awake()
    {
        GetComponent<Animation>();
    }
    public void ChangeDoorState()
    {

        doorStatus = !doorStatus;
       
    }
	// Update is called once per frame
	void Update () 
    {
      

    }
}
