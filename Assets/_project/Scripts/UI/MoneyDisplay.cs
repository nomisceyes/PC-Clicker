using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _wallet.OnMoneyChanged += UpdateDisplay;
    }

    private void OnDisable()
    {
        _wallet.OnMoneyChanged -= UpdateDisplay;
    }

    private void UpdateDisplay(int value)
    {
        _text.text = value.ToString() + "$";
    }
}