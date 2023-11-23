public class SmoothHealthBar : SmoothResourceBar
{
    protected virtual void OnEnable()
    {
        _character.HealthChanged += OnResourceChanged;
        _character.MaxHealthChanged += OnMaxResourceChanged;
    }

    protected virtual void OnDisable()
    {
        _character.HealthChanged -= OnResourceChanged;
        _character.MaxHealthChanged -= OnMaxResourceChanged;
    }
}
