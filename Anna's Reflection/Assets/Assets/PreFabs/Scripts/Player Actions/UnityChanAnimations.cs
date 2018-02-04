using UnityEngine;
using System.Collections;

public class UnityChanAnimations : MonoBehaviour {
    public Animator anim;
    public Rigidbody rigid;
    public float ms;
    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        ms = 2f;
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal * ms * Time.deltaTime, 0f, moveVertical * ms * Time.deltaTime);
        rigid.MovePosition(transform.position + move);

        anim.SetFloat("inputH", moveHorizontal);
        anim.SetFloat("inputV", moveVertical);
        if (moveHorizontal != 0 || moveVertical != 0)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);
    }
    // Update is called once per frame
    void Update ()
    {
	   
	}
}
