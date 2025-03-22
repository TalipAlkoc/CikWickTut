using System;
using UnityEngine;

public class HolyWheatCollectıble : MonoBehaviour,ICollectible
{
    [SerializeField] private WheatDesignSO _wheatDesignSO;

    [SerializeField] private PlayerController _playerController;


    public void Collect()
    {
        _playerController.SetJumpForce(_wheatDesignSO.IncreaseDecreaseMultiplayer,_wheatDesignSO.ResetBoostDuration);
        Destroy(gameObject);
    }
}
