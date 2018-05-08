using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
   
   
    public InventoryUIManager InventoryUIManagerPrefab;
    public Canvas SafeZoneCanvas;
    public Canvas OptionsCanvas;
    public Canvas MainMenuCanvas;
    public Canvas DeathCanvas;

   

    private static bool _created = false;

    public Button InventoryButton;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(SafeZoneCanvas);
        DontDestroyOnLoad(OptionsCanvas);
        DontDestroyOnLoad(MainMenuCanvas);
        DontDestroyOnLoad(DeathCanvas);

        
    }

    public void SetInventoryActive ()
    {
        SafeZoneCanvas.gameObject.SetActive(false);
        InventoryUIManagerPrefab.gameObject.SetActive(true);
       
    }

    public void SetSafeZoneCanvasActive ()
    {
        SafeZoneCanvas.gameObject.SetActive(true);
        InventoryUIManagerPrefab.gameObject.SetActive(false);
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

    public void DeactivateDeathCanvas()
    {
        DeathCanvas.gameObject.SetActive(false);
    }




}
