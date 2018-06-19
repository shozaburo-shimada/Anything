using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour {

    public static TriggerManager Instance;
    public Shooter shooter;
    public AssultRifle assult;
    public Pistol pistol;
    public GrenadeLauncher grenade;

    void awake() {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



}
