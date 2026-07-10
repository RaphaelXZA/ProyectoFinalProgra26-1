using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetItemsController : MonoBehaviour
{
    private const string URL = "https://progra261chgrupo3.samidareno.com/get_items.php";

    public void Send(Action<ItemResultData> callback)
    {
        StartCoroutine(SendRequest(callback));
    }

    private IEnumerator SendRequest(Action<ItemResultData> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(URL))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(JsonUtility.FromJson<ItemResultData>(www.downloadHandler.text));
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }

}
