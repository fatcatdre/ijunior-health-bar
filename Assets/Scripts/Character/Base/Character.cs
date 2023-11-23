using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected int _maxHealth;

    protected int _health;

    public int Health => _health;
    public int MaxHealth => _maxHealth;

    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> MaxHealthChanged;

    protected virtual void Start()
    {
        SetMaxHealth(_maxHealth);
        SetHealth(_maxHealth);
    }

    public virtual void SetMaxHealth(int maxHealth)
    {
        _maxHealth = Mathf.Max(maxHealth, 0);

        if (_health > _maxHealth)
            SetHealth(_health);

        MaxHealthChanged?.Invoke(_maxHealth);
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

        HealthChanged?.Invoke(_health);
    }
}
