using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class NPCManager : MonoBehaviour
{

    public static NPCManager instance;

    //Singleton Managers
    GameClock gameClock;
    GameSceneManager gameSceneManager;

    //NPCS
    [SerializeField] private NPCController librarian;
    [SerializeField] private NPCController constructionWorker;




    protected void Awake()
    {

    #region Singleton
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of NPCManager found");
            Destroy(gameObject);
            return;
        }

        instance = this;
    #endregion
        


    }

    private void Start()
    {
        gameClock = GameClock.instance;
        gameSceneManager = GameSceneManager.instance;

        gameClock.OnHour += librarian.CheckSchedule;
        //gameClock.OnHour += constructionWorker.CheckSchedule;
    }
}
