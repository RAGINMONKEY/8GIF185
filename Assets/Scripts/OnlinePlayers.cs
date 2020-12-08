using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlinePlayers : MonoBehaviour
{
    public List<GameObject> PlayerList;
    void Start()
    {
        StartCoroutine(LateStart(0.5f));
    }


    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < players.Length; i++)
        {
            PlayerList.Add(players[i]);
        }
    }
    
}
