using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static ManagerScript Instance;
    public static int highestScore = 0;
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }
    
    public void SetScore(int newScore)
    {
        highestScore = newScore;
    }
    public int GetScore()
    {
        return highestScore;
    }
    public void ChangeScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void Quit()
    {
        Save();
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
    public void Save()
    {
        SaveData data = new SaveData();
        data.highestScore = highestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "\\Savefile.json", json);
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "\\Savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highestScore = data.highestScore;
        }else
        {
            Debug.Log("No file exist");
        }   
    }
}

[System.Serializable]
class SaveData
{
    public int highestScore;
}
