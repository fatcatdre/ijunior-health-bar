using UnityEngine;
using TMPro;

public class TextResourceRenderer : ResourceRenderer
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _resourceName;

    private int _resource;
    private int _maxResource;

    public override void Render(int resource, int maxResource)
    {
        _resource = resource;
        _maxResource = maxResource;

        DisplayResource();
    }

    private void DisplayResource()
    {
        _text.text = $"{_resourceName}: {_resource} / {_maxResource}";
    }
}
