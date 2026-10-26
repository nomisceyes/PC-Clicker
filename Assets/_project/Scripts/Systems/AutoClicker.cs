using System.Collections;
using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    [SerializeField] private Wallet _wallet; // БЛЯТЬ КАКОЙ НАХУЙ КОШЕЛЕК СУКА
    [SerializeField] private float _interval = 1f;
    [SerializeField] private int _incomePerTick = 0;

    private Coroutine _routine;
    private bool _running;

    public void IncreaseIncome(int value)
    {
        Debug.Log("Auto Click");
        _incomePerTick += value;
        UpdateLoop();
    }

    public void DecreaseInterval(float value)
    {
        _interval = Mathf.Max(0.1f, _interval - value);
        UpdateLoop();
    }

    private void UpdateLoop()
    {
        bool shouldRun = _incomePerTick > 0;

        if (shouldRun && !_running)
            StartLoop();
        else if (!shouldRun && _running)
            StopLoop();
    }

    private void StartLoop()
    {
        _running = true;
        _routine = StartCoroutine(TickLoop());
    }

    private void StopLoop()
    {
        _running = false;
        if (_routine != null) StopCoroutine(_routine);
        _routine = null;
    }

    private IEnumerator TickLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(_interval);
            _wallet.Add(_incomePerTick); // КАКОЙ КОШЕЛЕК ДОЛБАЕБИНА СДЕЛАТЬ ЧЕРЕЗ КОМПЬЮТЕР, КАКОГО ХУЯ У ТЕБЯ АВТОКЛИК ОБРАЩАЕТСЯ К КОШЕЛЬКУ
        }
    }

    private void OnDisable() => 
        StopLoop();
}