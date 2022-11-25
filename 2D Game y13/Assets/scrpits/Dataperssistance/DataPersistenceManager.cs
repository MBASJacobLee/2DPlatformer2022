using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
 
public class DataPersistenceManager : MonoBehaviour
{
    
    [SerializeField] private string fileName;
    public FileDataHandler dataHandler;
    [SerializeField] private GameData info;
    private List<IDataPersistence> dataPersistenceObjects;
    [SerializeField] private MainMenu MainMenu;
    public static DataPersistenceManager instance {get; private set; }
 
    private void Awake()
    {
        instance = this;
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
    }

 
    private void Start()
    {
        //this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        //calls fliedata handler
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }
 
 
    public void NewGame()
    {
        //creates blank file, and starts new game
        this.info = new GameData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
 
    public void LoadGame()
    {
        //loads data
        this.info = dataHandler.LoadData();
        Debug.Log("Trying to Load");
        if (this.info == null)
        {
            Debug.Log("Start a new game");
            NewGame();
        }
        else{}

        //this foreach function doesnt work and never loads the data
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(info);
            Debug.Log("Load");
        }
        Debug.Log(info.test);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   
    public void SaveGame()
    {
        //if there is no data to save it prints this
        if (this.info == null)
        {
            Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
            return;
        }
        else{}
 
        //this takes the data adds it to a list then sends it to the file data handeler scrpit to be saved
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(info);
        }
        dataHandler.SaveData(info);
    }
 
 
    private void OnApplicationQuit()
    {
        //saves game when game is stopped
        SaveGame();
        Debug.Log("trying to save");
    }
 
    //calls the interface Idatapersistance
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
 
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
 
//game data before it saves or loads
[System.Serializable]
public class GameData
{
   public int test;
   public Vector3 playerPosition;
 
   public GameData()
   {
      this.test = 0;
      playerPosition = Vector3.zero;
   }
}
