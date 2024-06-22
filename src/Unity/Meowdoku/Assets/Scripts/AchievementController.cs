using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI achievement1;
    [SerializeField] private TextMeshProUGUI achievement2;
    [SerializeField] private TextMeshProUGUI achievement3;
    [SerializeField] private Color succesColor;


    private void Start()
    {
        if (DataController.Instanse.PlayerData.Achievement1)
        {
            achievement1.color = succesColor;
        }
        if (DataController.Instanse.PlayerData.Achievement2)
        {
            achievement1.color = succesColor;
        }
        if (DataController.Instanse.PlayerData.Achievement3)
        {
            achievement1.color = succesColor;
        }
    }
}
