using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameLogic : NetworkBehaviour
{

	public GameObject player;
	public GameObject eventSystem;
	public GameObject startUI, restartUI;
	public GameObject directionalLight;

	public float targetTime = 600.0f;
	public bool ready = false;


	public float XRotateAmount = 1f;
	public float YRotateAmount = 1f;
	public float ZRotateAmount = 1f;

	private Quaternion initialRotation;
	private bool shouldRotate;
	private bool restoreRotation = false;

	void Start()
	{
		this.initialRotation = this.transform.rotation;

	}

	private void Instance_TimerStart(int timeLeft)
	{
		this.shouldRotate = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (ready == true)
		{

			if (directionalLight)
			{
				directionalLight.transform.Rotate(new Vector3(XRotateAmount, YRotateAmount, ZRotateAmount) * Time.deltaTime);
			}



			if (targetTime <= 0.0f)
			{
				timerEnded();
			}
		}

	}


	public void startPuzzle()
	{ //Begin the puzzle sequence
		startUI.SetActive(false);
		targetTime -= Time.deltaTime;
		ready = true;
		Debug.Log("foo");

	}




	public void resetGame()
	{
		restartUI.SetActive(false);
		startUI.SetActive(true);
		NetworkManager.singleton.ServerChangeScene("main");
	}


	public void gameOver()
	{
		restartUI.SetActive(true);

	}

	void timerEnded()
	{
		restartUI.SetActive(true);
		ready = false;
		//do your stuff here.
	}

}