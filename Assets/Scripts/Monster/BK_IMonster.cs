using UnityEngine;

public interface BK_IMonster
{
    int ID {get;}

    string Name {get;}
    int BasePv {get;} 
    int BaseAtk {get;}
    int BaseDef {get;}
    int BaseSpeed {get;}

    int BaseCritChance {get;}
    int BaseCritDamage {get;}
    int BaseRes {get;}
    int BaseAccuracy {get;}

    Sprite Icon {get;}
}