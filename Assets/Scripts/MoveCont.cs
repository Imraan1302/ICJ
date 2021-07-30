using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCont : MonoBehaviour
{
    public GameObject groundcheck;
    public bool ShiftDown, isGrounded, isCrouch , isMove;
    public float groundDist, gConst, sprintMod, xVal, yVal, moveSpeed;
    public LayerMask groundMask;
    public Vector3 downVelocity, move;
    public Rigidbody rig;

    //Collection things 
    public int key;
    public bool gotKey;
    public int itemcollect;

    // Start is called before the first frame update
    void Start()
    {
       

        rig = this.GetComponent<Rigidbody>();

        ShiftDown = false;
        groundDist = 0.2f;
        gConst = -9.8f;
        sprintMod = 45f;


    }

    void FixedUpdate()
    {
        HandleMovePly();
    }
    // Update is called once per frame
    void Update()
    {
        HandleMoveInputs();
        Sprint();
        Crouch();

       
    }

    void HandleMoveInputs()
    {


        isGrounded = Physics.CheckSphere(groundcheck.transform.position, groundDist, groundMask);





        xVal = Input.GetAxis("Horizontal");
        yVal = Input.GetAxis("Vertical");




        if ((yVal != 0))
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }



        if (isGrounded && downVelocity.y < 0)
        {
            downVelocity.y = -200f;
        }

        //end of gravity

        move = transform.right * xVal + transform.forward * yVal;


    }

    void HandleMovePly()
    {

        if (!isCrouch)
        {
            if (ShiftDown)
            {

                rig.velocity = (move * moveSpeed * (1 + (sprintMod / 100)) * Time.deltaTime) + (downVelocity * Time.deltaTime);
            }
            else
            {
                rig.velocity = (move * moveSpeed * Time.deltaTime) + (downVelocity * Time.deltaTime);
            }
        }
        else
        {
            rig.velocity = (move * moveSpeed * Time.deltaTime * .6f) + (downVelocity * Time.deltaTime);
        }
    }

    void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ShiftDown = !ShiftDown;
        }

        if (!isMove)
        {
            ShiftDown = false;
        }
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        { 
            isCrouch = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouch = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            key++;
            gotKey = true;
            Debug.Log("We got a key!");
        }

        if (collision.gameObject.tag == "EndDoor" && gotKey == true)
        {
            Debug.Log("Ahhh Last Door!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
