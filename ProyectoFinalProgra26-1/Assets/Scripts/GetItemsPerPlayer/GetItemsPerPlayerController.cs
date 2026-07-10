using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetItemsPerPlayerController : MonoBehaviour
{
    private const string URL = "https://progra261chgrupo3.samidareno.com/get_items_perPlayer.php";

    public void Send(Action<ItemsPerPlayerResultData> callback)
    {
        StartCoroutine(SendRequest(callback));
    }

    private IEnumerator SendRequest(Action<ItemsPerPlayerResultData> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(URL))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(JsonUtility.FromJson<ItemsPerPlayerResultData>(www.downloadHandler.text));
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }

}
