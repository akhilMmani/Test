using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform target;
    public FloatingJoystick movementJoystick;
    [SerializeField] float speed = 2.0f;
    [SerializeField] float rotSpeed = 2.0f;
    public GameObject parent;
    float x, y;
    Vector3 rotateValue;
    public Animator anim;
    public GameObject player;
    public float Speed = 1f;
    public CharacterController characterController;
    Quaternion TargetRotation;
    float Angle;
    public float TurnSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        movementJoystick = FindObjectOfType<FloatingJoystick>();
        parent = this.gameObject;
        characterController = GetComponent<CharacterController>();
        //anim = this.GetComponentInChildren<Animator>();
        //childAnim = parent.GetComponentInChildren<Animator>();
        //parent.find("nameofchild").GetComponent<Animator>();
        //player = GameObject.Find("player");
        GameObject child = parent.transform.GetChild(0).gameObject;
        player = child;
        // anim = player.GetComponent<Animator>();
        target = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
       GameObject child = parent.transform.GetChild(2).gameObject;
        player = child;
        player.transform.rotation = target.rotation;
        //target = player.transform;
            
        anim = player.GetComponent<Animator>();
        if (movementJoystick.Horizontal != 0 || movementJoystick.Vertical != 0)
        {
            Vector3 direction = target.forward * movementJoystick.Vertical;
             target.position = Vector3.Lerp(target.position, target.position + direction, Time.deltaTime * speed);
            //Vector3 move = new Vector3(movementJoystick.Horizontal, 0, movementJoystick.Vertical);
            //characterController.Move(move * Time.deltaTime * Speed);
            //TargetRotation = Quaternion.Euler(0, Angle, 0);
            //transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, TurnSpeed * Time.deltaTime);
            y = movementJoystick.Horizontal;
            rotateValue = new Vector3(0, y, 0);
            transform.eulerAngles += rotateValue * rotSpeed;
            //Debug.Log(target.eulerAngles);
            //LimitRot();
            
            if (anim != null)
            {
                if (anim.GetBool("Seating")) anim.SetBool("Seating", false);
                if (!anim.GetBool("Walking")) anim.SetBool("Walking", true);
                anim.speed = Speed;
            }
            transform.eulerAngles += rotateValue * rotSpeed;
        }
        else if (anim.GetBool("Walking"))
        {
            Debug.Log("stop walking");
            if (anim != null) anim.SetBool("Walking", false);
            anim.speed = 0; 
        }
    }
}
