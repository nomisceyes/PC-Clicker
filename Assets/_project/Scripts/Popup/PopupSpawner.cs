using UnityEngine;
using UnityEngine.Pool;

public class PopupSpawner : MonoBehaviour
{
    [SerializeField] private Popup _popupPrefab;
    [SerializeField] private RectTransform _canvasRoot;
    [SerializeField] private float _randomOffsetX = 300f;
    [SerializeField] private float _randomOffsetY = 200f;
    [SerializeField] private float _flyHeight = 30f;

    private ObjectPool<Popup> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Popup>(
            createFunc: () => Instantiate(_popupPrefab, _canvasRoot),
            actionOnGet: (@object) => SetUp(@object),
            actionOnRelease: (@object) => Reset(@object),
            defaultCapacity: 10,
            maxSize: 10);
    }

    private void Release(Popup popup) =>
        _pool.Release(popup);

    private void Reset(Popup @object)
    {
        @object.Destroyed -= Release;
    }

    private void SetUp(Popup @object)
    {
        @object.Destroyed += Release;
    }

    public void Spawn(Vector2 localPoint, int value)
    {
        Vector2 randomOffset = new Vector2(
            Random.Range(-_randomOffsetX, _randomOffsetX),
            Random.Range(0, _randomOffsetY)
        );

        Vector2 targetPos = localPoint + randomOffset;

        Popup popup = _pool.Get();
        popup.GetComponent<RectTransform>().anchoredPosition = targetPos;
        popup.Init(targetPos, _flyHeight);
        popup.Show(value);
    }
}