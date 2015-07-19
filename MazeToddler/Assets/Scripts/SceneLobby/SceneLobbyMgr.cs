using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneLobbyMgr : MonoBehaviour {

    //RuntimePlatform platform = Application.platform;
    public static int curStageNum = 1;
    
    public void OnGoToStage1()
    {
        curStageNum = 1;
        Application.LoadLevel("SceneStage1");
    }

    public void OnGoToStage2()
    {
        curStageNum = 2;
        Application.LoadLevel("SceneStage2");
    }

    public void OnGoToStage3()
    {
        curStageNum = 3;
        Application.LoadLevel("SceneStage3");
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
