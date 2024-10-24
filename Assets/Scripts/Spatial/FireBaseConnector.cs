using System;
using System.Collections; // 确保引入IEnumerator的命名空间
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

[Serializable]
public class PostData
{
    public string username;
    public string typeEvent;
    public string time;
    public string val;
}

public class FireBaseConnector : MonoBehaviour
{
    private string UserName;
    private PostData postData;

    void Start()
    {
        UserName = "Haoting";
        Debug.Log(UserName);
        CheckNetworkConnection();
        NextButtonEvent("str", "val");
    }
    private void CheckNetworkConnection()
    {
        StartCoroutine(TestConnection());
    }

    IEnumerator TestConnection()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("https://www.google.com"))
        {
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Network error: " + request.error);
            }
            else
            {
                Debug.Log("Internet is accessible.");
            }
        }
    }

    public void NextButtonEvent(string eventType, string value)
    {   

        postData = new PostData
        {
            username = UserName,
            typeEvent = "ClickNextButton",
            time = "01/09/2024 12:25pm",
            val = "0"
        };
        PostToDatabase();
    }

    private void PostToDatabase()
    {
        string jsonData = JsonUtility.ToJson(postData);
        StartCoroutine(Post("https://salucity-d1352-default-rtdb.firebaseio.com/records.json", jsonData));
    }

    IEnumerator Post(string url, string json)
    {
        byte[] jsonToSend = new UTF8Encoding().GetBytes(json);
        using (UnityWebRequest request = UnityWebRequest.Post(url, UnityWebRequest.kHttpVerbPOST))
        {
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error posting data: " + request.error);
            }
            else
            {
                Debug.Log("Data posted successfully!");
                Debug.Log("Response: " + request.downloadHandler.text);
            }
        }
    }
}