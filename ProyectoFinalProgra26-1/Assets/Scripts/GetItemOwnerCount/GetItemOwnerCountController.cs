using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetItemOwnerCountController : MonoBehaviour
{
    private const string URL = "https://progra261chgrupo3.samidareno.com/get_item_howManyPlayersOwnIt.php";

    public void Send(int itemId, Action<ItemOwnerCountResultData> callback)
    {
        StartCoroutine(SendRequest(itemId, callback));
    }

    private IEnumerator SendRequest(int itemId, Action<ItemOwnerCountResultData> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("item_id", itemId);

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(JsonUtility.FromJson<ItemOwnerCountResultData>(www.downloadHandler.text));
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }

}
