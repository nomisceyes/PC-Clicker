using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Computer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PopupSpawner _popup;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private ComboSystem _combo;
    
    private int _baseClickPower = 1;
    private int _bonusClickPower;
    
    public int ClickPower => _baseClickPower + _bonusClickPower;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        int comboMult = _combo.RegisterClick();
        int earned = ClickPower * comboMult;
        
        _popup.Spawn(transform.position, earned);
        _wallet.Add(earned);
    }
    
    public void IncreaseClickPower(int value)
    {
        _baseClickPower += value;
    }
}