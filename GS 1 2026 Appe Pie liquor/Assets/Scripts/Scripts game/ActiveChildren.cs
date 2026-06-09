using UnityEngine;

public class ActiveChild : MonoBehaviour
{
    private ActiveChildrenCounter parentCounter;
    private bool isActiveTracked = false;

    private void Awake()
    {
        parentCounter = GetComponentInParent<ActiveChildrenCounter>();
    }

    private void OnEnable()
    {
        if (parentCounter != null && !isActiveTracked)
        {
            parentCounter.RegisterChildActivated();
            isActiveTracked = true;
        }
    }

    private void OnDisable()
    {
        if (parentCounter != null && isActiveTracked)
        {
            parentCounter.RegisterChildDeactivated();
            isActiveTracked = false;
        }
    }
}