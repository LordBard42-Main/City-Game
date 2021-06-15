using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
