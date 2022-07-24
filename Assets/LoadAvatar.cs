using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Siccity.GLTFUtility;

namespace ReadyPlayerMe
{
    public class LoadAvatar : MonoBehaviour

    {
		public string avatarUrl;
		GameObject parentObject;
		//public textm

		private void Start()
        {
			loadAvatar();
			parentObject = this.gameObject;
			PlayerPrefs.GetString("avatarurl", avatarUrl);
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
	

