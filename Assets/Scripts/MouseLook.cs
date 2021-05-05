using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform Gun;
    public Transform PlayerBody;

    //public GameObject PlayerCamera;

    public float MouseSensitivity = 1000f;

    float Xrotation = 1f;
    //float GunRotation = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LockMouse();
        if (Cursor.lockState != CursorLockMode.None)
        {
            LookAround();
        }

    }

    public void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        Xrotation -= mouseY;
        //GunRotation -= mouseX; 

        Xrotation = Mathf.Clamp(Xrotation, -90f, 45f);
        //GunRotation = Mathf.Clamp(Xrotation, -90f, 45f);
        transform.localRotation = Quaternion.Euler(Xrotation, 0f, 0f);
        
        
        
        PlayerBody.Rotate(Vector3.up * mouseX);
        //Gun.transform.localRotation = Quaternion.Euler(GunRotation, 0f, 0f);
    }

    public void LockMouse()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
