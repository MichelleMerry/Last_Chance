using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class recorder : MonoBehaviour
{
    public AudioSource research;



     void Start()
    {
       research = GetComponent<AudioSource>();
    }
   void OnCollisionEnter(Collision collision)
   {
       if (collision.gameObject.tag == "Player")

       {
           
        Debug.Log("work please");
            Destroy(gameObject);
     }
        
         }
    }

