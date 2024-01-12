using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowingCharactersFormation : MonoBehaviour
{
    public static Vector3[] formationPositions;

    [SerializeField] [Range(1,5)]
    float _distanceToLeader = 1;

    public Character[] allCharacters;

    void Awake()
    {
        allCharacters = FindObjectsOfType<Character>();

        AssignFormationPositions();
    }

    public void AssignFormationPositions()
    {
        int positionIndex = 0;

        foreach(Character _character in allCharacters)
        {
            if(!_character.isLeader)
            {
                _character.characterIndex = positionIndex;
                positionIndex++;
            }
            else
            {
                _character.characterIndex = 999;
            }
        }
    }

    void CalculateFormationPositions()
    {
        formationPositions = new Vector3[allCharacters.Length - 1];

        Vector3 _leadersVelocityDirection = new();
        Vector3 _nextCharacterPosition;
        Character _leader = new();

        foreach(Character _character in allCharacters)
        {
            if(_character.isLeader)
            {
                _leader = _character;
                _leadersVelocityDirection = _character.characterAgent.velocity.normalized;
            }
        }

        foreach(Character _character in allCharacters)
        {
            if(!_character.isLeader)
            {
                _nextCharacterPosition = _leader.gameObject.transform.position 
                -_leadersVelocityDirection * _distanceToLeader * (_character.characterIndex + 1); 
                formationPositions[_character.characterIndex] = _nextCharacterPosition;    
            }
        }
    }

    void FixedUpdate()
    {
        CalculateFormationPositions();
    }
}
