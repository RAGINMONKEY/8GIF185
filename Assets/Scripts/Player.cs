using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public TMP_Text interactText;
    public float maxInteractionDistance = 1f;

    public GameObject camera;
    

    private bool onTower;
    private Tower TowerOn;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        onTower = false;
    }

    // Update is called once per frame
    void Update()
    {
    

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxInteractionDistance))
        {
            if (hit.transform.GetComponent("Tower") != null)
            {
                interactText.GetComponent<TMP_Text>().enabled = true;

                if (Input.GetButtonDown("Interact"))
                {
                    TowerOn = hit.transform.GetComponent<Tower>();
                    SwitchToCanonView();
                }

            }

        }
        else interactText.GetComponent<TMP_Text>().enabled = false;

        if(onTower == true)
        {
            if(Input.GetButtonDown("Cancel"))
            {
                SwitchToPlayerView();
            }
        }
      

    }

    public void SwitchToPlayerView()
    {
        TowerOn.camera.SetActive(false);
        this.GetComponent<Camera>().enabled = true;

        onTower = false;
        TowerOn = null;

    }

    public void SwitchToCanonView()
    {
        onTower = true;

        TowerOn.camera.SetActive(true);
        this.GetComponent<Camera>().enabled = false;

    
    }
   
    public ArrayList getControl()
    {
        ArrayList cont = new ArrayList();    // declaration
        cont.Add("clavier");
        cont.Add("mouse");
        cont.Add("space");
        return cont;
    }

    public Player getPlayer()
    {
        return this;
    }

    public bool getCurrCar()
    {
        return true;
    }
}
