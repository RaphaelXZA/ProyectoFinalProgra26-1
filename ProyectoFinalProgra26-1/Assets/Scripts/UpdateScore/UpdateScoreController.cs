using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class UpdateScoreController : MonoBehaviour
{
    private const string URL = "https://progra261chgrupo3.samidareno.com/update_score.php";

    public void Send(int playerId, int score, Action<string> callback)
    {
        StartCoroutine(SendRequest(playerId, score, callback));
    }

    private IEnumerator SendRequest(int playerId, int score, Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("player_id", playerId);
        form.AddField("score", score);

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