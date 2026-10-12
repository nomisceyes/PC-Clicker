using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Computer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Popup _popup;

    private int _amount;
    public event Action<int> UpdateDisplay;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        _popup.Show(1);
        _amount++;
        UpdateDisplay?.Invoke(_amount);
    }
}