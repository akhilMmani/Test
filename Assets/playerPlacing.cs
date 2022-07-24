using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
namespace ReadyPlayerMe
{ 
public class playerPlacing : MonoBehaviour
{
    public GameObject Player;
    public Transform PlayerPos;
	public GameObject parentObject;
	public string avatarUrl;
		public GameObject UserPanel;
		public TextMeshProUGUI loadingText;
		public GameObject MainCamera;
		public GameObject UIcamera;
		public GameObject LoadingCanvas;
        // Start is called before the first frame update
        private void Awake()
        {
			PlayerPrefs.GetString("avatarurl", avatarUrl);
			avatarUrl = PlayerPrefs.GetString("avatarurl");
		}
        void Start()
    {
		loadAvatar();
		//parentObject = this.gameObject;
		//PlayerPrefs.GetString("avatarurl", avatarUrl);
			avatarUrl = PlayerPrefs.GetString("avatarurl");
			Debug.Log(avatarUrl);
		}
	private void loadAvatar()
	{
		var avatarLoader = new AvatarLoader();
		avatarLoader.OnCompleted += AvatarLoadingCompleted;
		avatarLoader.OnFailed += AvatarLoadingFailed;
		avatarLoader.OnProgressChanged += AvatarLoadingProgressChanged;

		avatarLoader.LoadAvatar(avatarUrl);
	}

	private void AvatarLoadingCompleted(object sender, CompletionEventArgs args)
	{
		Debug.Log($"{args.Avatar.name} is imported!");
			
			args.Avatar.transform.SetParent(parentObject.transform);
			args.Avatar.transform.position = parentObject.transform.position;
			 
			args.Avatar.transform.localScale = new Vector3(1, 1, 1);
			//args.Avatar.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
			//args.Avatar.layer = parentObject.layer;
			//gameObject.GetComponent<GameController>().Username();
			Debug.Log("UsernamePanel");
			MainCamera.SetActive(false);
			UIcamera.SetActive(true);
			UserPanel.SetActive(true);
			LoadingCanvas.SetActive(false);
		}

	private void AvatarLoadingFailed(object sender, FailureEventArgs args)
	{
		Debug.Log($"Failed with {args.Type}: {args.Message}");
	}

	private void AvatarLoadingProgressChanged(object sender, ProgressChangeEventArgs args)
	{
		Debug.Log($"Progress: {args.Progress * 100}%");
			loadingText.text = args.Progress.ToString();
	}
}
}
