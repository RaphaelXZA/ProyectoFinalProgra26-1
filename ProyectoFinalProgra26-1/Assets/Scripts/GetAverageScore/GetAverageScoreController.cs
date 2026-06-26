using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetAverageScoreController : MonoBehaviour
{
    private const string URL = "http://localhost/proyectoFinalProgra26_1/get_average_score.php";

    public void Send(Action<AverageScoreResultData> callback)
    {
        StartCoroutine(SendRequest(callback));
    }

    private IEnumerator SendRequest(Action<AverageScoreResultData> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(URL))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(JsonUtility.FromJson<AverageScoreResultData>(www.downloadHandler.text));
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }

}