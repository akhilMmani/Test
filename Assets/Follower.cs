using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Follower : MonoBehaviour
{
	// Use this for initialization
	[SerializeField]
	public Transform target;

	public float smoothSpeed = 200f;
	public Vector3 offset;

	Vector3 desiredPosition;
	Vector3 smoothedPosition;
	public bool followPlayer = false;
	public bool followCam = false;
	public Vector3 camoffset = new Vector3(0, -1.8f, 0f);
	private Vector3 camrot;
	PhotonView view;
	public GameObject player;

	[SerializeField]
	bool editorControls = false;
	private void Start()
	{
		view = this.GetComponent<PhotonView>();
		
	}

	void FixedUpdate()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		target = player.transform;
		if (followPlayer)
		{
			if (editorControls)
			{
				SetupPlayer_Follwer();
				return;
			}
			FollowPlayer_Update();
		}
		else if (followCam)
		{
			FollowCamera();
		}

	}

	private void SetupPlayer_Follwer()
	{
		//set manual data for player script to follow
		var follow = target.gameObject.AddComponent<Follower>();
		follow.target = Camera.main.transform;
		follow.followCam = true;
		follow.offset = new Vector3(0, -2.25f, 0);
		this.enabled = false;
	}
	private void FollowPlayer_Update()
	{
		desiredPosition = target.position + offset;
		smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;
		transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, target.eulerAngles, smoothSpeed * Time.deltaTime);
	}
	private void FollowCamera()
	{
		/*if (desiredPosition == null)
			target.position = transform.position;*/
		desiredPosition = target.position + camoffset;
		smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;
		/*	if (camrot == null)
			{
				target.eulerAngles = transform.eulerAngles;
			}*/
		camrot = new Vector3(0, target.eulerAngles.y, 0);
		transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, camrot, smoothSpeed * Time.deltaTime);
	}
}
