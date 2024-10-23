using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class UImanager : MonoBehaviour {

public GameObject startPanel;
public GameObject gameOverPanel;
public GameObject clickText;
public Text score;
public Text highScore1;
public Text highScore2;
public static UImanager current;

void Awake() {
	if (current == null)
		current = this;
}

	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GameStart(){
		clickText.GetComponent<Animator>().Play ("TextDisappear");
    	startPanel.GetComponent<Animator>().Play ("StartPanelDisappear");
	}
	
	public void GameOver(){
		gameOverPanel.SetActive(true);
	}
	public void Restart(){
		SceneManager.LoadScene(0);
	}
}
