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

        if (cc.isGrounded == true && cc.velocity.magnitude > 0.1f && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().volume = Random.Range(0.5f, 1f);
            GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
            GetComponent<AudioSource>().Play();

        }

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
