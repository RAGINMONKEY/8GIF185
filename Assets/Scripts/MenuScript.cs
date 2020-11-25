using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuScript : MonoBehaviour
{
    public GameObject Menu0GO;
    public GameObject Menu1GO;
    public GameObject Menu2GO;

    [Header("LazyCoding")]
    public GameObject Panel_NameInput;
    public GameObject PanelLandingPage;
    public GameObject BackgroundEnterIpAdress;
    
    public void OnPlayOnlineButton() { Menu1GO.SetActive(true); Menu0GO.SetActive(false); }
    public void OnCancelOnlineCancelButton() 
    {            
        Menu1GO.SetActive(false);
        Panel_NameInput.SetActive(true);
        PanelLandingPage.SetActive(false);
        BackgroundEnterIpAdress.SetActive(false);
        Menu0GO.SetActive(true);         
    }
    public void OnExitButton() { Application.Quit(); }
    public void OnOptionsButton() { Menu0GO.SetActive(false); Menu2GO.SetActive(true); }
    public void OnOptionCancelButton() { Menu0GO.SetActive(true); Menu2GO.SetActive(false); }
    public void OnPlayOfflineButton() { SceneManager.LoadSceneAsync("TestingScene"); }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
