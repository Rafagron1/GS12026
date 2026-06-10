using UnityEngine;
using UnityEngine.UI;

public class VerificaColetavel : MonoBehaviour
{
    [SerializeField] private string idItem = "item_01";

    private Image sr;

    private void Awake()
    {
        sr = GetComponent<Image>();
    }

    private void Start()
    {
        VerificarSeFoiColetado();
    }

    private void VerificarSeFoiColetado()
    {
        if (PlayerPrefs.GetInt(idItem, 0) == 1)
        {
            sr.color = Color.white;
        }
    }
}
