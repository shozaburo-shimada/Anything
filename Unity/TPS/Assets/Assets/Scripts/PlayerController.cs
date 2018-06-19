using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://gametukurikata.com/fps/rotation
public class PlayerController : MonoBehaviour {

    private Transform myCamera;

    //[SerializeField] private float mouseSpeed = 2.0f;
    [SerializeField] private Vector2 mouseSpeed;
    [SerializeField] private float rotateSpeed = 2.0f;
    [SerializeField] private bool cameraRotForward = true;
    [SerializeField] private float cameraRotateLimit = 30f;
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float thrust = 100.0f;
    public GameObject Weapon;
    private Quaternion initCameraRot;
    private Quaternion charaRotate;
    private Quaternion cameraRotate;
    private bool isGround;
    private Vector3 velocity;
    private Animator animator;
    private Rigidbody rb;


    // Use this for initialization
    void Start () {
        myCamera = transform.Find("CamPos").transform;

        charaRotate = transform.localRotation;

        initCameraRot = myCamera.localRotation;
        cameraRotate = myCamera.localRotation;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        RotateChara();
        RotateCamera();
        MoveChara();
        Shoot();

	}

    void RotateChara() {
        float yRotate = Input.GetAxis("Mouse X") * mouseSpeed.x;
        //Debug.Log("yRotete: " + yRotate);
        charaRotate *= Quaternion.Euler(0f, yRotate, 0f);
        //Debug.Log("charaRotate: " + charaRotate);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, charaRotate, rotateSpeed * Time.deltaTime);
    }

    void RotateCamera() {
        float xRotate = Input.GetAxis("Mouse Y") * mouseSpeed.y;
        if (cameraRotForward) {
            xRotate *= -1;
        }
        cameraRotate *= Quaternion.Euler(xRotate, 0f, 0f);

        //var tempRot = (cameraRotate.eulerAngles.x > 180) ? cameraRotate.eulerAngles.x - 180 : cameraRotate.eulerAngles.x;
        //var resultYRot = Mathf.Clamp(Mathf.DeltaAngle(initCameraRot.eulerAngles.x, tempRot), -cameraRotateLimit, cameraRotateLimit);
        //resultYRot = (resultYRot < 0) ? resultYRot + 180 : resultYRot;
        //Limit
        //var resultYRot = Mathf.Clamp(Mathf.DeltaAngle(initCameraRot.eulerAngles.x, cameraRotate.eulerAngles.x), -cameraRotateLimit, cameraRotateLimit);
        //Debug.Log("initCameraRot: " + initCameraRot.eulerAngles.x + ", temp: " + tempRot + ", resultYRot: " + resultYRot);
        //cameraRotate = Quaternion.Euler(resultYRot, cameraRotate.eulerAngles.y, cameraRotate.eulerAngles.z);

        myCamera.localRotation = Quaternion.Slerp(myCamera.localRotation, cameraRotate, rotateSpeed * Time.deltaTime);
    }

    void MoveChara() {
        if (isGround) {

            //Move
            velocity = Vector3.zero;

            if (Input.GetKey(KeyCode.W)) {
                //transform.position += transform.forward * 0.01f;
                velocity += transform.forward;
            }

            if (Input.GetKey(KeyCode.A)) {
                //transform.position += transform.right * -0.01f;
                velocity -= transform.right;
            }

            if (Input.GetKey(KeyCode.S)) {
                //transform.position += transform.right * -0.01f;
                velocity -= transform.forward;
            }

            if (Input.GetKey(KeyCode.D)) {
                //transform.position += transform.right * 0.01f;
                velocity += transform.right;
            }

            velocity = velocity.normalized * moveSpeed * Time.deltaTime;

            if (velocity.magnitude > 0) {
                animator.SetBool("is_running", true);
                transform.position += velocity;
            } else {
                animator.SetBool("is_running", false);
            }

            //Jump
            if (Input.GetKey(KeyCode.Space)) {
                rb.AddForce(new Vector3(0, thrust, 0));
                isGround = false;
                //Debug.Log("ground:false");
                animator.SetBool("is_jumping", true);
            } else {
                animator.SetBool("is_jumping", false);
            }
        }
    }

    void Shoot() {
        //Left Click
        if (Input.GetMouseButtonDown(0)) {

        }

        //Right Click
        if (Input.GetMouseButtonDown(1)) {
            /*
            switch (Weapon.Name) {
                case "Hound":

                    break;
                default:
                    Debug.Log("Player has no weapon");
                    break;
            }
            */

        }
    }

    private void OnCollisionStay(Collision collision) {
        isGround = true;
        //Debug.Log("ground:true");
    }
}
