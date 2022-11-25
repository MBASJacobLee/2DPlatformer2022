/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{   
    public static SaveManager instance;

    public bool hasloaded;

    public SaveData activeSave;

    private void Awake() 
    {
        instance = this;

        Load();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            DeleteData();
        }
    }

    public void Save()
    {
        string dataPath = Application.persistentDataPath;

        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();

        Debug.Log("saved");
    }


    public void Load()
    {
        string dataPath = Application.persistentDataPath;

        if(System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Open);
            activeSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();

            Debug.Log("Loaded");

            hasloaded = true;
            Debug.Log(hasloaded);
        }
    }

    public void DeleteData()
    {
        string dataPath = Application.persistentDataPath;

        if(System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
            File.Delete(dataPath + "/" + activeSave.saveName + ".save");
        }
    }

    private void OnApplicationQuit() 
    {
        Save();
    }
}

[System.Serializable]
public class SaveData
{
    public string saveName;
    public Vector3 respos;
    public int test;
    //[SerializeField] private Player test;

    /*respos = vector3.zero;
    this.test = 0;
}
*/

/*if(SaveManager.instance.hasloaded)
        {
            test = SaveManager.instance.activeSave.test;
            Debug.Log(test);
        }else
        {
            SaveManager.instance.activeSave.test = test;
            this.test = 0;
        }*/