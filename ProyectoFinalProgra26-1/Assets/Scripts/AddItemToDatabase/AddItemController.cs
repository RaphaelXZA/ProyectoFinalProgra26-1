using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AddItemController : MonoBehaviour
{
    private const string URL = "https://progra261chgrupo3.samidareno.com/add_item.php";

    public void Send(string itemName, string itemDescription, Action<string> callback)
    {
        StartCoroutine(SendRequest(itemName, itemDescription, callback));
    }

    private IEnumerator SendRequest(string itemName, string itemDescription, Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("item_name", itemName);
        form.AddField("item_description", itemDescription);

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