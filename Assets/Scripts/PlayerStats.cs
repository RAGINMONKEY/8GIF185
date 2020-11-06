using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int Life;
    public int startLife = 100;
    public Text LifeText;


    private void Start()
    {
        Life = startLife;
        InvokeRepeating("IncrementLife", 0f, 1f);
    }

    private void Update()
    {
        LifeText.text = "$" + Life.ToString();
    }
    void IncrementLife()
    {
        Life += 1;
    }
}
