using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetPlayerInventoryController : MonoBehaviour
{
    private const string URL = "https://progra261chgrupo3.samidareno.com/get_player_inventory.php";

    public void Send(int playerId, Action<PlayerInventoryResultData> callback)
    {
        StartCoroutine(SendRequest(playerId, callback));
    }

    private IEnumerator SendRequest(int playerId, Action<PlayerInventoryResultData> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("player_id", playerId);

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(JsonUtility.FromJson<PlayerInventoryResultData>(www.downloadHandler.text));
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }

}
