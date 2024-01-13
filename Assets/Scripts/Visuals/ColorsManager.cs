using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorsManager : MonoBehaviour
{
    public Color characterColor;
    float r;
    float g;
    float b;
    float a;

    Color _normal;
    Color _highlighted;
    Color _pressed;
    Color _selected;
    Color _disabled;

    ColorBlock _buttonNewColors;

    Character[] _allCharacters;

    void Awake()
    {
        _allCharacters = FindObjectOfType<FollowingCharactersFormation>().allCharacters;

        CreateCharacterColor();
        SetCharacterColor();
        CreateButtonColorBlock();
        SetButtonColors();
    }

    void CreateCharacterColor()
    {
        r = UnityEngine.Random.Range(0f,1f);
        g = UnityEngine.Random.Range(0f,1f);
        b = UnityEngine.Random.Range(0f,1f);
        a = 1;

        characterColor = new Color(r,g,b,a);
    }

    void SetCharacterColor()
    {
        foreach(Character _character in _allCharacters)
        {
            if(transform.GetSiblingIndex() -1 == _character.gameObject.transform.GetSiblingIndex())
            {
                _character.GetComponent<Renderer>().material.SetColor("_Color",characterColor);
            }
        }
    }

    void CreateButtonColorBlock()
    {
        print(characterColor);
        _normal = new Color(r,g,b,a);
        _highlighted = new Color(r*0.9f,g*0.9f,b*0.9f,a);
        _pressed = new Color(r*0.75f,g*0.75f,b*0.75f,a);
        _selected = new Color(r*0.9f,g*0.9f,b*0.9f,a);
        _disabled = new Color(r*0.75f,g*0.75f,b*0.75f,a*0.5f);

        _buttonNewColors.normalColor = _normal;
        _buttonNewColors.highlightedColor = _highlighted;
        _buttonNewColors.pressedColor = _pressed;
        _buttonNewColors.selectedColor = _selected;
        _buttonNewColors.disabledColor = _disabled;
        _buttonNewColors.colorMultiplier = 1;
    }

    void SetButtonColors()
    {
        GetComponent<Button>().colors = _buttonNewColors;
    }
}
