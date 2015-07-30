using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerItem : MonoBehaviour {
	public GameObject playerHammer;
	public GameObject playerShell;

	public bool playerGotHammer = false;
	public bool playerGotShell = false;

	void Awake() {
		playerGotHammer = false;
		playerGotShell = false;
		playerHammer.SetActive (playerGotHammer);
		playerShell.SetActive (playerGotShell);
	}
	
	public void PlayerGotHammer() {
		playerGotHammer = true;
		playerHammer.SetActive (playerGotHammer);
	}

	public void PlayerGotShell() {
		playerGotShell = true;
		playerShell.SetActive (playerGotShell);
	}
}
