using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
