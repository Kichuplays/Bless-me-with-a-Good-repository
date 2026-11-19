using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldEnemy : MonoBehaviour
{
    public EncounterData encounterData;


    public bool canBeAttacked = true;

    private bool battleStarted = false;

    public void StartBattle()
    {
        if (!canBeAttacked)
        {
            return;
        }
        if (battleStarted)
        {
            return;
        }
        if (encounterData == null)
        {
            Debug.Log("There is no encounter data");
            return;
        }

        battleStarted = true;

        BattleData.instance.SetEncounter(encounterData);


        SceneManager.LoadScene("BattleScene"); 
        }

}
