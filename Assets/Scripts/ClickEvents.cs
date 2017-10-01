using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClickEvents : MonoBehaviour {

	public void StartGame(GameObject sender)
    {
        CountdownTimer.instance.startTimer();
        Destroy(gameObject);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
