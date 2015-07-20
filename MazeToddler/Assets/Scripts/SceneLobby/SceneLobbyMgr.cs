using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneLobbyMgr : MonoBehaviour {
    //RuntimePlatform platform = Application.platform;
    public static int curStageNum = 0;

    void ChangeScene()
    {
        string strStageName = string.Format("SceneStage{0}", curStageNum);
        Application.LoadLevel(strStageName);
    }

    public void OnGoToStage0()
    {
        curStageNum = 0;
        ChangeScene();
    }

    public void OnGoToStage1()
    {
        curStageNum = 1;
        ChangeScene();
    }

    public void OnGoToStage2()
    {
        curStageNum = 2;
        ChangeScene();
    }

    public void OnGoToStage3()
    {
        curStageNum = 3;
        ChangeScene();
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
