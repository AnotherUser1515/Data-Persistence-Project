using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    public string topPlayerName;
    public float topScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSave();
    }

    [System.Serializable]
    class SaveData
    {
        public string topPlayerName;
        public float topScore;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.topPlayerName = topPlayerName;
        data.topScore = topScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadSave()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            topPlayerName = data.topPlayerName;
            topScore = data.topScore;
        }
    }
}
