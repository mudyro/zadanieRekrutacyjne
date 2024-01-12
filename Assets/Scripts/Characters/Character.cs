using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public CharacterTypeScriptableObject characterType;

    float _characterSpeed;
    int _characterAngularSpeed;
    int _characterHealth;

    public bool isLeader;

    public int positionInFormationIndex;

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
        characterAgent.SetDestination(FollowingCharactersFormation.formationPositions[positionInFormationIndex]);
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