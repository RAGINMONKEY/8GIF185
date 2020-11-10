using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacters : MonoBehaviour
{
    public GameObject Character1, Character2;
    int currentCaracter;
    void Start()
    {
        currentCaracter = 1;

        Character1.GetComponentInChildren<Player>().setNumber(1);
        Character2.GetComponentInChildren<Player>().setNumber(2);

        Character1.GetComponent<Player>().enabled = true;
        Character2.GetComponent<Player>().enabled = false;

        Character1.GetComponent<PlayerMovementScript>().enabled = true;
        Character2.GetComponent<PlayerMovementScript>().enabled = false;

        Character1.GetComponentInChildren<PlayerAnimatorScript>().enabled = true;
        Character2.GetComponentInChildren<PlayerAnimatorScript>().enabled = false;

        Character1.GetComponentInChildren<MouseLook>().enabled = true;
        Character2.GetComponentInChildren<MouseLook>().enabled = false;

        Character1.GetComponentInChildren<Camera>().enabled = true;
        Character2.GetComponentInChildren<Camera>().enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
         SwitchCharacter(1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SwitchCharacter(2);
    }
    public void SwitchCharacter(int number)
    {
        switch(number)
        {
            case 1:

                currentCaracter = 1;

                Character1.GetComponent<Player>().enabled = true;
                Character2.GetComponent<Player>().enabled = false;

                Character1.GetComponent<PlayerMovementScript>().enabled = true;
                Character2.GetComponent<PlayerMovementScript>().enabled = false;

                Character1.GetComponentInChildren<PlayerAnimatorScript>().enabled = true;
                Character2.GetComponentInChildren<PlayerAnimatorScript>().enabled = false;

                Character1.GetComponentInChildren<MouseLook>().enabled = true;
                Character2.GetComponentInChildren<MouseLook>().enabled = false;

                Character1.GetComponentInChildren<Camera>().enabled = true;
                Character2.GetComponentInChildren<Camera>().enabled = false;

                Toast.Instance.Show("Switched to 1rst Character", 2f);
                break;

            case 2:

                currentCaracter = 2;

                Character1.GetComponent<Player>().enabled = false;
                Character2.GetComponent<Player>().enabled = true;

                Character1.GetComponent<PlayerMovementScript>().enabled = false;
                Character2.GetComponent<PlayerMovementScript>().enabled = true;

                Character1.GetComponentInChildren<PlayerAnimatorScript>().enabled = false;
                Character2.GetComponentInChildren<PlayerAnimatorScript>().enabled = true;

                Character1.GetComponentInChildren<MouseLook>().enabled = false;
                Character2.GetComponentInChildren<MouseLook>().enabled = true;

                Character1.GetComponentInChildren<Camera>().enabled = false;
                Character2.GetComponentInChildren<Camera>().enabled = true;

                Toast.Instance.Show("Switched to 2nd Character", 2f);
                break;
        }
    }

    public int getCurrCar()
    {
        return currentCaracter;
    }

    public ArrayList getControl()
    {
        ArrayList cont = new ArrayList();    // declaration
        cont.Add("clavier"); // clavier ou manette
        cont.Add("mouse");
        cont.Add("space"); // touche pour tirer reconnu par unity
        return cont;
    }

    /*public SwitchCharacters getPlayer()
    {
        return this;
    }*/
}
