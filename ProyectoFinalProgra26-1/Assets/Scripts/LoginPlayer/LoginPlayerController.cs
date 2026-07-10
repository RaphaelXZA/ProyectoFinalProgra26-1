using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LoginPlayerController : MonoBehaviour
{
    private const string URL = "https://progra261chgrupo3.samidareno.com/login_player.php";

    public void Send(string playername, string password, Action<string> callback)
    {
        StartCoroutine(SendRequest(playername, password, callback));
    }

    private IEnumerator SendRequest(string playername, string password, Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("playername", playername);
        form.AddField("password", password);

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