using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimController : MonoBehaviour {
	private void Awake(){
		AudioManager.Instance().PlayBGM("Menu_DrftWood");
	}
}
