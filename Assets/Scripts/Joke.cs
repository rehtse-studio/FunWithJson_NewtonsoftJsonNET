using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Joke : MonoBehaviour
{
    private UIManager _uiManager;
    private JokesParsinJSON _jokesParsinJSON;

    private void Start()
    {
        _uiManager = GameObject.Find("UI").GetComponent<UIManager>();
    }

    public void TakeJokeJSON(string jsonText)
    {
        _jokesParsinJSON = JsonConvert.DeserializeObject<JokesParsinJSON>(jsonText.ToString());
        _uiManager.ShowJoke(_jokesParsinJSON.Joke.ToString());
    }
}
