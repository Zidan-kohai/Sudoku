using UnityEngine;
using UnityEngine.UI;

public class AchievementController : MonoBehaviour
{
    [SerializeField] private Image achievement1;
    [SerializeField] private Image achievement2;
    [SerializeField] private Image achievement3;
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
