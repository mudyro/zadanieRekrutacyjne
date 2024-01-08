using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowingCharactersFormation : MonoBehaviour
{
    public static Vector3[] formationPositions;

    [SerializeField] [Range(1,5)]
    float _distanceToLeader = 1;

    Character[] _allCharacters;

    void Awake()
    {
        _allCharacters = FindObjectsOfType<Character>();
    }

    void Start()
    {
        AssignFormationPositions();
    }

    void AssignFormationPositions()
    {
        int positionIndex = 0;

        foreach(Character _character in _allCharacters)
        {
            if(!_character.isLeader)
            {
                _character.positionInFormationIndex = positionIndex;
                positionIndex++;
            }
        }
    }

    void CalculateFormationPositions()
    {
        formationPositions = new Vector3[_allCharacters.Length - 1];

        Vector3 _leadersVelocityDirection = new();
        Vector3 _nextCharacterPosition;
        Character _leader = new();

        foreach(Character _character in _allCharacters)
        {
            if(_character.isLeader)
            {
                _leader = _character;
                _leadersVelocityDirection = _character.characterAgent.velocity.normalized;
            }
        }

        foreach(Character _character in _allCharacters)
        {
            if(!_character.isLeader)
            {
                _nextCharacterPosition = _leader.gameObject.transform.position 
                -_leadersVelocityDirection * _distanceToLeader * (_character.positionInFormationIndex + 1); 
                formationPositions[_character.positionInFormationIndex] = _nextCharacterPosition;    
            }
        }
    }

    void FixedUpdate()
    {
        CalculateFormationPositions();
    }
}
