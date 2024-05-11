using UnityEngine;

public class DataController : MonoBehaviour
{
    private const string path = "PlayerData";
    public static DataController Instanse;

    public PlayerData PlayerData;

    public void Awake()
    {
        Instanse = this;

        DontDestroyOnLoad(gameObject);
        Load();
    }


    public void Save()
    {
        string json = JsonUtility.ToJson(PlayerData);

        PlayerPrefs.SetString(path, json);
    }


    public void Load()
    {
        if(PlayerPrefs.HasKey(path))
        {
            string json = PlayerPrefs.GetString(path);
            PlayerData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            PlayerData = new PlayerData();
        }
    }
}