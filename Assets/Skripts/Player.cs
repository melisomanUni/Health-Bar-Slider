using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth;
    [SerializeField] private HealtBar _healtBar;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healtBar.SetMaxHealth(_maxHealth);
    }

    //private void Update()
    //{
    //    if(Input.GetKeyDown())
    //    {

    //    }
    //}

    public void TakeDamage(int damage)
    {
        if (_currentHealth - damage >= 0)
        {
            Debug.Log("Получен урон");
            _currentHealth -= damage;
            _healtBar.SetHealth(_currentHealth);
            Debug.Log("Урон отображён");

        }
    }

    public void ReturnDamage(int damage)
    {
        if (_currentHealth + damage <= _maxHealth)
        {
            Debug.Log("Лечение получено");
            _currentHealth += damage;
            _healtBar.SetHealth(_currentHealth);
            Debug.Log("Лечение отображено");

        }
    }
}
