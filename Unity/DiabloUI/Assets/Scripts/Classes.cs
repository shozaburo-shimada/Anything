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
    public MonoBehaviour mono;

    //abstractでもよいが、全部実装しなきゃエラーになるので、とりあえずvirtualに
    public virtual void SkillExecute() { 
        Debug.Log("This is "+ Name + "'s skill execute base function");
    }

}

public enum Characters {

    Barbarian, Crusader, DemonHunter, Monk, WitchDoctor, Wizard
}

[System.Serializable]
public abstract class ActiveSkill : SkillBase {

    public int UseCost;
    public float CoolTime;
}

[System.Serializable]
public abstract class PassiveSkill : SkillBase {

    public string FlavorText;
}

public enum HunterSkillCategory {
    Primary, Secondary, Devices, Archery, Hunting, Defensive
}

[System.Serializable]
public abstract class DHActiveSkill : ActiveSkill {
    public HunterSkillCategory Category;
}

[System.Serializable]
public abstract class DHPassiveSkill : PassiveSkill {


}


[System.Serializable]
public class SpikeTrap : DHActiveSkill {

}

[System.Serializable]
public class Impale : DHActiveSkill {

}

[System.Serializable]
public class Bolas : DHActiveSkill {

    public override void SkillExecute() {
        base.SkillExecute();
        Debug.Log("This is bolas skill override function");
        mono.StartCoroutine(BolasRoutine());
    }

    IEnumerator BolasRoutine() {
        Debug.Log("Bolas routine first");
        yield return new WaitForSeconds(2);
        Debug.Log("Boloas routine second");
    }

}

[System.Serializable]
public class SmokeScreen : DHActiveSkill {

}


[System.Serializable]
public class HungeringArrow : DHActiveSkill {

}

[System.Serializable]
public class RapidFire : DHActiveSkill {

}


[System.Serializable]
public class Ambush : DHPassiveSkill {

}
