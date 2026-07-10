using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetTotalScoreController : MonoBehaviour
{
    private const string URL = "https://progra261chgrupo3.samidareno.com/get_total_score.php";

    public void Send(Action<TotalScoreResultData> callback)
    {
        StartCoroutine(SendRequest(callback));
    }

    private IEnumerator SendRequest(Action<TotalScoreResultData> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(URL))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(JsonUtility.FromJson<TotalScoreResultData>(www.downloadHandler.text));
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }

}
