using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth;

    public event UnityAction<int,int> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
        HealthChanged?.Invoke(_currentHealth,_maxHealth);
    }

    public void Heal(int health)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + health, 0, _maxHealth);
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    } 
}
