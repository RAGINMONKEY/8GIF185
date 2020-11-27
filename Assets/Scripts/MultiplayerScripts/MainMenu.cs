using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private NetworkManagerLobby networkManager = null;

    [Header("UI")]
    [SerializeField] private GameObject landingPagePanel = null;

    public void HostLobby()
    {
        //when host is press, start hosting and disable panel
        
        networkManager.StartHost();
        landingPagePanel.SetActive(false);
    }
}
