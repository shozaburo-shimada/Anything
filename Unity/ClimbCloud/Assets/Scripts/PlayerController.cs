using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rigid2D;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

	// Use this for initialization
	void Start () {
        this.rigid2D = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

        //Jump
        if (Input.GetKeyDown(KeyCode.Space)){
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //Right/Left
        int key = 0;

        if (Input.GetKeyDown(KeyCode.RightArrow)) key = 1;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) key = -1;

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        if (speedx < this.maxWalkSpeed) {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        if (key != 0) {
            transform.localScale = new Vector3(key, 1, 1);
        }



	}
}
