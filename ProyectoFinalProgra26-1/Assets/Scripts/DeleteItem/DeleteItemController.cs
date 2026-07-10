using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DeleteItemController : MonoBehaviour
{
    private const string URL = "https://progra261chgrupo3.samidareno.com/delete_item.php";

    public void Send(int itemId, Action<string> callback)
    {
        StartCoroutine(SendRequest(itemId, callback));
    }

    private IEnumerator SendRequest(int itemId, Action<string> callback)
    {
        WWWForm form = new WWWForm();
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
