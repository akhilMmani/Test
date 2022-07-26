using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject ButtonCanvas;
    public GameObject player;
    public GameObject[] Players;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");  
        
        Players = GameObject.FindGameObjectsWithTag("Player");
        //DontDestroyOnLoad
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ButtonCanvas.SetActive(true);
            Debug.Log("trigger");
        }
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ButtonCanvas.SetActive(true);
        }
    }*/
}
