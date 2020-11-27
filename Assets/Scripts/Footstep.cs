using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    CharacterController cc;
    
    
    void Start()
    {
        cc = this.GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {

     
        if (cc.isGrounded == true && (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && GetComponent<AudioSource>().isPlaying == false)
        {
            if (Input.GetKey(KeyCode.LeftShift))

            {
                GetComponent<AudioSource>().volume = Random.Range(0.2f, 0.5f);
                GetComponent<AudioSource>().pitch = Random.Range(2f, 2.5f);
                GetComponent<AudioSource>().Play();
            }
            else
            {
                GetComponent<AudioSource>().volume = Random.Range(0.2f, 0.5f);
                GetComponent<AudioSource>().pitch = Random.Range(1.5f, 2f);
                GetComponent<AudioSource>().Play();
            }
        }

    }  
}
