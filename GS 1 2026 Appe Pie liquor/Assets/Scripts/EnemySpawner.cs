using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool Ocupado { get; private set; }

    private GameObject inimigoAtual;

    public bool Spawnar(GameObject inimigo)
    {
        if (Ocupado)
            return false;

        inimigo.transform.position = transform.position;
        inimigo.SetActive(true);

        inimigoAtual = inimigo;
        Ocupado = true;

        return true;
    }

    public void Liberar()
    {
        inimigoAtual = null;
        Ocupado = false;
    }
}