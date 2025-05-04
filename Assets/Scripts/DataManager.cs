using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private string savedataFile;
    public Data playerData = new Data();

    void Awake()
    {
        savedataFile = Application.persistentDataPath + "/savedata.json";

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    public class Data
    {
        public string playerName = "";

        public int highestScore = 0;
        public string highestScoreName = "";
    }

    public void SaveData()
    {
        Data save = playerData;

        string json = JsonUtility.ToJson(save);
        File.WriteAllText(savedataFile, json);
    }

    public void LoadData()
    {
        if (File.Exists(savedataFile))
        {
            playerData = JsonUtility.FromJson<Data>(File.ReadAllText(savedataFile));
        }
    }
}
