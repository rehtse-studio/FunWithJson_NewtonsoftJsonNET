using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _jokeTMP;

    public void ShowJoke(string joke)
    {
        _jokeTMP.text = joke.ToString();
    }
}
