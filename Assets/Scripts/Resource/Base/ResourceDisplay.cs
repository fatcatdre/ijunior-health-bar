using UnityEngine;

[DefaultExecutionOrder(10)]
public abstract class ResourceDisplay : MonoBehaviour
{
    [SerializeField] protected Character _character;

    protected virtual void OnResourceChanged(int resource) { }

    protected virtual void OnMaxResourceChanged(int maxResource) { }
}
