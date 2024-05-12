using System.Collections.Generic;
using UnityEngine;

public class RecordController : MonoBehaviour
{
    [SerializeField] private Type type;
    [SerializeField] private Record recordPrefab;
    [SerializeField] private Transform recordHandler;
    [SerializeField] private List<GameObject> records = new List<GameObject>();

    public Type GetType => type;

    private void Start()
    {
        SpawnRecords(DataController.Instanse.PlayerData.EasyRecords);
    }


    private void SpawnRecords(List<RecordData> dates)
    {
        Clear();

        foreach (RecordData data in dates)
        {
            Record record = Instantiate(recordPrefab, recordHandler);
            record.Initialize(data);
            records.Add(record.gameObject);
        }
    }

    private void Clear()
    {
        foreach (var item in records)
        {
            Destroy(item);
        }
    }

    public void RightMode()
    {
        switch(type)
        {
            case Type.Easy:
                type = Type.Medium;
                break;
            case Type.Medium:
                type = Type.Hard;
                break;
            case Type.Hard:
                type = Type.Easy;
                break;
        }

        switch(type)
        {
            case Type.Easy:
                SpawnRecords(DataController.Instanse.PlayerData.EasyRecords);
                break;
            case Type.Medium:
                SpawnRecords(DataController.Instanse.PlayerData.MediumRecords);
                break;
            case Type.Hard:
                SpawnRecords(DataController.Instanse.PlayerData.HardRecords);
                break;
        }
    }

    public void LeftMode()
    {
        switch (type)
        {
            case Type.Easy:
                type = Type.Hard;
                break;
            case Type.Medium:
                type = Type.Easy;
                break;
            case Type.Hard:
                type = Type.Medium;
                break;
        }

        switch (type)
        {
            case Type.Easy:
                SpawnRecords(DataController.Instanse.PlayerData.EasyRecords);
                break;
            case Type.Medium:
                SpawnRecords(DataController.Instanse.PlayerData.MediumRecords);
                break;
            case Type.Hard:
                SpawnRecords(DataController.Instanse.PlayerData.HardRecords);
                break;
        }
    }

    public enum Type
    {
        Easy,
        Medium,
        Hard
    }


        
}