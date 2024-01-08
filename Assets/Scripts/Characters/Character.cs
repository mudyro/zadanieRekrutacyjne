using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    float _characterSpeed;
    float _characterRotationRadius;
    float _characterHealth;

    public bool isLeader;

    public int positionInFormationIndex;

    RaycastHit _hit = new RaycastHit();

    public NavMeshAgent characterAgent;

    void Awake()
    {
        characterAgent = GetComponent<NavMeshAgent>();
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
        if(isLeader)
        {
            MoveToMouseClick();
        }
        else
        {
            FollowLeadingCharacter();
        }
    }
}