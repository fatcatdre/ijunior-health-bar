public class HealthDisplay : ResourceDisplay
{
    protected virtual void OnEnable()
    {
        foreach (var renderer in _resourceRenderers)
            _character.HealthChanged += renderer.Render;
    }

    protected virtual void OnDisable()
    {
        foreach (var renderer in _resourceRenderers)
            _character.HealthChanged -= renderer.Render;
    }
}
