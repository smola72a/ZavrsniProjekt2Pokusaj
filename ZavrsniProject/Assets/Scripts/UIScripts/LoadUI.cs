using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadUI : MonoBehaviour
{
    public Canvas OptionsCanvas;
    public Canvas MainMenuCanvas;
    public Canvas DeathCanvas;

    private static bool _created = false;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(OptionsCanvas);
        DontDestroyOnLoad(DeathCanvas);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
        MainMenuCanvas.gameObject.SetActive(false);
    }



    public void QuitGame()
    {
        Application.Quit();
    }


    public void ActivateOptionsCanvas()
    {
       MainMenuCanvas.gameObject.SetActive(false);
       OptionsCanvas.gameObject.SetActive(true);

    }

    public void ActivateMainMenuCanvas()
    {
        MainMenuCanvas.gameObject.SetActive(true);
        OptionsCanvas.gameObject.SetActive(false);
    }

    
}

