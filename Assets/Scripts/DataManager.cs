using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Play time variables
    public static DataManager Instance;
    public string PlayerName;

    // Variables for storing highscore data
    public string HighScorePlayerName;
    public int HighScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }



    [System.Serializable]
    class DataStore
    {
        public string HighScorePlayerName;
        public int HighScore;
    }

    public void SaveData()
    {
        DataStore data = new DataStore();
        data.HighScorePlayerName = HighScorePlayerName;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataStore data = JsonUtility.FromJson<DataStore>(json);

            HighScorePlayerName = data.HighScorePlayerName;
            HighScore = data.HighScore;
        }
    }
}
