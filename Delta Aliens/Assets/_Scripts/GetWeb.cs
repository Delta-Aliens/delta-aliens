using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Class that sends an HTTP GET request to a URL and retrieves an integer value.
/// </summary>
public class GetWeb : MonoBehaviour
{
    private const string URL = "https://us-central1-delta-aliens-heat-engine.cloudfunctions.net/getCoin";

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// Coroutine that sends an HTTP GET request to the URL and retrieves an integer value.
    /// </summary>
    /// <returns>An IEnumerator that can be used with StartCoroutine to execute the coroutine.</returns>
    public IEnumerator GetCurrency()
    {
        // Send HTTP GET request to the URL using UnityWebRequest.Get method.
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest(); // Wait for request to complete.

            // If the request did not succeed, print the error message.
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Failed to get currency: " + request.error);
            }
            else
            {
                // If the request succeeded, parse the response text to an integer value and print it.
                int currency = int.Parse(request.downloadHandler.text);
                EventSystemsManager.Instance.UpdateCoin(currency); // Update the coin value in the game.
            }
        }
    }
}
