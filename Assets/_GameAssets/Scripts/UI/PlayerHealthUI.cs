using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image[] _playerHealthImages;

    [Header("Sprites")]
    [SerializeField] private Sprite _playerHealthySprite;
    [SerializeField] private Sprite _playerUnhealthySprite;

    [Header("Sprites")]
    [SerializeField] private float _scaleDuration;

    private RectTransform[] _playerHealthTransforms;


    private void Awake()
    {
        _playerHealthTransforms = new RectTransform[_playerHealthImages.Length];

        for (int i = 0; i < _playerHealthImages.Length; i++)
        {
            _playerHealthTransforms[i] = _playerHealthImages[i].gameObject.GetComponent<RectTransform>();
        }
    }

    //FOR TESTİNG
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            AnimateDamage();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            AnimateDamageForAll();
        }
    }

    public void AnimateDamage()
    {
        for (int i = 0; i < _playerHealthImages.Length; i++)
        {
            if (_playerHealthImages[i].sprite == _playerHealthySprite)
            {
                AnimateDamageSprites(_playerHealthImages[i], _playerHealthTransforms[i]);
                break;
            }
            
        }
    }

    // IF PLAYER CAUGHT BY CAT
    public void AnimateDamageForAll()
    {
        for (int i = 0; i < _playerHealthImages.Length; i++)
        {
            AnimateDamageSprites(_playerHealthImages[i], _playerHealthTransforms[i]);
        }
    }

    
    private void AnimateDamageSprites(Image activeImage , RectTransform activeImageTransform) 
    {
        activeImageTransform.DOScale(0f, _scaleDuration).SetEase(Ease.InBack).OnComplete(() =>
         {
             activeImage.sprite = _playerUnhealthySprite;
             activeImageTransform.DOScale(1f, _scaleDuration).SetEase(Ease.OutBack);
         });
    }
}
