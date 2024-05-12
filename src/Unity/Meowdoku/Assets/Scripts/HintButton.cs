using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HintButton : Selectable, IPointerClickHandler
{
    public Grid grid;
    public TextMeshProUGUI CountView;

    private void Start()
    {
        CountView.text = DataController.Instanse.PlayerData.HintCount.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (DataController.Instanse.PlayerData.HintCount <= 0) return;

        DataController.Instanse.PlayerData.HintCount -= 1;
        DataController.Instanse.Save();
        CountView.text = DataController.Instanse.PlayerData.HintCount.ToString();
        grid.Hint();
    }
}
