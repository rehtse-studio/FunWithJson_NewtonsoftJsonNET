using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class GetJokeWebRequest : MonoBehaviour
{
    /// <summary>
    /// URL to get the jokes as JSON
    /// </summary>
    /// 
    private string _jokesURL = "https://icanhazdadjoke.com/";
    private Joke _joke;

    private void Start()
    {
        _joke = GetComponent<Joke>();
    }

    public void JokeRequestCoroutine()
    {
        StartCoroutine(JokeRequest());
    }
    private IEnumerator JokeRequest()
    {
        using(var jokesRequest = UnityWebRequest.Get(_jokesURL))
        {
            /// <summary>
            /// Set the Headers for the API request
            /// </summary>
            /// <summary>
            /// API reference: "https://icanhazdadjoke.com/api"
            /// Fetching a random joke as JSON:
            /*
                $ curl - H "Accept: application/json" https://icanhazdadjoke.com/
                {
                    "id": "R7UfaahVfFd",
                    "joke": "My dog used to chase people on a bike a lot. It got so bad I had to take his bike away.",
                    "status": 200
                }
            */
            /// </summary>
            jokesRequest.SetRequestHeader("Accept", "application/json");
            yield return jokesRequest.SendWebRequest();

            switch (jokesRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.Log(jokesRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(jokesRequest.downloadHandler.text);
                    _joke.TakeJokeJSON(jokesRequest.downloadHandler.text);
                    break;
            }
        }
    }
}
