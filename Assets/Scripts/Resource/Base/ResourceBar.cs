using UnityEngine;
using UnityEngine.UI;

public abstract class ResourceBar : ResourceDisplay
{
    [SerializeField] protected Slider _slider;

    protected override void OnResourceChanged(int resource)
    {
        SetResource(resource);
    }

    protected override void OnMaxResourceChanged(int maxResource)
    {
        SetMaxResource(maxResource);
    }

    protected virtual void SetResource(float resource)
    {
        _slider.value = resource;
    }

    protected virtual void SetMaxResource(float maxResource)
    {
        _slider.maxValue = maxResource;
    }
}
