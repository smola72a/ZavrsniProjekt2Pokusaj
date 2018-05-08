using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
   
   
    public Canvas InventoryCanvas;
    public Canvas SafeZoneCanvas;
    public Canvas OptionsCanvas;
    public Canvas MainMenuCanvas;
    public Canvas DeathCanvas;
    public Canvas GameplayCanvas;
    public Canvas LootCanvas;

   

    private static bool _created = false;

    public Button InventoryButton;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(SafeZoneCanvas);
        DontDestroyOnLoad(OptionsCanvas);
        DontDestroyOnLoad(MainMenuCanvas);
        DontDestroyOnLoad(DeathCanvas);
        DontDestroyOnLoad(GameplayCanvas);
        DontDestroyOnLoad(LootCanvas);



    }

    public void SetInventoryActive ()
    {
        SafeZoneCanvas.gameObject.SetActive(false);
        InventoryCanvas.gameObject.SetActive(true);
       
    }

    public void SetSafeZoneCanvasActive ()
    {
        SafeZoneCanvas.gameObject.SetActive(true);
        InventoryCanvas.gameObject.SetActive(false);
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
