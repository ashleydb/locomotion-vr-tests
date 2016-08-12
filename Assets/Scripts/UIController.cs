using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public PlayerController player;
	public Text modeText;

	// Use this for initialization
	void Start () {
	}
	
	public void ModeButtonClick() {
		player.ChangeLocomotionMode ();
		modeText.text = player.GetLocomotionModeString();
	}
}
