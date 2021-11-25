using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManagerX : MonoBehaviour
{
    public static MainManagerX Instance;
    public int bestScore;
    //public int currentScore;
    public string bestName;
    public string currentName;

    [System.Serializable]
    class SavedBestScore
    {
        public string name;
        public int score;
    }

    private string filePath()
    {
        //Debug.Log(Application.persistentDataPath);
        return Application.persistentDataPath + "/savescore.json";
        
    }
    

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveScore(string savedName, int savedScore)
    {
        SavedBestScore data = new SavedBestScore();
        data.name = savedName;
        data.score = savedScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath(), json);

    }

    public void LoadScore(ref string savedName, ref int savedScore)
    {
        if (File.Exists(filePath()))
        {
            string json = File.ReadAllText(filePath());
            SavedBestScore data = JsonUtility.FromJson<SavedBestScore>(json);

            savedName = data.name;
            savedScore = data.score;

        }
        else 
        {
            savedName = "Nobody";
            savedScore = 0;
        }
    }
}
