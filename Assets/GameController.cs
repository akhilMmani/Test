using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject MaleUserPanel;
    public GameObject FemaleUserPanel;
    public GameObject BodySelection;
    public static string AvatarURL;
    public GameObject UIcamera;
    public GameObject MainCamera;
    public GameObject UserPanel;
    public GameObject loadingPanel;
    public TMP_InputField inputField;
    public string PlayerName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MaleAvatar()
    {
        MaleUserPanel.SetActive(true);
        BodySelection.SetActive(false);

    }
    public void FemaleAvatar()
    {
        FemaleUserPanel.SetActive(true);
        BodySelection.SetActive(false);
    }
    public void SelectUser(string avtrurl)
    {
        PlayerPrefs.SetString("avatarurl", avtrurl);
        loading();
        Debug.Log(avtrurl);
        AvatarURL = avtrurl;
        MaleUserPanel.SetActive(false);
        FemaleUserPanel.SetActive(false);
    }
    public void loading()
    {
        loadingPanel.SetActive(true);
        //Username();
    }
    public void Username()
    {
        Debug.Log("UsernamePanel");
        MainCamera.SetActive(false);
        UIcamera.SetActive(true);
        UserPanel.SetActive(true);

    }
    public void LoadEnviornment()
    {
        SceneManager.LoadScene(2);
        PlayerName = inputField.text;
        PlayerPrefs.SetString("Playername", PlayerName);
    }
}
