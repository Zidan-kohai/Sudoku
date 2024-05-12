using TMPro;
using UnityEngine;

public class Record : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeView;
    [SerializeField] private TextMeshProUGUI valueView;

    public void Initialize(RecordData data)
    {
        timeView.text = data.time.ToString();
        valueView.text = data.value.ToString();  
    }
}
