using UnityEngine;
using System.Collections;

public abstract class SmoothResourceBar : ResourceBar
{
    [SerializeField] private float _easeSpeed;
    [SerializeField] private bool _isFullAtStart = true;

    protected float _targetResource;
    protected Coroutine _resourceUpdateCoroutine;

    protected virtual void Start()
    {
        if (_isFullAtStart)
        {
            _targetResource = _character.Health;
            _slider.value = _targetResource;
        }
    }

    protected override void OnResourceChanged(int resource)
    {
        StopAnimation();

        if (_easeSpeed > 0f)
        {
            _resourceUpdateCoroutine = StartCoroutine(UpdateResource(resource));
        }
        else
        {
            SetResource(resource);
            _targetResource = resource;
        }
    }

    protected override void OnMaxResourceChanged(int maxResource)
    {
        _targetResource = Mathf.Min(_targetResource, maxResource);

        base.OnMaxResourceChanged(maxResource);
    }

    protected virtual IEnumerator UpdateResource(int resource)
    {
        while (Mathf.Approximately(_targetResource, resource) == false)
        {
            _targetResource = Mathf.MoveTowards(_targetResource, resource, _easeSpeed * Time.deltaTime);
            SetResource(_targetResource);

            yield return null;
        }
    }

    protected virtual void StopAnimation()
    {
        if (_resourceUpdateCoroutine != null)
            StopCoroutine(_resourceUpdateCoroutine);
    }
}
