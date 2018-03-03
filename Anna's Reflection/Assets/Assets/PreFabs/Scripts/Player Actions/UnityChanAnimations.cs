using UnityEngine;
using System.Collections;

public class UnityChanAnimations : MonoBehaviour {
    public Animator anim;
    public Rigidbody rigid;
    public float msx, msz;
    bool is_test;
    private bool is_running;
    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        msx = 1.5f;
        msz = 2f;
        is_running = false;
        is_test = false;
    }

    /*Updated fixed. 
     * get movement horzontal and movement vertical 
     * shift -> run
     */
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal * msx * Time.deltaTime, 0f, moveVertical * msz * Time.deltaTime);
       
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
        anim.SetFloat("inputH", moveHorizontal);
        anim.SetFloat("inputV", moveVertical);
        
        if(Input.GetKey(KeyCode.LeftShift) && moveVertical > 0)
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
    }
    // Update is called once per frame
    void Update ()
    {
	   
	}
}
