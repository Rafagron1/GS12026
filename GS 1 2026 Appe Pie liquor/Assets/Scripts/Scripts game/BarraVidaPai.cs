using UnityEngine;

public class BarraVidaPai : MonoBehaviour
{
    [SerializeField] private Transform fill;
    [SerializeField] private float vidaMaxima;

    public float vidaAtual;

    private float larguraOriginal;
    private Vector3 posicaoOriginal;

    private void OnEnable()
    {
        PontoFraco vidaTotal = GetComponentInParent<PontoFraco>();
        vidaMaxima = vidaTotal.bossHP;
        vidaAtual = vidaMaxima;

        larguraOriginal = fill.localScale.x;
        posicaoOriginal = fill.localPosition;
    }
    private void Update()
    {
        PontoFraco vidaTotal = GetComponentInParent<PontoFraco>();
        vidaAtual = vidaTotal.bossHP;
        AtualizarVida(vidaAtual);
    }
    public void AtualizarVida(float novaVida)
    {
        vidaAtual = Mathf.Clamp(novaVida, 0, vidaMaxima);

        float porcentagem = vidaAtual / vidaMaxima;

        // reduz largura
        fill.localScale = new Vector3(
            larguraOriginal * porcentagem,
            fill.localScale.y,
            fill.localScale.z
        );

        // desloca para manter a borda esquerda fixa
        fill.localPosition = new Vector3(
            posicaoOriginal.x - (larguraOriginal * (1f - porcentagem) * 0.5f),
            posicaoOriginal.y,
            posicaoOriginal.z
        );
    }
}
