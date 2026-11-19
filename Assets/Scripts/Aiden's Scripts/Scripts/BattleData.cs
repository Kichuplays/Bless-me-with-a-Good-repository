using UnityEditorInternal;
using UnityEngine;

public class BattleData : MonoBehaviour
{
    public static BattleData instance;

    [Header("Current Encounter")]
    public EncounterData CurrentEncounter;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;

        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void SetEncounter(EncounterData encounter)
    {
        CurrentEncounter = encounter;
    }

    public void ClearEncounter()
    {
        CurrentEncounter = null;    
    }
}
