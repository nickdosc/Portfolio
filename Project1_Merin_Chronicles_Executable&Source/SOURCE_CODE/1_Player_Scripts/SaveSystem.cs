using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSystem
{

//Save the file in a .data file using the custom application path that the game has been launched from.
  public static void SavePlayer(PlayerCharacter player)
  {
      BinaryFormatter formatter = new BinaryFormatter();
      string path = Application.persistentDataPath + "/player.data";
      FileStream stream =  new FileStream(path, FileMode.Create);

      PlayerData data = new PlayerData(player);

      formatter.Serialize(stream, data);
      stream.Close();
  }

//Load the data that has been stored in the custom appliaction path that the game has been launched from.
  public static PlayerData LoadPlayer()
   {
      string path = Application.persistentDataPath + "/player.data";
      if(File.Exists(path)){
          BinaryFormatter formatter = new BinaryFormatter();
          FileStream stream = new FileStream(path, FileMode.Open);

          PlayerData data = formatter.Deserialize(stream) as PlayerData;
          stream.Close();
          return data;
      } 
      else
      {
          Debug.LogError("Save file note found in" + path);
          return null;
      }
  }
}
