using UnityEngine;
using System.Collections;

public class UnityChanAnimations : MonoBehaviour {
    public Animator anim;
    public Rigidbody rigid;
    public float movement_speed_x, movement_speed_z;
    bool is_test;
    private bool is_running;
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F; 
    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        movement_speed_x = 1.5f;
        movement_speed_z = 2f;
        is_running = false;
        is_test = false;
    }

    /*Updated fixed. 
     * get movement horzontal and movement vertical 
     * shift -> run
     */
    void FixedUpdate()
    {
        float move_horizontal = Input.GetAxis("Horizontal");
        float move_vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(move_horizontal * movement_speed_x * Time.deltaTime, 0f, move_vertical * movement_speed_z * Time.deltaTime);
       
        if(move.z == 0f)
        {
            move.x = move.x * 0.7f;
        }
        else if ( move.z < 0f )
        {
            move.x = 0f;
        }
        else if(is_running)
        {
            move.x *= 2f;
            move.z *= 2f;
        }
        rigid.MovePosition(transform.position + move);
        anim.SetFloat("inputH", move_horizontal);
        anim.SetFloat("inputV", move_vertical);
        
        if(Input.GetKey(KeyCode.LeftShift) && move_vertical > 0)
        {
            is_running = true;
        }
        else
        {
            is_running = false;
        }
        if (Input.GetKey(KeyCode.F1))
        {
            is_test = true;
        }
        else
        {
            is_test = false;
        }
        anim.SetBool("isRunning", is_running);
        anim.SetBool("isTest", is_test);
        /*
        float h = rotationSpeed * Input.GetAxis("Mouse X");
        float v = rotationSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(v, h, 0);*/

    }
    // Update is called once per frame
    void Update ()
    {
	   
	}
}
