using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneStageMgr0 : MonoBehaviour {
	public static SceneStageMgr0 Instance;

	public GameObject sceneClearedUIPrefab;

	public PlayerItem playerItemUI;
    //RuntimePlatform platform = Application.platform;

	void Awake() {
		if (Instance == null) {
			Instance = this;
		} else if (Instance != this) {
			Destroy(gameObject);
		}
	}

    public void OnBtnResult()
    {
        Application.LoadLevel("SceneResult");
    }

	public void PlayerReachedGoal() {
		Instantiate (sceneClearedUIPrefab);
	}

	public void BackToLobby() {
		Application.LoadLevel("SceneLobby");
	}

	public void AcquiredHammer() {
		playerItemUI.PlayerGotHammer ();
	}

	public void AcquiredShell() {
		playerItemUI.PlayerGotShell ();
	}

	public bool PlayerHasHammer() {
		return playerItemUI.playerGotHammer;
	}

	public bool PlayerHasShell() {
		return playerItemUI.playerGotShell;
	}

	/*
	public void OnQuitBtn()
	{
		Application.Quit();
	}

	void Update()
	{
		if( platform == RuntimePlatform.Android)
		{
			if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
		}
	}
	*/
}
