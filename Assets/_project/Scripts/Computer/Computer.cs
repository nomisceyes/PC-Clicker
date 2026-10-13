using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Computer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PopupSpawner _popup;

    private int _amount;
    public event Action<int> UpdateDisplay;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        _popup.Spawn(transform.position, 1);
        _amount++;
        UpdateDisplay?.Invoke(_amount);
    }
}