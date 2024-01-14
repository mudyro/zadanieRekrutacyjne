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
            if(NotLeaderButtonClicked(_character))
            {
                _character.isLeader = false;
            }
            else if(FollowingCharacterButtonClicked(_character))
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

    bool NotLeaderButtonClicked(Character _characterToCheck)
    {
        return
        (
            _characterToCheck.isLeader &&
            (transform.GetSiblingIndex() - 1 != _characterToCheck.transform.GetSiblingIndex())
        );
    }

    bool FollowingCharacterButtonClicked(Character _characterToCheck)
    {
        return
        (
            (!_characterToCheck.isLeader) && 
            (transform.GetSiblingIndex() - 1 == _characterToCheck.transform.GetSiblingIndex())
        );
    }


}
