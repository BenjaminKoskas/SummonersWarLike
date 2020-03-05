using UnityEngine;

[CreateAssetMenu(fileName = "Monsters", menuName = "Game/Monsters/New Monster")]
public class BK_Monster : ScriptableObject, BK_IMonster
{
    [SerializeField] private int id = 0;
    public int ID => id;

    [SerializeField] private BK_EMonsterStar natStar = 0;
    public BK_EMonsterStar NatStar => natStar;

    [SerializeField] private BK_EMonsterType type = BK_EMonsterType.NONE;
    public BK_EMonsterType Type => type;

    [SerializeField] private string name = string.Empty;
    public string Name => name;

    [SerializeField] private string awakenedName = string.Empty;
    public string AwakenedName => name;

    [SerializeField] private int basePv = 0;
    public int BasePv => basePv;

    [SerializeField] private int baseAtk = 0;
    public int BaseAtk => baseAtk;

    [SerializeField] private int baseDef = 0;
    public int BaseDef => baseDef;

    [SerializeField] private int baseSpeed = 0;
    public int BaseSpeed => baseSpeed;

    [SerializeField] private int baseCritChance = 0;
    public int BaseCritChance => baseCritChance;

    [SerializeField] private int baseCritDamage = 0;
    public int BaseCritDamage => baseCritDamage;

    [SerializeField] private int baseRes = 0;
    public int BaseRes => baseRes;

    [SerializeField] private int baseAccuracy = 0;
    public int BaseAccuracy => baseAccuracy;

    [SerializeField] private Sprite icon;
    public Sprite Icon => icon;
}