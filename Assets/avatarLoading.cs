using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace ReadyPlayerMe
{ 
public class avatarLoading : MonoBehaviour
{
        public string AvatarUrl;
        public string Username;
        public GameObject parentObject;
        public TextMeshProUGUI UsernameText;
        public GameObject LoadingCanvas;

        // Start is called before the first frame update
        void Start()
    {
        LoadAvatar();
            AvatarUrl = PlayerPrefs.GetString("avatarurl");
            Username = PlayerPrefs.GetString("Playername");
            parentObject = this.gameObject;
            UsernameText.text = Username;
            LoadingCanvas = GameObject.FindGameObjectWithTag("loading");
        }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadAvatar()
    {
        var avatarLoader = new AvatarLoader();
        avatarLoader.OnCompleted += AvatarLoadingCompleted;
        avatarLoader.OnFailed += AvatarLoadingFailed;
        avatarLoader.OnProgressChanged += AvatarLoadingProgressChanged;
            AvatarUrl = PlayerPrefs.GetString("avatarurl");
            avatarLoader.LoadAvatar(AvatarUrl);
    }
    private void AvatarLoadingCompleted(object sender, CompletionEventArgs args)
    {
        Debug.Log($"{args.Avatar.name} is imported!");

        args.Avatar.transform.SetParent(parentObject.transform);
        args.Avatar.transform.position = parentObject.transform.position;

        args.Avatar.transform.localScale = new Vector3(1, 1, 1);
            args.Avatar.name = "player";
           // args.Avatar.GetComponent<Animator>().enabled = false;
            LoadingCanvas.SetActive(false);
            

        //args.Avatar.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        //args.Avatar.layer = parentObject.layer;
        //gameObject.GetComponent<GameController>().Username();

    }

    private void AvatarLoadingFailed(object sender, FailureEventArgs args)
    {
        Debug.Log($"Failed with {args.Type}: {args.Message}");
    }

    private void AvatarLoadingProgressChanged(object sender, ProgressChangeEventArgs args)
    {
        Debug.Log($"Progress: {args.Progress * 100}%");

    }
}
}

