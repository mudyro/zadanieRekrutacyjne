using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEventsManager : MonoBehaviour
{
    FollowingCharactersFormation _followingCharactersFormation;

    Character[] _allCharacters;

    GameObject[] _buttonsGameobjects;

    void Awake()
    {
        _followingCharactersFormation = FindAnyObjectByType<FollowingCharactersFormation>();
        _allCharacters = _followingCharactersFormation.allCharacters;
        _buttonsGameobjects = FindObjectOfType<ButtonSpawner>().buttonsGameobjects;
    }

    public void SetLeadingPlayer()
    {
        foreach(Character _character in _allCharacters)
        {
            if(_character.isLeader &&
            transform.GetSiblingIndex() - 1 != _character.transform.GetSiblingIndex())
            {
                _character.isLeader = false;
            }
            else if(!_character.isLeader && 
            (transform.GetSiblingIndex() - 1 == _character.transform.GetSiblingIndex()))
            {
                _character.isLeader = true;
            }
        }

        _followingCharactersFormation.AssignFormationPositions();
    }

    public void UpdateButtonsState()
    {
        foreach(var _button in _buttonsGameobjects)
        {
            _button.GetComponent<Button>().interactable = true;
        }

        GetComponent<Button>().interactable = false;
    }

    void OnDestroy()
    {
        gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
    }
}
