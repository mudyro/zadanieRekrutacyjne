using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public CharacterTypeScriptableObject characterType;

    float _closestDistanceToLeader = 2;
    float _currentDistanceToLeader = 999;

    float _characterSpeed;
    int _characterAngularSpeed;
    int _characterHealth;

    public bool isLeader;

    public int characterIndex = 999;

    RaycastHit _hit = new RaycastHit();

    public NavMeshAgent characterAgent;

    void Awake()
    {
        characterAgent = GetComponent<NavMeshAgent>();

        _characterSpeed = characterType.characterSpeed;
        characterAgent.speed = _characterSpeed;

        _characterAngularSpeed = characterType.characterAngularSpeed;
        characterAgent.angularSpeed = _characterAngularSpeed;

        _characterHealth = characterType.characterHealth;
    }

    void MoveToMouseClick()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(_ray,out _hit))
            {
                characterAgent.SetDestination(_hit.point);
            }
        }
    }

    void FollowLeadingCharacter()
    {
        if(_currentDistanceToLeader > _closestDistanceToLeader)
        {
            characterAgent.SetDestination(FollowingCharactersFormation.formationPositions[characterIndex]);
        }
        else
        {
            characterAgent.speed = 0;
        }
    }    

    void CalculateCurrentDistanceToLeader()
    {
        GameObject[] _charactersGameObjects = new GameObject[transform.parent.childCount];

        for (int i = 0; i < transform.parent.childCount; i++)
        {
            _charactersGameObjects[i] = transform.parent.GetChild(i).gameObject;
            
            if(_charactersGameObjects[i].GetComponent<Character>().isLeader)
            {
                _currentDistanceToLeader = UnityEngine.Vector3.Distance(transform.position,_charactersGameObjects[i].transform.position);
            }
        }
    }

    void FixedUpdate()
    {
        UpdateCharacterParameters();

        if(isLeader)
        {
            MoveToMouseClick();
        }
        else
        {
            CalculateCurrentDistanceToLeader();
            FollowLeadingCharacter();
        }
    }

    void UpdateCharacterParameters()
    {
        _characterSpeed = characterType.characterSpeed;
        characterAgent.speed = _characterSpeed;

        _characterHealth = characterType.characterHealth;
        _characterAngularSpeed = characterType.characterAngularSpeed;

        _characterHealth = characterType.characterHealth;
    }
}