using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public static CamController camcont;
    public float LookSensitivity = 100f;
    public Transform PlyHitbox;
    public RaycastHit LookHit;
    public Vector3 test, sPoint, CamPosition;
    public float xRotation = 0f;
    public Camera main;
    public float camZtilt, camtiltstep, camYtilt;



    string FormatHours, FormatMin;
    public float mouseX, mouseY, GrabRange, trueGrab, PrecisionRange;


    void Awake()
    {
        camcont = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        GetMousePos();
        RotateView();
    }

    void GetMousePos()
    {
        mouseX = Input.GetAxis("Mouse X") * LookSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * LookSensitivity * Time.deltaTime;
    }



    void RotateView()
    {


        xRotation -= mouseY;












        PlyHitbox.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);



        

        Physics.Raycast(CamPosition, transform.forward * 100, out LookHit, GrabRange);
        // Debug.DrawRay(CamPosition, transform.forward * 100, Color.yellow);

    }

}

