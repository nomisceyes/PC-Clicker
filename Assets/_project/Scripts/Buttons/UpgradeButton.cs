using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private UpgradeSystem _upgradeSystem;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _costText;
    
    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
        _wallet.OnMoneyChanged += OnMoneyChanged;
        _upgradeSystem.OnUpgraded += OnUpgraded;

        Refresh();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
        _wallet.OnMoneyChanged -= OnMoneyChanged;
        _upgradeSystem.OnUpgraded -= OnUpgraded;
    }

    private void OnClick()
    {
        if (!_wallet.TrySpend(_upgradeSystem.CurrentCost))
            return;

        _upgradeSystem.ApplyUpgrade();
    }

    private void OnMoneyChanged(int money)
    {
        Refresh();
    }

    private void OnUpgraded()
    {
        Refresh();
    }

    private void Refresh()
    {
        _costText.text = $"{_upgradeSystem.CurrentCost}$";
        _button.interactable = _wallet.Money >= _upgradeSystem.CurrentCost;
    }
}