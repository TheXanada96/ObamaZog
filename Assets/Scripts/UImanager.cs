 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class UImanager : MonoBehaviour {

public GameObject startPanel;
public GameObject gameOverPanel;
public GameObject clickText;
public GameObject diamondText;
public Text diamondLabel;
public Text score;
public Text highScore1;
public Text highScore2;
public static UImanager current;

void Awake() {
	if (current == null)
		current = this;
}

	
	void Start () {
		if (PlayerPrefs.HasKey("highScore"))
			highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
		else 
			highScore1.text = "High Score: 0";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GameStart(){
		clickText.GetComponent<Animator>().Play ("TextDisappear");
    	startPanel.GetComponent<Animator>().Play ("StartPanelDisappear");

		diamondText.SetActive(true);
	}
	
	public void GameOver(){

		score.text = PlayerPrefs.GetInt("score").ToString();
		highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
		gameOverPanel.SetActive(true);

		diamondText.SetActive(false);
	}
	public void Restart(){
		SceneManager.LoadScene(0);
	}
}
