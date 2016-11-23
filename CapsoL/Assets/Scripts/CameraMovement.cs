using UnityEngine;
using System.Collections;





public class CameraMovement : MonoBehaviour 
{
    Vector2 mouseLook;
    Vector2 smoothV;

    public float senitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject character;
void Awake() 
{
        character = this.transform.parent.gameObject;
}
void Update()
{
        var mb = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mb = Vector2.Scale(mb, new Vector2(senitivity * smoothing, senitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mb.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mb.y, 1f / smoothing);
        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

     
    }



}
