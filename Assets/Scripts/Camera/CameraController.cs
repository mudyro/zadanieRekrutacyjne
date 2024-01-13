using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float _cameraToPlayerDistance;

    Character[] _allCharacters;

    CinemachineVirtualCamera _virtualCamera;

    void Awake()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _allCharacters = new Character[FindObjectOfType<FollowingCharactersFormation>().gameObject.transform.childCount];
    }

    void FixedUpdate()
    {
        StickCameraToLeadingPlayer();
    }

    void StickCameraToLeadingPlayer()
    {
        if(_allCharacters[0] == null)
        {
            _allCharacters = FindObjectOfType<FollowingCharactersFormation>().allCharacters;
        }

        foreach (Character _character in _allCharacters)
        {
            if(_character.isLeader)
            {
                _virtualCamera.Follow = _character.gameObject.transform;
                _virtualCamera.LookAt = _character.gameObject.transform;
            }
        }
    }

}
