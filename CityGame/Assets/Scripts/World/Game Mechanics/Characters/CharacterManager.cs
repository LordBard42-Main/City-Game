using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    [SerializeField] private List<CharacterController> characterControllers;


    private void Awake()
    {
        #region Singleton
        if(instance != null)
        {
            Debug.LogWarning("Character Manager already exists");
            Destroy(gameObject);
            return;
        }
        instance = this;
        #endregion




    }


    /// <summary>
    /// Gets Character Controller Based on Charcter ID
    /// </summary>
    /// <param name="characterID"></param>
    /// <returns></returns>
    public CharacterController GetCharacterConroller(Characters characterID)
    {
        if(characterID != default(Characters))
        {
            foreach(CharacterController characterController in characterControllers)
            {
                if (characterController.Character.Id == characterID)
                    return characterController;
            
            }

        }

        return default(CharacterController);
    }

    public List<CharacterController> Characters { get => characterControllers; private set => characterControllers = value; }
}
