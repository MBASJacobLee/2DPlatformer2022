using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is the inferface the save game ref to
public interface IDataPersistence
{
   void LoadData(GameData info);
 
   void SaveData(GameData info);
}
