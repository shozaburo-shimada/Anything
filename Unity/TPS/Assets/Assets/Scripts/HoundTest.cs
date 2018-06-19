using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoundTest : MonoBehaviour {

    public GameObject target;
    //public float rotSpeed = 180.0f; //追尾性能
    private float rotSpeed;
    public float maxRotSpeed = 180.0f;
    public float initRotSpeed = 10.0f;
    public float focusSpeed = 5.0f;
    public float bulletSpeed = 6.0f; //弾速
    private float etime = 0;

	// Use this for initialization
	void Start () {
        rotSpeed = initRotSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        etime += Time.deltaTime;
        rotSpeed = Mathf.Pow(2, focusSpeed*etime);

        //targetと弾とのベクトル
        Vector3 vecTarget = target.transform.position - transform.position;
        //弾の正面ベクトル
        Vector3 vecForward = transform.TransformDirection(Vector3.forward);
        //ターゲットまでの角度
        float angleDiff = Vector3.Angle(vecForward, vecTarget);
        //ホーミング角度(回転角)
        float angleAdd = rotSpeed * Time.deltaTime;
        //ターゲットへ向けるクォータニオン
        Quaternion rotTarget = Quaternion.LookRotation(vecTarget);

        if (angleDiff <= angleAdd) {
            //ターゲットと弾との角度が回転角以内なら完全にターゲットの方を向く
            transform.rotation = rotTarget;
        } else {
            //ターゲットと弾との角度が回転角より大きいなら、指定角度だけターゲットを向く
            float t = angleAdd / angleDiff;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotTarget, t);
        }

        transform.position += transform.TransformDirection(Vector3.forward)*bulletSpeed*Time.deltaTime;
	}
}
