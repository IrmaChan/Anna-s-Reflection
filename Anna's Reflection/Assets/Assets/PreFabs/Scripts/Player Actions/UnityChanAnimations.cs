using UnityEngine;
using System.Collections;

public class UnityChanAnimations : MonoBehaviour {
    public Animator anim;
    public Rigidbody rigid;
    public float msx, msz;

    private bool run;
    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        msx = 1.5f;
        msz = 2f;
        run = false;
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal * msx * Time.deltaTime, 0f, moveVertical * msz * Time.deltaTime);
       
        if(move.z <= 0f)
        {
            move.x = 0f;
        }
        else if(run)
        {
            move.x *= 2f;
            move.z *= 2f;
        }
        rigid.MovePosition(transform.position + move);
        anim.SetFloat("inputH", moveHorizontal);
        anim.SetFloat("inputV", moveVertical);
        
        if(Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }
        anim.SetBool("run", run);
    }
    // Update is called once per frame
    void Update ()
    {
	   
	}
}
