using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject overlayPanel;

    private void Start()
    {
        overlayPanel.SetActive(false);
    }

    public void AbrirOverlay()
    {
        overlayPanel.SetActive(true);
    }

    public void FecharOverlay()
    {
        overlayPanel.SetActive(false);
    }
    public void InicarJogo()
    {
        SceneManager.LoadScene("Main");
    }
    public void FecharJogo()
    {
        Application.Quit();
    }
}
