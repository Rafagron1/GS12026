using UnityEngine;

public class Vidaficaparada : MonoBehaviour
{
    private Vector3 posicaoInicial;

    private void Awake()
    {
        posicaoInicial = transform.position;
    }

    private void LateUpdate()
    {
        transform.position = posicaoInicial;
    }
}

