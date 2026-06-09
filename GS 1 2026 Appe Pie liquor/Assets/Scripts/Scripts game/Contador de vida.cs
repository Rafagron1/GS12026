using UnityEngine;

public class Contadordevida : MonoBehaviour
{
    [SerializeField] private Nelso player;
    [SerializeField] private float pontos;
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.vida<pontos)
        {
            spriteRenderer.color = Color.black;
        }
    }
}
