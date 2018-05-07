using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {
    public static SkillManager Instance;

    public SpikeTrap SpikeTrap;
    public Impale Impale;
    public Bolas Bolas;
    public SmokeScreen SmokeScreen;
    public HungeringArrow HungeringArrow;
    public RapidFire RapidFire;
    public Ambush Ambush;

    public List<Skill> AllSkills = new List<Skill>();
    public List<DHActiveSkill> HunterActiveSkills = new List<DHActiveSkill>();

    private void Awake(){
        Instance = this;　//UI ManagerでListを参照させるため
        Setting();
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Setting() {
        AllSkills.Add(SpikeTrap);
        AllSkills.Add(Impale);
        AllSkills.Add(Bolas);
        AllSkills.Add(SmokeScreen);
        AllSkills.Add(HungeringArrow);
        AllSkills.Add(RapidFire);
        AllSkills.Add(Ambush);

        foreach (Skill sk in AllSkills) {
            if (sk is DHActiveSkill){
                DHActiveSkill ask = sk as DHActiveSkill;
                ask.mono = this;
                ask.BelongToWho = Characters.DemonHunter;
                HunterActiveSkills.Add(ask);
            }
            else if (sk is DHPassiveSkill) {
                DHPassiveSkill psk = sk as DHPassiveSkill;
                psk.mono = this;
                psk.BelongToWho = Characters.DemonHunter;
            }
        }

    }

}
