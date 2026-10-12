using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private Computer _computer;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _computer.UpdateDisplay += UpdateDisplay;
    }

    private void OnDisable()
    {
        _computer.UpdateDisplay -= UpdateDisplay;
    }

    private void UpdateDisplay(int value)
    {
        _text.text = value.ToString() + "$";
    }
}