using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealtBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;

    private Slider _slider;
    private Coroutine _fadeHealthCoroutine;


    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _player.HealthChanged += ChangeHealth;
    }
    private void OnDisable()
    {
        _player.HealthChanged -= ChangeHealth;
    }

    private void ChangeHealth(int currentHealth, int maxHealth)
    {
        float normalizedHealth = (float)currentHealth / maxHealth;
        FadeHealth(normalizedHealth);
    }

    private void FadeHealth(float normalizedHealth)
    {
        if (_fadeHealthCoroutine != null)
        {
            StopCoroutine(_fadeHealthCoroutine);
        }

        _fadeHealthCoroutine = StartCoroutine(FadeHealthCoroutine(normalizedHealth));
    }

    private IEnumerator FadeHealthCoroutine(float normalizedHealth)
    {
        while (_slider.value != normalizedHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, normalizedHealth, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
