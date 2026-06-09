using UnityEngine;

public class SpawnerMisseis : MonoBehaviour
{
    public int activeCount = 0;
    private float cD = 10;
    private bool cDON = true;
    private void Awake()
    {

    }
    private void Update()
    {
        if (cDON)
        {
            cD -= Time.deltaTime;
            if (cD < 0)
            {
                Ativacao();
            }
        }
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
        cDON = true;
    }
    private void Ativacao()
    {
        foreach (Transform filho in transform)
        {
            if (!filho.gameObject.activeSelf)
            {
                filho.position = transform.position;
                filho.gameObject.SetActive(true);
                cDON = false;
                cD = 10f;
                return;
            }
        }
        }
    }