using UnityEngine;

public class MisselSpawnado : MonoBehaviour
{
    private SpawnerMisseis parentCounter;
    private bool isActiveTracked = false;

    private void Awake()
    {
        parentCounter = GetComponentInParent<SpawnerMisseis>();
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