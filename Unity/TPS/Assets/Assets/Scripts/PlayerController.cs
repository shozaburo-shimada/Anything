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
    private Quaternion initCameraRot;
    private Quaternion charaRotate;
    private Quaternion cameraRotate;


	// Use this for initialization
	void Start () {
        myCamera = transform.Find("CamPos").transform;

        charaRotate = transform.localRotation;

        initCameraRot = myCamera.localRotation;
        cameraRotate = myCamera.localRotation;
		
	}
	
	// Update is called once per frame
	void Update () {
        RotateChara();
        RotateCamera();
        MoveChara();

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

    }
}
