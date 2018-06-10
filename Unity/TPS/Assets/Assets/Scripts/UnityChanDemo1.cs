using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanDemo1 : MonoBehaviour {

    private Animator animator;
    private Rigidbody rb;
    bool f_ground;

    public float thrust = 100.0f;
    public float rlspeed = 5.0f;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (f_ground){
            if (Input.GetKey("up")) { 
                transform.position += transform.forward * 0.01f;
                animator.SetBool("is_running", true);
            }else{ 
                animator.SetBool("is_running", false);
            }

            if (Input.GetKey("right")){
                transform.Rotate(0, 10, 0);
            }

            if (Input.GetKey("left")){
                transform.Rotate(0, -10, 0);
            }

            if (Input.GetKey(KeyCode.A)) {
                Debug.Log("left");
                //rb.AddForce(transform.right * (-1) * rlspeed);
                transform.position += transform.right * -0.01f;
            }

            if (Input.GetKey(KeyCode.D)) {
                Debug.Log("right");
                //rb.AddForce(transform.right * (1) * rlspeed);
                transform.position += transform.right * 0.01f;
            }


            if (Input.GetKey(KeyCode.Space)){
                rb.AddForce(new Vector3(0, thrust, 0));
                f_ground = false;
                //Debug.Log("ground:false");
                animator.SetBool("is_jumping", true);
            } else {
                animator.SetBool("is_jumping", false);
            }
        }
	}

    private void OnCollisionStay(Collision collision) {
        f_ground = true;
        //Debug.Log("ground:true");
    }
}
