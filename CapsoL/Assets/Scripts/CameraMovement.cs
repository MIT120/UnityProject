using UnityEngine;
using System.Collections;





public class CameraMovement : MonoBehaviour 
{
    
    Vector2 mouseLook;
    Vector2 smoothV;
    GameObject cube;
    public float senitivity = 2.0f;
    public float smoothing = 2.0f;
    private float rotateSpeed = 0.1f;
    Vector2 mb;
    GameObject character;
    private Vector3 point;
    void Awake() 
{
        character = transform.parent.gameObject;
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        point = cube.transform.position;
        transform.LookAt(point);
    }
void Update()
{

        mb = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mb = Vector2.Scale(mb, new Vector2(senitivity * smoothing, senitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mb.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mb.y, 1f / smoothing);

        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -28, 17);
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        Camera.main.transform.Rotate(-mouseLook.y, 0, 0);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);



    }
    public void DoorAnimationCamera(bool isDoorOpen)
    {
        if (isDoorOpen)
        {
            Camera.main.transform.rotation = Quaternion.Euler(0, 50, 1);
        }

    }
    public void CameraRotateToObject(bool trigger)
    {
        if (trigger)
        {




            Camera.main.transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * 20);

        }

    }



}
