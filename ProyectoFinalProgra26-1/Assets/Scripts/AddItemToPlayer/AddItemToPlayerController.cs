using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AddItemToPlayerController : MonoBehaviour
{
    private const string URL = "https://progra261chgrupo3.samidareno.com/add_item_toPlayer.php";

    public void Send(int playerId, int itemId, Action<string> callback)
    {
        StartCoroutine(SendRequest(playerId, itemId, callback));
    }

    private IEnumerator SendRequest(int playerId, int itemId, Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("player_id", playerId);
        form.AddField("item_id", itemId);

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
