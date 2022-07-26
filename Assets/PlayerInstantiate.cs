using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerInstantiate : MonoBehaviour
{
    public GameObject Player;
    public string AvatarUrl;
    public string Username;
    public GameObject parentObject;
    public GameObject Menu;
    public GameObject LoadingCanvas;
    // Start is called before the first frame update
    void Start()
    {
        Player = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0);
        //LoadAvatar();
        AvatarUrl = PlayerPrefs.GetString("avatarurl");
        Username = PlayerPrefs.GetString("Playername");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Load()
    {
        LoadingCanvas.SetActive(false);
        Menu.SetActive(true);
    }
    public static void loadA()
    {
        
    }
}

       
       
