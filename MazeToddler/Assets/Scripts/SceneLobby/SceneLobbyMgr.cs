using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneLobbyMgr : MonoBehaviour {

    //RuntimePlatform platform = Application.platform;

    public void OnStartBtn()
    {
        Application.LoadLevel("SceneStage");
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
