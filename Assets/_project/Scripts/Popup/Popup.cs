using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private RectTransform _body;

    private Sequence _currentAnimation;
    private float _flyHeight;
    
    private Vector3 _targetBodyPosition;
    private Vector3 _startPosition;

    public event Action<Popup> Destroyed;
    
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _body = GetComponent<RectTransform>();
    }

    public void Init(Vector3 targetPos, float flyHeight = 30f)
    {
        _targetBodyPosition = targetPos;
        _flyHeight = flyHeight;
    }
    
    public void Show(int value)
    {
        _text.text = value + "$";
        _text.alpha = 0f;
        _text.transform.localScale = Vector3.one;

        _currentAnimation?.Kill();
        
        Vector3 startPos = _targetBodyPosition + new Vector3(0, -_flyHeight, 0);
        _body.anchoredPosition = startPos;

        _currentAnimation = DOTween.Sequence();
        _currentAnimation
            .Append(_body.DOAnchorPos(_targetBodyPosition + new Vector3(0, _flyHeight, 0), 0.25f))
            .Join(_text.DOFade(1f, 0.2f))
            .Join(_text.transform.DOScale(1.5f, 0.25f))
            .Append(_body.DOAnchorPos(_targetBodyPosition, 0.25f).SetEase(Ease.OutCirc))
            .Join(_text.transform.DOScale(1f, 0.35f))
            .Append(_text.DOFade(0f, 0.4f))
            .OnComplete(() => Destroy(gameObject)); 
    }

    public void Hide()
    {
        _currentAnimation?.Kill();
        gameObject.SetActive(false);
    }
}