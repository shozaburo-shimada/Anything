using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//http://sasanon.hatenablog.jp/entry/2017/09/17/041612
public class CameraController2 : MonoBehaviour {
    [SerializeField] private Transform player;          //注視対象プレイヤー
    [SerializeField] private float distance = 1.0f;    //注視プライヤーとカメラとの距離
    [SerializeField] private Quaternion vRotation;      //カメラの垂直回転
    [SerializeField] private Quaternion hRotation;      //カメラの水平回転
    [SerializeField] private float turnSpeed = 10.0f;      //カメラの水平回転

    // Use this for initialization
    void Start () {
        // Init Rotation
        Debug.Log("Player rotation: " +player.rotation);
        Debug.Log("Player position: " + player.position);
        transform.rotation = player.rotation;
        /*
        vRotation = Quaternion.Euler(30, 0, 0); //垂直は30度見下ろし
        hRotation = Quaternion.identity;        //水平は無回転
        //hRotation = Quaternion.Euler(player.forward);
        transform.rotation = hRotation * vRotation;
        */
        //Init Position
        transform.position = player.position - transform.rotation * Vector3.forward * distance;
        //transform.position = player.position - transform.rotation * player.forward * distance;
    }
	
	void LateUpdate () {
        //水平回転
        //if (Input.GetMouseButton(0))
            hRotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * turnSpeed, 0);

        transform.rotation = hRotation * vRotation;

        transform.position = player.position - transform.rotation * Vector3.forward * distance;
    }
}
