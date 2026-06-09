using UnityEngine;

public class ActiveChildrenCounter : MonoBehaviour
{
    public int activeCount = 0;
    private WaveManager manager;
    private void Awake()
    {
        manager = GetComponentInParent<WaveManager>();
    }
    public void RegisterChildActivated()
    {
        activeCount++;
        Debug.Log("Child ativado. Total: " + activeCount);
    }

    public void RegisterChildDeactivated()
    {
        activeCount--;

        if (activeCount < 0)
            activeCount = 0;

        Debug.Log("Child desativado. Total: " + activeCount);

        if (activeCount == 0)
        {
            AllChildrenInactive();
        }
    }

    private void AllChildrenInactive()
    {
        Debug.Log("TODOS OS FILHOS ESTÃO DESATIVADOS");
        manager.ProximaWave();
    }
}