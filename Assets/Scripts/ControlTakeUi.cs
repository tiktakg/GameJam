using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ControlTakeUi : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool isTakePressed = false;


    public void OnPointerDown(PointerEventData eventData)
    {
        isTakePressed =  true;
    }

    public void OnPointerUp(PointerEventData eventData) 
    {  
        isTakePressed = false;
    }

}
