using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classes : MonoBehaviour {


}

public interface Skill {

}

[System.Serializable]
public abstract class SkillBase:Skill {

    public string Name;
    public Sprite SkillIcon;
    public Characters BelongToWho;
    public string Description;


}

public enum Characters {
    
    Barbarian, Crusader, DemonHunter, Monk, WitchDoctor, Wizard
}

[System.Serializable]
public abstract class ActiveSkill : SkillBase {


}

[System.Serializable]
public abstract class PassiveSkill : SkillBase {


}

[System.Serializable]
public abstract class DHActiveSkill : ActiveSkill {


}

[System.Serializable]
public abstract class DHPassiveSkill : PassiveSkill {


}


[System.Serializable]
public class SpikeTrap : DHActiveSkill {

}
