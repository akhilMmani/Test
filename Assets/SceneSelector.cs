using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public GameObject player;
    //public GameObject[] Players;
    // Start is called before the first frame
    private void Awake()
    {
       
        
       
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void LoadRoom(int A)
    {
        SceneManager.LoadScene(A);
        //DontDestroyOnLoad(player);
    }
}
