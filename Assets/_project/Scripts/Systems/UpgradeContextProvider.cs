using UnityEngine;

public class UpgradeContextProvider : MonoBehaviour
{
    [SerializeField] private Computer _computer;
    [SerializeField] private AutoClicker _autoClicker;

    public UpgradeContext Context { get; private set; }

    private void Awake()
    {
        Context = new UpgradeContext
        {
            Computer = _computer,
            AutoClicker = _autoClicker,
        };
    }
}