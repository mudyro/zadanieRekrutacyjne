using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterTypeScriptableObject", menuName = "ScriptableObjects/CharacterType")]
public class CharacterTypeScriptableObject : ScriptableObject
{
    [Range(2,4)]
    public float characterVelocity = 2,
    characterRotationRadius = 2,
    characterHealth = 2;

    void Awake()
    {
        RandomizeCharacterStats();
    }

    void RandomizeCharacterStats()
    {
        characterVelocity = Random.Range(2f,4f);
        characterRotationRadius = Random.Range(2f,4f);
        characterHealth = Random.Range(2f,4f);
    } 
}
