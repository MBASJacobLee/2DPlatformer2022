using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName) 
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData LoadData() 
    {
        //this is taking the loaded data out of the file, which works
        GameData loadedData = null;
        string fullPath = (Application.dataPath + "/text.txt");
        if (File.Exists(fullPath)) 
        {
            string dataToLoad = "";
            var stream = new FileStream(Application.dataPath + "/text.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(stream))
                {
                    dataToLoad = reader.ReadToEnd();
                }
            loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
        }
        return loadedData;
       
            /*var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Open);
            activeSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();

            Debug.Log("Loaded");

            hasloaded = true;
            Debug.Log(hasloaded);*/
        
        
        /*// use Path.Combine to account for different OS's having different path separators
        string fullPath = (Application.dataPath + "/text.txt");
        GameData loadedData = null;
        if (File.Exists(fullPath)) 
        {
            // load the serialized data from the file
            string dataToLoad = "";
            using (FileStream stream = new FileStream(fullPath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    dataToLoad = reader.ReadToEnd();
                }
            }

            // deserialize the data from Json back into the C# object
            loadedData = JsonUtility.FromJson<GameData>(dataToLoad);}*/
    }

    public void SaveData(GameData info) 
    {
        //creates a file to save info to 
        string dataToStore = JsonUtility.ToJson(info, true);
        File.WriteAllText(Application.dataPath + "/text.txt", dataToStore);
        
        //this is the copmlitcated version of the code above
        /*
        // use Path.Combine to account for different OS's having different path separators
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        // create the directory the file will be written to if it doesn't already exist
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

        // serialize the C# game data object into Json
        

        // write the serialized data to the file
        using (FileStream stream = new FileStream(fullPath, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(stream)) 
            {
                writer.Write(dataToStore);
            }
        }*/
    }
}