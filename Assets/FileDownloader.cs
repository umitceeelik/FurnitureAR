using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FileDownloader : MonoBehaviour
{
    public string url;

    public string filePath { get; set; }

    public static FileDownloader Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void StartDownload()
    {
        StartCoroutine(DownloadFile());
    }

    private IEnumerator DownloadFile()
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        string objectName = url.Substring(url.LastIndexOf("/"));

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            // Get the downloaded data
            byte[] data = www.downloadHandler.data;

            // Save the downloaded data to a file
            filePath = Application.persistentDataPath + objectName;
            System.IO.File.WriteAllBytes(filePath, data);

            GetModel.Instance.ImportGLTF(filePath);
            // Do something with the filePath
            Debug.Log("Download complete. File saved at: " + filePath);
        }
        else
        {
            Debug.LogError("Download failed: " + www.error);
        }
    }
}
