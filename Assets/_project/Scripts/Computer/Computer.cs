using UnityEngine;
using UnityEngine.EventSystems;

public class Computer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Popup _popup;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        _popup.Show(1);
    }
}