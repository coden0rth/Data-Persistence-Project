using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public int playerScore;
    public string playerName;
    public string currentPlayer;

    private string filePath;

   void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        filePath = Path.Combine(Application.persistentDataPath, "data.json");
        LoadData();
    }

    public void Save()
    {
        SaveData saveData = new SaveData
        {
            playerScore = playerScore,
            playerName = currentPlayer
        };

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Data saved to " + filePath);
    }

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            playerScore = saveData.playerScore;
            playerName = saveData.playerName;
            Debug.Log("Data loaded from " + filePath);
        }
        else
        {
            playerScore = 0;
            playerName = "-";
            Debug.Log("No save file found. Using default values.");
        }
    }

    public void ClearData()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("Save file deleted.");
        }
    }

    [System.Serializable]
    private class SaveData
    {
        public int playerScore;
        public string playerName;
    }
}
