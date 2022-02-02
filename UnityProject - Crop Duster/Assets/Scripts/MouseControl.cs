using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{

    [SerializeField] float speedH = 2.0f;
    [SerializeField] float speedV = 2.0f;

    float yaw = 0.0f;
    float pitch = 0.0f;

    public float speed = 50.0f;
    public float strafeSpeed = 50.0f;
    public float elevationSpeed = 25.0f;

    public float speedMultiplier = 2.0f;

    //private GameObject _drag;
    //private Vector3 screenPosition;
    //private Vector3 offset;



    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            if (Cursor.visible)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }
        }

        if (!Cursor.visible)
        {
            CameraMovement();

        }

        float translation;
        float strafe;
        float elevation ;


        if (Input.GetKey(KeyCode.LeftShift))
        {
            translation = Input.GetAxis("Vertical") * speed * speedMultiplier;
            strafe = Input.GetAxis("Horizontal") * strafeSpeed * speedMultiplier;
            elevation = Input.GetAxis("Elevation") * elevationSpeed * speedMultiplier;
        }
        else
        {
            translation = Input.GetAxis("Vertical") * speed;
            strafe = Input.GetAxis("Horizontal") * strafeSpeed;
            elevation = Input.GetAxis("Elevation") * elevationSpeed;
        }

        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;
        elevation *= Time.deltaTime;

        transform.Translate(0, 0, translation);

        transform.Translate(strafe, 0, 0);

        transform.Translate(0, elevation, 0);
    }

    void CameraMovement()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    
}
