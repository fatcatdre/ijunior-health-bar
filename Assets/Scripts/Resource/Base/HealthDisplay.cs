using UnityEngine;

public class HealthDisplay : ResourceDisplay
{
    [SerializeField] private ResourceRenderer[] _resourceRenderers;

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
