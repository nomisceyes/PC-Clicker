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

    public void EnablePanel()
    {
        _panel.SetActive(true);
    }

    public void DisablePanel()
    {
        _panel.SetActive(false);
    }
}