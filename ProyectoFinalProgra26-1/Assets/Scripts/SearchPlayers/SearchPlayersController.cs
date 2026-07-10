using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SearchPlayersController : MonoBehaviour
{
    private const string URL = "https://progra261chgrupo3.samidareno.com/search_player.php";

    public void Send(string player_name, Action<PlayerResultData> callback)
    {
        StartCoroutine(SendRequest(player_name, callback));
    }

    private IEnumerator SendRequest(string player_name, Action<PlayerResultData> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("player_name", player_name);

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(JsonUtility.FromJson<PlayerResultData>(www.downloadHandler.text));
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }

}
