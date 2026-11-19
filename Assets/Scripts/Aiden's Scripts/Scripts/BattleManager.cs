using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Runtime.CompilerServices;
using static UnityEngine.Rendering.DebugUI.Table;

public class BattleManager : MonoBehaviour
{
    [Header("Player")]
    public PlayerCombat player;

    public SummonController summonController;

    [Header("Enemy Spawn Points")]
    public Transform[] enemySpawnPoints;


    [Header("Current Enemies")]
    public List<EnemeyCombat> enemies = new();

    [Header("Battle State")]
    public BattleState currentState;


    private int currentEnemyIndex = 0;

    private void Start()
    {
        StartBattle();
    }
   
    private void StartBattle()
    {
        if (BattleData.instance == null)
        {
            Debug.Log(" Battle Data Error");

            return;
        }

        if (BattleData.instance.CurrentEncounter == null)
        {
            Debug.Log("Current Encounter Error");
            return;
        }
        SpawnEnemies(); 

        currentState = BattleState.PlayerTurn;



        if (summonController.activeSoul == null)
        {
            if (summonController.ownedSouls.Count > 0)
            {
                summonController.Summon(
                    summonController.ownedSouls[0]
                );
            }
        }
        Debug.Log("Battle has begun");



        StartPlayerTurn();
        //6767676767676767676767676767676767676767676
    }
    private void SpawnEnemies()
    {
        EncounterData encounter = BattleData.instance.CurrentEncounter;

        for (int i = 0;
            i < encounter.enemies.Length;
            i++)
        {
            if (i >= enemySpawnPoints.Length)
            {
                Debug.Log("Add More SpawnPoints");
                break;
            }
            EnemyData enemyData = encounter.enemies[i];

            GameObject enemyObject =
                Instantiate(
                    enemyData.modelPrefab,
                    enemySpawnPoints[i].position,
                    enemySpawnPoints[i].rotation);

            EnemeyCombat enemy =
            enemyObject.AddComponent<EnemeyCombat>();
            enemy.Inititalize(enemyData);

            enemies.Add(enemy);
            
        }



    }


    private void StartPlayerTurn()
    {
        currentState = BattleState.PlayerTurn;

        Debug.Log("Player turn, pick a skill");




    }
    private void EndPlayerTurn()
    {
        if (currentState != BattleState.PlayerTurn)
        {
            return;
        }

        currentState = BattleState.EnemyTurn;

        StartEnemyTurn();

    }

    private void StartEnemyTurn()
    {
        Invoke(nameof(ExecuteEnemyTurn), 2f);



    }
    public void SwitchSummon(
    SoulData newSummon)
    {
        if (currentState !=
            BattleState.PlayerTurn)
            return;

        summonController.SwitchSoul(
            newSummon
        );

        EndPlayerTurn();
    }

    
    private void ExecuteEnemyTurn()
    {
        Debug.Log("Enemy turn. look out");

        foreach(EnemeyCombat enemy in enemies)
        {
            if (enemy == null || enemy.isDead)
            {
                continue;
            }

            EnemyAttackPlayer(enemy);

            if (player.isDead)
            {
                Defeat();
                return; 
            }

        }

        StartPlayerTurn();

    }
    private void EnemyAttackPlayer(EnemeyCombat enemy)
    {
        int damage = Mathf.Max(
            1,
            enemy.data.enemyDmg -
            summonController.GetDefense(player));


        player.TakeDamage(damage);

        Debug.Log("YOOOOO THATS ALOT OF DAMAGE");

    }

    public void PlayerAttackEnemy(EnemeyCombat enemy,SkillData data)
    {
        if (currentState!= BattleState.PlayerTurn)
        {
            return;
        }
        if (enemy == null || enemy.isDead)
        {
            return;
        }

        if (!player.UseSp(data.SPCost))
        {
            Debug.Log("No SP, brokie");

            return;
        }

        int damage = DamageCalculater.CalculateDamage(player, summonController, enemy, data);

        enemy.TakeDamage(damage);

        if (CheckVictory())
        {

            Victory();
            return;
        }

        EndPlayerTurn();
    }

    private bool CheckVictory()
    {
        foreach (EnemeyCombat enemy in enemies)
        {
            if (enemy != null &&
                !enemy.isDead)
            {
                return false;
            }
        }

        return true;
    }

    private void Victory()
    {

        currentState = BattleState.Win;


        BattleData.instance.ClearEncounter();

        Invoke(nameof(ReturnToOverworld), 2f);


    }

    private void Defeat()
    {
        currentState =
           BattleState.Lose;
    }

    private void ReturnToOverworld()
    {
        SceneManager.LoadScene(
           "Overworld"
       );


    }
}
