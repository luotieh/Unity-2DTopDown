using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class PlayerData{
    public Vector2 playerPosition;
}



public class PlayerDataManage : MonoBehaviour
{
    public Transform player;

    private string savePath;
    
    private void Awake(){
        // savePath = Path.Combine(Application.persistentDataPath, "saveData.json");
        savePath = "Assets/Saves/saveData.json";
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.O)){
            Save();
        }
        else if(Input.GetKeyDown(KeyCode.P)){
            Load();
        }
    }

    private void Save(){
        PlayerData saveData = new PlayerData();

        saveData.playerPosition = player.position;

        string jsonData = JsonUtility.ToJson(saveData);

        File.WriteAllText(savePath, jsonData);

        Debug.Log("save ok!");

    }

    private void Load(){
        string jsonData = File.ReadAllText(savePath);

        PlayerData loadData = JsonUtility.FromJson<PlayerData>(jsonData);

        player.position = loadData.playerPosition;

        Debug.Log("load ok!");

    }

}
