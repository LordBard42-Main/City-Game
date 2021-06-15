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
    CharacterManager characterManager;




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

        characterManager = CharacterManager.instance;

    }

    private void Start()
    {
        gameClock = GameClock.instance;
        gameSceneManager = GameSceneManager.instance;

        foreach(CharacterController characterController in characterManager.Characters)
        {
            if (characterController.Character.Id == Characters.Player)
                continue;

            gameClock.OnHour += (characterController as NPCController).CheckSchedule;

        }
        //gameClock.OnHour += constructionWorker.CheckSchedule;
    }

    private void OnDestroy()
    {
        if(NPCManager.instance == this)
            foreach (CharacterController characterController in characterManager.Characters)
            {
                if (characterController.Character.Id == Characters.Player)
                    continue;

                gameClock.OnHour -= (characterController as NPCController).CheckSchedule;

            }
    }
}
