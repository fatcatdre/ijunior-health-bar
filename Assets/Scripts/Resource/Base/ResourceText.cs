using UnityEngine;
using TMPro;

public abstract class ResourceText : ResourceDisplay
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _resourceName;

    private int _resource;
    private int _maxResource;

    protected override void OnResourceChanged(int resource)
    {
        _resource = resource;

        DisplayResource();
    }

    protected override void OnMaxResourceChanged(int maxResource)
    {
        _maxResource = maxResource;

        DisplayResource();
    }

    protected virtual void DisplayResource()
    {
        _text.text = $"{_resourceName}: {_resource} / {_maxResource}";
    }
}
