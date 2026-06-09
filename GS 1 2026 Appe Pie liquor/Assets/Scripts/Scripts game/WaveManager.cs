using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private int waveAtual = 0;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == 0);
        }
    }

    public void ProximaWave()
    {
        waveAtual++;

        if (waveAtual >= transform.childCount)
        {
            Debug.Log("Todas as waves concluídas!");
            BossFight();
            return;
        }

        transform.GetChild(waveAtual).gameObject.SetActive(true);

        Debug.Log("Wave " + (waveAtual + 1) + " iniciada");
    }

    private void BossFight()
    {
        Debug.Log("Boss Fight!");
    }
}