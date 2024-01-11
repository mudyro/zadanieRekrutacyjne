using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterTypeScriptableObject", menuName = "ScriptableObjects/CharacterType")]
public class CharacterTypeScriptableObject : ScriptableObject
{
    [Range(2,10)]
    public float characterSpeed = 2;

    [Range(90,270)]
    public int characterAngularSpeed = 120;

    [Range(2,5)]
    public int characterHealth = 5;

    void Awake()
    {
        RandomizeCharacterStats();
    }

    void RandomizeCharacterStats()
    {
        characterSpeed = Random.Range(2f,10f);
        characterAngularSpeed = Random.Range(90,270);
        characterHealth = Random.Range(2,10);
    } 
}
