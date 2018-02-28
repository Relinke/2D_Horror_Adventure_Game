using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimController : MonoBehaviour {
	public Animator SceneAnimator;
	private void Awake(){
		AudioManager.Instance().PlayBGM("Menu_DrftWood");
	}

	public void OnStartAnimEnd(){
		SceneAnimator.Play("Main Menu Sea");
	}
}
