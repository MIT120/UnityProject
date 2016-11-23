using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class FlashLight : MonoBehaviour {

    // Use this for initialization
    public AudioClip soundOn;
    public AudioClip soundOff;
    AudioSource audio;
    AudioSource audioFlashOff;
    public Light light;
    private bool isLightOn = false;
    private float lightIntens = 0.0f;

    public Camera mainCam;
    public Camera thirdPerson;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audioFlashOff = GetComponent<AudioSource>();
        lightIntens = light.intensity;
    }

    void Update()
    {
        FlashTrigger();
    }
    public void FlashTrigger()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //isLightOn = !isLightOn;
            if (!isLightOn)
            {
                light.intensity = 0;
                isLightOn = true;
                audio.PlayOneShot(soundOn, 0.7f);
                
            }
            else
            {
                light.intensity = lightIntens;
                isLightOn = false;
                audioFlashOff.PlayOneShot(soundOff, 0.7f);
                
            }
        }

    }
    public void SwitchMainCam()
    {
        thirdPerson.gameObject.SetActive(true);
        mainCam.gameObject.SetActive(false);
    }
  
}
