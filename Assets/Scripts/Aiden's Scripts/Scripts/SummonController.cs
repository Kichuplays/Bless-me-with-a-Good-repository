using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SummonController : MonoBehaviour
{
    public Transform summonSpawnPoint;

    [Header("Owned Souls")]
    public List<SoulData> ownedSouls = new();

    public SoulData activeSoul;

    private GameObject activateSoulObject;


    public void Summon(SoulData summon)
    {
        if (summon == null)
        {
            return;
        }

        if (activateSoulObject!= null)
        {
            Destroy(activateSoulObject);
        }
        activeSoul = summon;

        activateSoulObject = Instantiate(summon.ModelPrefab, summonSpawnPoint.position, summonSpawnPoint.rotation);
        Debug.Log("PERSO...uhh I mean Soul ignite or sumtin");
    }

    public void SwitchSoul(SoulData newSummon)
    {
        if (newSummon == null)
        {
            return;
        }
        if (activeSoul == newSummon)
        {
            Debug.Log("That the one you already have, choose another one");
        }

        Summon(newSummon);


    }
   public int GetAttack(PlayerCombat player)
   {
        return player.attack + activeSoul.attackBonus;
   }
    public int GetMagic(PlayerCombat player)
    {
        return player.attack + activeSoul.magicBonus;
    }
    public int GetAgility(PlayerCombat player)
    {
        return player.attack + activeSoul.agilityBonus;
    }
    public int GetDefense(PlayerCombat player)
    {
        return player.attack + activeSoul.defenseBonus;
    }


}
