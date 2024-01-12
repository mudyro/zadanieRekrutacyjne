using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ButtonSpawner : MonoBehaviour
{
    public GameObject characters;
    public GameObject leaderSwitcherButtonPrefab;

    int _buttonsToSpawnAmount;

    void Awake()
    {
        _buttonsToSpawnAmount = characters.transform.childCount;
        SpawnMenuButtons();
    }

    void SpawnMenuButtons()
    {
        for (int i = 0; i < _buttonsToSpawnAmount; i++)
        {
            Instantiate(leaderSwitcherButtonPrefab,transform);
        }
    }
}
