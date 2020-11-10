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
    private int number;

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

        if (onTower == true)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                SwitchToPlayerView();
            }
        }


    }

    public void SwitchToPlayerView()
    {
        TowerOn.setActive(false);
        TowerOn.setCurrent(0);

        TowerOn.camera.SetActive(false);
        if (this.GetComponent<Camera>() != null)
        {
            this.GetComponent<Camera>().enabled = true;
        }

        onTower = false;
        TowerOn = null;

    }

    public void SwitchToCanonView()
    {
        onTower = true;
        TowerOn.setActive(true);
        TowerOn.setCurrent(getNumber());

        TowerOn.camera.SetActive(true);
        if (this.GetComponent<Camera>() != null)
        {
            this.GetComponent<Camera>().enabled = false;
        }
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

    public void setNumber(int number)
    {
        this.number = number;
    }

    public int getNumber()
    {
        return number;
    }

    public void switchP(){

        if (onTower)
        {
            if (this.GetComponentInParent<SwitchCharacters>().getCurrCar() != number)
            {
                TowerOn.camera.SetActive(false);
            }
            else if (this.GetComponentInParent<SwitchCharacters>().getCurrCar() == number)
            {
                TowerOn.camera.SetActive(true);
            }
        }
    }
}
