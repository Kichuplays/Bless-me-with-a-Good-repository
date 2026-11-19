using UnityEngine;

[CreateAssetMenu(menuName = "New Soul")]
public class SoulData : ScriptableObject
{
    [Header("Soul Identity")]
    public string SoulName; 
    public GameObject ModelPrefab;


    [Header("Soul Stats")]

    public int attackBonus;
    public int magicBonus;
    public int defenseBonus;
    public int agilityBonus;


    [Header("Element Resistence")]
    public elementResistence fire;
    public elementResistence ice;
    public elementResistence earth;
    public elementResistence water;
    public elementResistence wind;


    [Header("Skill")]
    public SkillData[] Skills;


}
