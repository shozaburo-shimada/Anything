using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager Instance;
    public Text CategoryText;
    public GameObject SkillconObj;
    public Transform SkillScroll;

    void Awake(){
        Instance = this;
    }

    private void Start() {
        CategoryText.text = HunterSkillCa.ToString();
        GenerateSkillIcons(HunterSkillCa);
    }

    public HunterSkillCategory HunterSkillCa;
    public int CategoryPos;

    public void CategoryBtnPressed(bool LeftBtn) {
        Debug.Log("Btn Pressed. Left Button?" + LeftBtn);
        ChangeCategoryUI(LeftBtn);


    }

    public void ChangeCategoryUI(bool toLeft) {
        if(toLeft){
            CategoryPos--;
        }
        else{
            CategoryPos++;
        }

        if (CategoryPos == -1) CategoryPos = 5;
        if (CategoryPos == 6) CategoryPos = 0;

        HunterSkillCa = (HunterSkillCategory)CategoryPos;
        CategoryText.text = HunterSkillCa.ToString();

        GenerateSkillIcons(HunterSkillCa);

    }

    public void GenerateSkillIcons(HunterSkillCategory category) {

        for (int i = SkillScroll.childCount - 1; i >= 0; i--) {
            Destroy(SkillScroll.GetChild(i).gameObject);
        }

        //Demon HunterのActiveスキルを巡回、該当のカテゴリのスキルがあればオブジェクト化していく
        foreach (DHActiveSkill skill in SkillManager.Instance.HunterActiveSkills) {
            if (skill.Category == category) {

                // Skill Button Object生成
                GameObject go = Instantiate(SkillconObj); 
                // Objectの配置
                go.transform.SetParent(SkillScroll);
                // Objectにイメージをセット
                go.GetComponent<Image>().sprite = skill.SkillIcon;
                // スキル名を表示
                go.GetComponentInChildren<Text>().text = skill.Name;
                // ButtonにonClickのコールバック関数を登録
                go.GetComponent<Button>().onClick.AddListener(() => SkillBtnPressed(go.GetComponent<Button>()));


            }
        } 
    }

    public int changePos = 1;

    public void SkillChangeAccept() {
        ChangeSkillKey(changePos, CurrentSkill);

    }

    public GameObject[] KeyUIs;

    public void ChangeSkillKey(int where, DHActiveSkill skill) {
        KeyUIs[where - 1].GetComponent<Image>().sprite = skill.SkillIcon;
        KeyMap.instance.SetKeyFunc(where, skill.SkillExecute);

    }

    public DHActiveSkill CurrentSkill;

    public void SkillBtnPressed(Button btn) {
        Debug.Log("Skill, " + btn.GetComponentInChildren<Text>().text + " is Pressed");

        foreach (DHActiveSkill skill in SkillManager.Instance.HunterActiveSkills) {
            if (skill.Name == btn.GetComponentInChildren<Text>().text)
                CurrentSkill = skill;
        }

        Debug.Log("Curent Skill is "+ CurrentSkill.Name);
    }
}
