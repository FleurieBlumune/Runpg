using UnityEngine;
using System.Collections;

// Handles the various main menu options and executes code depending on which menu item this snippet is attached to.
// Also exits on escape press.

public class MenuManager : MonoBehaviour {

	public bool isQuit=false;
	
	void OnMouseEnter(){
		renderer.material.color=Color.red;
	}
	
	void OnMouseExit(){
		renderer.material.color=Color.white;
	}
	
	void OnMouseUp(){
		if (isQuit==true) {
			Application.Quit();
		}
		else {
			Application.LoadLevel(1);
		}
	}
	
	void Update(){
		if (Input.GetKey(KeyCode.Escape)) { Application.Quit();
		}
	}
}
