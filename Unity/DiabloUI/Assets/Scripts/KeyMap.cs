using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void KeyFunc();

public class KeyMap : MonoBehaviour {

    public static KeyMap instance;

    void Awake() {
        instance = this;  
    }

    public KeyFunc Key1Func;
    public KeyFunc Key2Func;
    public KeyFunc Key3Func;
    public KeyFunc Key4Func;
    public KeyFunc MouseLeftFunc;
    public KeyFunc MouseRightFunc;

    // Use this for initialization
    void Start () {
        Key1Func = () => Debug.Log("I'm Key1Func()");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1") && Key1Func != null) {
            Key1Func();
        }
        if (Input.GetKeyDown("2") && Key2Func != null)
        {
            Key2Func();
        }
        if (Input.GetKeyDown("3") && Key3Func != null)
        {
            Key3Func();
        }

    }

    public void SetKeyFunc(int where, KeyFunc func) {
        switch (where) {
            case 1:
                Key1Func = func;
                break;
            case 2:
                Key2Func = func;
                break;
            case 3:
                Key3Func = func;
                break;
            case 4:
                Key4Func = func;
                break;
            case 5:
                MouseLeftFunc = func;
                break;
            case 6:
                MouseRightFunc = func;
                break;
        }
    }

    public void Key1Btn() {
        Key1Func();
    }
    public void Key2Btn() {
        Key2Func();
    }
    public void Key3Btn() {
        Key3Func();
    }
    public void Key4Btn() {
        Key4Func();
    }
}
