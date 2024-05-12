using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    public float musicVolume = 1;
    public float soundVolume = 1;
    public int HintCount = 12;
    public bool IsVibrationOn = true;
    public bool Achievement1;
    public bool Achievement2;
    public bool Achievement3;
    public List<RecordData> EasyRecords = new List<RecordData>();

    public List<RecordData> MediumRecords = new List<RecordData>();

    public List<RecordData> HardRecords = new List<RecordData>();
}
