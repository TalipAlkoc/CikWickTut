using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseUI : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField] private GameObject _blackBackgroundObject;
    [SerializeField] private GameObject _winPopup;
    [SerializeField] private GameObject _losePopup;

    [Header("Settings")]
    [SerializeField] private float _animationDuration = 0.3f;


    private Image _blackBackgorundImage;
    private RectTransform _winPopupTransform;
    private RectTransform _losePopupTransform;


    private void Awake()
    {
        _blackBackgorundImage = _blackBackgroundObject.GetComponent<Image>();
        _winPopupTransform = _winPopup.GetComponent<RectTransform>();
        _losePopupTransform = _losePopup.GetComponent<RectTransform>();
    }

    public void OnGameWin()
    {
        _blackBackgroundObject.SetActive(true);
        _winPopup.SetActive(true);

        _blackBackgorundImage.DOFade(0.8f, _animationDuration).SetEase(Ease.Linear);
        _winPopupTransform.DOScale(1.5f, _animationDuration).SetEase(Ease.OutBack);
    }

    public void OnGameLose()
    {
        _blackBackgroundObject.SetActive(false);
        _losePopup.SetActive(true);
        _blackBackgorundImage.DOFade(0.8f, _animationDuration).SetEase(Ease.Linear);
        _losePopupTransform.DOScale(1.5f, _animationDuration).SetEase(Ease.OutBack);
    }
}


