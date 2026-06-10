using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuzinho : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InicarJogo()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
