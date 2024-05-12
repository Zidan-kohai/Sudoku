using UnityEngine;

public class DataController : MonoBehaviour
{
    private const string path = "PlayerData";
    public static DataController Instanse;

    public PlayerData PlayerData;

    public void Awake()
    {
        if (Instanse != null) return;

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

    public void AddRecord(string hardnest, RecordData record)
    {
        if (hardnest == "Easy")
        {
            if (PlayerData.EasyRecords.Count == 0)
            {
                PlayerData.EasyRecords.Add(record);
            }
            else
            {
                for (int i = 0; i < PlayerData.EasyRecords.Count; i++)
                {
                    if (record.value.TotalSeconds < PlayerData.EasyRecords[i].value.TotalSeconds)
                    {
                        PlayerData.EasyRecords.Insert(i, record);
                    }
                }
            }
        }
        else if(hardnest == "Medium")
        {
            if (PlayerData.MediumRecords.Count == 0)
            {
                PlayerData.MediumRecords.Add(record);
            }
            else
            {
                for (int i = 0; i < PlayerData.MediumRecords.Count; i++)
                {
                    if (record.value.TotalSeconds < PlayerData.MediumRecords[i].value.TotalSeconds)
                    {
                        PlayerData.MediumRecords.Insert(i, record);
                    }
                }
            }

        }
        else if(hardnest == "Hard")
        {
            if (PlayerData.HardRecords.Count == 0)
            {
                PlayerData.HardRecords.Add(record);
            }
            else
            {
                for (int i = 0; i < PlayerData.HardRecords.Count; i++)
                {
                    if (record.value.TotalSeconds < PlayerData.HardRecords[i].value.TotalSeconds)
                    {
                        PlayerData.HardRecords.Insert(i, record);
                    }
                }
            }
        }
        Save();
    }
}
