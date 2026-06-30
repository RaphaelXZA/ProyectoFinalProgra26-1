using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DeletePlayerController : MonoBehaviour
{
    private const string URL = "https://progra261chgrupo3.samidareno.com/delete_player.php";

    public void Send(int playerId, Action<string> callback)
    {
        StartCoroutine(SendRequest(playerId, callback));
    }

    private IEnumerator SendRequest(int playerId, Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("player_id", playerId);

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(www.downloadHandler.text);
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }

}
