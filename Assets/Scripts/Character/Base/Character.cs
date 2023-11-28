using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected int _maxHealth;

    protected int _health;

    public int Health => _health;
    public int MaxHealth => _maxHealth;

    public event UnityAction<int, int> HealthChanged;

    protected virtual void Start()
    {
        _health = _maxHealth;

        SetMaxHealth(_maxHealth);
    }

    public virtual void SetMaxHealth(int maxHealth)
    {
        _maxHealth = Mathf.Max(maxHealth, 0);

        if (_health > _maxHealth)
            SetHealth(_health);
        else
            HealthChanged?.Invoke(_health, _maxHealth);
    }

    public virtual void TakeDamage(int damage)
    {
        SetHealth(_health - damage);
    }

    public virtual void Heal(int healAmount)
    {
        SetHealth(_health + healAmount);
    }

    protected virtual void SetHealth(int health)
    {
        _health = Mathf.Clamp(health, 0, _maxHealth);

        HealthChanged?.Invoke(_health, _maxHealth);
    }
}
