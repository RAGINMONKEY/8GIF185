﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public TMP_Text interactText;
    public TMP_Text towerText;
    public float maxInteractionDistance = 1f;

    public GameObject camera;


    public bool onTower;
    private bool haveAmmo;
    private Tower TowerOn;
    private int number;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        towerText.GetComponent<TMP_Text>().enabled = false;
        onTower = false;
        haveAmmo = false;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
            if (Physics.Raycast(ray, out hit, maxInteractionDistance))
            {
               if ((hit.transform.GetComponent("Tower") != null || hit.transform.GetComponent("OnlineTower") != null) && haveAmmo)
              {
                interactText.GetComponent<TMP_Text>().enabled = true;

                    if (Input.GetButtonDown("Interact"))
                    {
                    hit.transform.GetComponent<Tower>().fillAmmo();
                    print("tour rechargé");
                    haveAmmo = false;
                     }
                }
                else if (hit.transform.GetComponent("Tower") != null || hit.transform.GetComponent("OnlineTower") != null)
            {
                    interactText.GetComponent<TMP_Text>().enabled = true;

                    if (Input.GetButtonDown("Interact"))
                    {
                        TowerOn = hit.transform.GetComponent<Tower>();
                        SwitchToCanonView();
                    }

                }else if (hit.transform.tag == "Finish")
            {
                interactText.GetComponent<TMP_Text>().enabled = true;
                if (Input.GetButtonDown("Interact"))
                {
                    haveAmmo = true;
                }
            } 

            }
            else interactText.GetComponent<TMP_Text>().enabled = false;
        
        

        if (onTower == true)
        {
            interactText.GetComponent<TMP_Text>().enabled = false;

            if (Input.GetButtonDown("Cancel"))
            {
                SwitchToPlayerView();
            }
        }


    }

    public void SwitchToPlayerView()
    {
        TowerOn.setActive(getNumber() * -1);
        TowerOn.setCurrent(getNumber() * -1);

        string cam = "Camera" + getNumber().ToString();
        TowerOn.transform.Find(cam).gameObject.SetActive(false);
        if (this.GetComponent<Camera>() != null)
        {
            this.GetComponent<Camera>().enabled = true;
        }

        onTower = false;
        TowerOn = null;

        this.GetComponent<PlayerMovementScript>().enabled = true;
        this.GetComponentInChildren<PlayerAnimatorScript>().enabled = true;
        this.GetComponent<Footstep>().enabled = true;

        towerText.GetComponent<TMP_Text>().enabled = false;
    }

    public void SwitchToCanonView()
    {
        onTower = true;
        TowerOn.setActive(getNumber());
        TowerOn.setCurrent(getNumber());

        string cam = "Camera" + getNumber().ToString();
        TowerOn.transform.Find(cam).gameObject.SetActive(true);
        if (this.GetComponent<Camera>() != null)
        {
            this.GetComponent<Camera>().enabled = false;
        }

        this.GetComponent<PlayerMovementScript>().enabled = false;
        this.GetComponentInChildren<PlayerAnimatorScript>().enabled = false;
        this.GetComponent<Footstep>().enabled = false;

        towerText.GetComponent<TMP_Text>().enabled = true;
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
            string cam = "Camera" + getNumber().ToString();
            if (this.GetComponentInParent<SwitchCharacters>().getCurrCar() != number)
            {
                TowerOn.transform.Find(cam).gameObject.SetActive(false);
            }
            else if (this.GetComponentInParent<SwitchCharacters>().getCurrCar() == number)
            {
                TowerOn.transform.Find(cam).gameObject.SetActive(true);
            }
        }
    }
}
