using TMPro;
using UnityEngine;

public class DescriptionTooltip : MonoBehaviour
{
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private RectTransform _tooltipRectTransform;
    [SerializeField] private float _offsetX;
    [SerializeField] private float _offsetY;

    public void UpdateTooltip(Upgrade upgrade)
    {
        if (_description != null)
            _description.text = upgrade.Data.Description;

        _cost.text = upgrade.CurrentCost.ToString();
    }

    public void ShowTooltip(Vector2 targetIcon)
    {
        gameObject.SetActive(true);
        PositionTooltip(targetIcon);
    }

    public void HideTooltip() =>
        gameObject.SetActive(false);

    private void PositionTooltip(Vector2 targetIcon)
    {
        gameObject.transform.position = targetIcon;

        _tooltipRectTransform.anchoredPosition = new Vector2(
            _tooltipRectTransform.anchoredPosition.x + _offsetX,
            _tooltipRectTransform.anchoredPosition.y + _offsetY);
    }
}