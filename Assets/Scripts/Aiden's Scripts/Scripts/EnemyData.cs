using UnityEngine;


[CreateAssetMenu(menuName ="New EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("Enemy")]
    public string enemyName;
    public GameObject modelPrefab;

    [Header("Enemy Stats")]
    public int enemyHealth;
    public int enemyDmg;
    public int magic;
    public int defense;

    [Header("Enemy Resistence")]
    public elementResistence fire;
    public elementResistence water;
    public elementResistence earth;
    public elementResistence wind;
    public elementResistence ice;

    [Header("Skills")]
    public SkillData[] skills;

}
