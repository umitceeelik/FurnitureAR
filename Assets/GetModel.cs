using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Siccity.GLTFUtility;

public class GetModel : MonoBehaviour
{
    public static GetModel Instance;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        string path = Application.persistentDataPath + "/62a6f5911e270d2d0bce60ce.glb";
        Debug.Log(path);
        //ImportGLTF(path);
        //ImportGLTFAsync(path);
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void ImportGLTF()
    {
        FileDownloader.Instance.StartDownload();

        GameObject result = Importer.LoadFromFile(FileDownloader.Instance.filePath);
        Debug.Log(result.name);
    }


    public void ImportGLTF(string filepath)
    {
        GameObject result = Importer.LoadFromFile(filepath);
        Debug.Log(result.name);
    }

    void ImportGLTFAsync(string filepath)
    {
        Importer.ImportGLTFAsync(filepath, new ImportSettings(), OnFinishAsync);
    }

    void OnFinishAsync(GameObject result, AnimationClip[] animations)
    {
        Debug.Log("Finished importing " + result.name);
    }
}
