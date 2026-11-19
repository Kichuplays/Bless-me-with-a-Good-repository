using UnityEngine;


[CreateAssetMenu(menuName = "New Skill")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public ElementType element;
    //skills

    [Header("Combat")]
    public int SkillDamage;
    public int SPCost;
    public bool multiTarget;

    [Header("Support")]
    public int Heal;
    

}
