using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Characters { None, Player, LibraryOwner, ConstructionOwner }
public enum Disposition { Neutral, Hate, Dislike, Like, Love }
public enum CharacterTraits { Neutral, Easygoing, Hardball }

[CreateAssetMenu(fileName = "NewNPC", menuName = "NPC/NPC")]
public class Character : ScriptableObject
{
    [Header("Basic Information")]
    [SerializeField] private new string name = "New NPC";
    [SerializeField] private Characters id;
    [SerializeField] private Sprite icon = null;

    [Header("Character Disposition")]
    [SerializeField] private CharacterTraits characterTrait;

    public Characters Id { get => id; set => id = value; }
}
