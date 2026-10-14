using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private UpgradeSystem _upgradeSystem;
    [SerializeField] private UpgradeData _data;
    [SerializeField] private DescriptionTooltip _tooltip;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Button _button;

    private Upgrade _upgrade;

    private void Awake()
    {
        _upgrade = _upgradeSystem.GetUpgrade(_data);
    }

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

    private void OnClick() => _upgradeSystem.TryPurchase(_data);

    private void OnUpgraded(Upgrade upgrade)
    {
        if (upgrade.Data != _data) return;
        
        _tooltip.UpdateTooltip(upgrade);
        Refresh();
    }

    private void OnMoneyChanged(int money) => Refresh();

    private void Refresh()
    {
        _button.interactable = !_upgrade.IsMaxLevel && _wallet.Money >= _upgrade.CurrentCost;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _tooltip.UpdateTooltip(_upgrade);
        _tooltip.ShowTooltip(transform.position);
    }

    public void OnPointerExit(PointerEventData eventData) => _tooltip.HideTooltip();
}