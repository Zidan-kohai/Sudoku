using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Number_Button : Selectable, IPointerClickHandler, ISubmitHandler, IPointerUpHandler, IPointerExitHandler
{
    public NumberData data;
    public UnityEvent onClick;

    private void Start()
    {
        gameObject.GetComponent<Image>().sprite = data.fruitIcon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke();
        Game_Events.Place_Number_Func(data);
    }

    public void OnSubmit(BaseEventData eventData)
    {

    }
    
}
