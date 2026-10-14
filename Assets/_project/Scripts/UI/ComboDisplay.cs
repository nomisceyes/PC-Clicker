using TMPro;
using UnityEngine;

public class ComboDisplay : MonoBehaviour
{
    [SerializeField] private ComboSystem _combo;
    [SerializeField] private TMP_Text _text;

    private void OnEnable() => _combo.OnComboChanged += Refresh;
    private void OnDisable() => _combo.OnComboChanged -= Refresh;

    private void Refresh(int combo)
    {
        if (combo == 0)
            _text.text = string.Empty;
        else
            _text.text = $"x{_combo.Multiplier}";
    }
}