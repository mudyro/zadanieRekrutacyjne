using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawner : MonoBehaviour
{
    public GameObject characters;
    public GameObject leaderSwitcherButtonPrefab;

    int _buttonsToSpawnAmount;

    public GameObject[] buttonsGameobjects;

    void Awake()
    {
        _buttonsToSpawnAmount = characters.transform.childCount;
        buttonsGameobjects = new GameObject[_buttonsToSpawnAmount];
        SpawnMenuButtons();
        SetButtonFunctions();
    }

    void SpawnMenuButtons()
    {
        for (int i = 0; i < _buttonsToSpawnAmount; i++)
        {
            buttonsGameobjects[i] = Instantiate(leaderSwitcherButtonPrefab,transform);
        }
    }

    void SetButtonFunctions()
    {
        foreach (var _button in buttonsGameobjects)
        {
            _button.GetComponent<Button>().onClick.AddListener(_button.GetComponent<ButtonEventsManager>().SetLeadingPlayer);
            _button.GetComponent<Button>().onClick.AddListener(Donothing);
        }
    }

    void Donothing()
    {

    }
}
