using UnityEngine;

public class GoldWheatCollectıble : MonoBehaviour,ICollectible
{
    [SerializeField] private WheatDesignSO _wheatDesignSO;

    [SerializeField] private PlayerController _playerController;

    


    public void Collect()
    {
        _playerController.SetMovementSpeed(_wheatDesignSO.IncreaseDecreaseMultiplayer,_wheatDesignSO.ResetBoostDuration);
        Destroy(gameObject);
    }
}
