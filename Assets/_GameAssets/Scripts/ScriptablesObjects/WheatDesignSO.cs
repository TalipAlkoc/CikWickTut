using UnityEngine;

[CreateAssetMenu(fileName ="WheatDesignSO",menuName ="SciptableObjects/WheatDesignSO")]
public class WheatDesignSO : ScriptableObject
{
    [SerializeField] private float _increaseDescreaseMultiplayer;
    [SerializeField] private float _resetBoostDuration;

    public float IncreaseDecreaseMultiplayer => _increaseDescreaseMultiplayer;
    public float ResetBoostDuration => _resetBoostDuration;
}
