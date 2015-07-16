using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneMainMgr : MonoBehaviour {

	//RuntimePlatform platform = Application.platform;

	public void OnStartBtn()
	{
		Application.LoadLevel("SceneLobby");
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
