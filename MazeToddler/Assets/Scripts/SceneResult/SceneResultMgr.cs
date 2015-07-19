using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneResultMgr : MonoBehaviour {

    //RuntimePlatform platform = Application.platform;

    public void OnRetry()
    {
        int curStageNum = SceneLobbyMgr.curStageNum;
        string strStageName = string.Format("SceneStage{0}", curStageNum);
        Application.LoadLevel(strStageName);
    }

    public void OnGoToLobby()
    {
        Application.LoadLevel("SceneLobby");
    }

    public void OnGoToMain()
    {
        Application.LoadLevel("SceneMain");
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
