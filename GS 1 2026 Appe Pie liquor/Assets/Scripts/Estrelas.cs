using UnityEngine;

public class Estrelas : MonoBehaviour
{
    [SerializeField] private float velocidade = 2f;

    void Update()
    {
        transform.position += Vector3.left * velocidade * Time.deltaTime;

        if (transform.position.x <= -18f)
        {
            transform.position = new Vector3(
                18f,
                transform.position.y,
                transform.position.z
            );
        }
    }
}
