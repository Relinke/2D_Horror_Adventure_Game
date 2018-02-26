using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpEvent : MonoBehaviour {
	public void EnterMainMenu(){
		SceneManager.LoadScene("MainMenu");
	}
}
