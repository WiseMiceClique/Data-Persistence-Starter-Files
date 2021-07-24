using System.IO;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    private string path;

    private void Awake()
    {
        path = Application.persistentDataPath + "/savefile.json";
        //File.Delete(path);
    }

    private void Start() //POLYMORPHISM ;)
    {
        MainManager.Instance.gameSaver = this;
        path = Application.persistentDataPath + "/savefile.json";
    }
    public void SaveScore(string playerName, int playerScore)
    {
        SaveData data = new SaveData(playerName, playerScore);
        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(path, jsonData);
    }

    public SaveData LoadScore()
    {
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonData);
            return data;
        }
        return new SaveData("Nobody",0);
    }

}
    [System.Serializable]
    public class SaveData
    {
        public string name;
        public int score;

        public SaveData(string playerName, int playerScore)// ABSTRACTION
        {
            name = playerName;
            score = playerScore;
        }
    }