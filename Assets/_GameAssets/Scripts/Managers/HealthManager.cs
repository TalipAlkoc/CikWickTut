using System;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }

    public event Action OnPlayerDead;

    [Header("Settings")]
    [SerializeField] private int _maxHealth = 3;
    private int _currentHealth;

    [Header("References")]
    [SerializeField] private PlayerHealthUI _playerHealthUI;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Awake()
    {
        Instance = this;
    }

    public void Damage(int damageAmount)
    {

        if (_currentHealth > 0)
        {
            _currentHealth -= damageAmount;
            _playerHealthUI.AnimateDamage();
            

            if(_currentHealth <= 0)
            {
                OnPlayerDead?.Invoke();
                
            }
        }
        
    }

    public void Heal(int healAmount)
    {
        if(_currentHealth < _maxHealth)
        {
            _currentHealth = Mathf.Min(_currentHealth + healAmount, _maxHealth);
        }
    }
}
