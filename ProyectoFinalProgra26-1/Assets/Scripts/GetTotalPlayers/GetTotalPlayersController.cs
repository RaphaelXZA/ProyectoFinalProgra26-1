using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetTotalPlayersController : MonoBehaviour
{
    private const string URL = "https://progra261chgrupo3.samidareno.com/get_total_players.php";

    public void Send(Action<TotalPlayersResultData> callback)
    {
        StartCoroutine(SendRequest(callback));
    }

    private IEnumerator SendRequest(Action<TotalPlayersResultData> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(URL))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(JsonUtility.FromJson<TotalPlayersResultData>(www.downloadHandler.text));
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }

}
