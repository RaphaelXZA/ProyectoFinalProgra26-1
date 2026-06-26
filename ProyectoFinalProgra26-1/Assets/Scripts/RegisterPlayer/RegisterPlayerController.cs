using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RegisterPlayerController : MonoBehaviour
{
    private const string URL = "http://localhost/proyectoFinalProgra26_1/register_player.php";

    public void Send(string playername, string email, string password, Action<string> callback)
    {
        StartCoroutine(SendRequest(playername, email, password, callback));
    }

    private IEnumerator SendRequest(string playername, string email, string password, Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("playername", playername);
        form.AddField("email", email);
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
