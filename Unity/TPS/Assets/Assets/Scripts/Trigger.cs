using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Udemy Class.csを参考に
public class Trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public interface Skill {

}

[System.Serializable]
public abstract class SkillBase : Skill {

    public string Name;
    public Sprite SkillIcon;
    public string Description;
}

//------------------------------------------


[System.Serializable]
public abstract class ActiveSkill : SkillBase {


}

[System.Serializable]
public abstract class PassiveSkill : SkillBase {


}


//-------------------------------------------

[System.Serializable]
public abstract class GunnerSkill : ActiveSkill {
    public TypeOfBullets bullet;

}



[System.Serializable]
public abstract class SniperSkill : ActiveSkill {


}

[System.Serializable]
public abstract class BladeSkill : ActiveSkill {


}

// --------------------------------

[System.Serializable]
public class Shooter : GunnerSkill {


}

[System.Serializable]
public class AssultRifle : GunnerSkill {


}

[System.Serializable]
public class GrenadeLauncher : GunnerSkill {


}

[System.Serializable]
public class Pistol : GunnerSkill {


}

// ---------------------------------

public enum TypeOfBullets {
    Hound, Asteroid, Meteor, Viper
}

[System.Serializable]
public abstract class Bullet {
    public string Name;
}

[System.Serializable]
public class Hound : Bullet {
    
}

[System.Serializable]
public class Asteroid : Bullet {

}

[System.Serializable]
public class Meteor : Bullet {

}


[System.Serializable]
public class Viper : Bullet {

}