using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanDemo1 : MonoBehaviour {

    private Animator animator;
    private Rigidbody rb;
    bool f_ground;

    public Vector3 velocity;
    public float thrust = 100.0f;
    public float movespeed = 5.0f;

    //For Rotation, http://corevale.com/unity/2346
    public Vector2 rotationSpeed;
    public bool reverse = false;
    private Vector2 lastMousePosition;
    private Vector2 newAngle = Vector2.zero;
    Transform campos;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Debug.Log("My position: " + transform.position);
        //campos = transform.Find("CamPos").transform;
	}

    // Update is called once per frame
    void Update() {


        if (f_ground) {

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

            velocity = velocity.normalized * movespeed * Time.deltaTime;

            if (velocity.magnitude > 0) {
                animator.SetBool("is_running", true);
                transform.position += velocity;
            } else {
                animator.SetBool("is_running", false);
            }

            //Jump
            if (Input.GetKey(KeyCode.Space)) {
                rb.AddForce(new Vector3(0, thrust, 0));
                f_ground = false;
                //Debug.Log("ground:false");
                animator.SetBool("is_jumping", true);
            } else {
                animator.SetBool("is_jumping", false);
            }
        }

        //Rotation
        // 左クリックした時
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("左クリック");
            // カメラの角度を変数"newAngle"に格納
            //newAngle = campos.transform.localEulerAngles;
            newAngle = transform.localEulerAngles;
            // マウス座標を変数"lastMousePosition"に格納
            lastMousePosition = Input.mousePosition;
        }
        // 左ドラッグしている間
        else if (Input.GetMouseButton(0)) {
            //カメラ回転方向の判定フラグが"true"の場合
            if (!reverse) {
                //Debug.Log("ドラッグ");
                // Y軸の回転：マウスドラッグ方向に視点回転
                // マウスの水平移動値に変数"rotationSpeed"を掛ける
                //（クリック時の座標とマウス座標の現在値の差分値）
                newAngle.y -= (lastMousePosition.x - Input.mousePosition.x) * rotationSpeed.y;
                // X軸の回転：マウスドラッグ方向に視点回転
                // マウスの垂直移動値に変数"rotationSpeed"を掛ける
                //（クリック時の座標とマウス座標の現在値の差分値）
                newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * rotationSpeed.x;
                // "newAngle"の角度をカメラ角度に格納
                //campos.transform.localEulerAngles = newAngle;
                Debug.Log("Mouse Position: " + Input.mousePosition);
                Debug.Log("Last Position: " + lastMousePosition);
                Debug.Log("new Angle: " + newAngle);
                transform.localEulerAngles = newAngle;
                // マウス座標を変数"lastMousePosition"に格納
                lastMousePosition = Input.mousePosition;
            }
        }
    }

    private void OnCollisionStay(Collision collision) {
        f_ground = true;
        //Debug.Log("ground:true");
    }
}
