using UnityEngine;

public class UpgradesDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void Start()
    {
        DisablePanel();
    }

    public void PanelControl()
    {
        if (_panel.activeSelf == false)
            EnablePanel();
        else
            DisablePanel();
    }

    private void EnablePanel()
    {
        _panel.SetActive(true);
    }

    private void DisablePanel()
    {
        _panel.SetActive(false);
    }
}