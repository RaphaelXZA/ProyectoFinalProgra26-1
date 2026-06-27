using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetRankingController : MonoBehaviour
{
    private const string URL = "https://progra261chgrupo3.samidareno.com/get_ranking.php";

    public void Send(Action<PlayerResultData> callback)
    {
        StartCoroutine(SendRequest(callback));
    }

    private IEnumerator SendRequest(Action<PlayerResultData> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(URL))
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