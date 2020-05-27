using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    public AudioSource research;


    public void Start()
    {
        research = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            research.Play();
            print("Item Pick up");
            //   Destroy(gameObject);
        }
    }
}