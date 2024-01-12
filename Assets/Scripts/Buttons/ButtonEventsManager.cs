using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEventsManager : MonoBehaviour
{
    FollowingCharactersFormation _followingCharactersFormation;

    Character[] _allCharacters;

    int _buttonIndex;

    ButtonEventsManager[] _buttonEventsManagers;

    void Awake()
    {
        _followingCharactersFormation = FindAnyObjectByType<FollowingCharactersFormation>();
        _allCharacters = _followingCharactersFormation.allCharacters;

        _buttonEventsManagers = FindObjectsOfType<ButtonEventsManager>();
    }

    public void SetLeadingPlayer()
    {
        foreach(Character _character in _allCharacters)
        {
            if(_character.isLeader)
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
        foreach(ButtonEventsManager _button in _buttonEventsManagers)
        {
            _button.GetComponent<Button>().interactable = true;
        }
        gameObject.GetComponent<Button>().interactable = false;
    }
}
