using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    private int _currentHealth;


    private void Start()
    {
        _currentHealth = _maxHealth;
    }



    public void Damage(int damageAmount)
    {

        if (_currentHealth > 0)
        {
            _currentHealth -= damageAmount;

            // todo:uı animated damage

            if(_currentHealth <= 0)
            {
                // todo: Player Dead
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
