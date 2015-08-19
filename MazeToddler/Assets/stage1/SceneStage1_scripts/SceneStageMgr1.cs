using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneStageMgr1 : MonoBehaviour {
	public static SceneStageMgr1 Instance;
	public Image fader;
	public bool playerGotStarFish;
	public bool paused;

    RuntimePlatform platform = Application.platform;

	void Awake() {
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy (gameObject);
		playerGotStarFish = false;
		paused = false;
	}

    public void OnBtnResult()
    {
        Application.LoadLevel("SceneResult");
    }

	void Update()
	{
		if( platform == RuntimePlatform.Android)
		{
			if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
		}
	}

	public void PlayerGotStartFish() {
		playerGotStarFish = true;
	}

	public void FadeOut() {
		paused = true;
		StartCoroutine (_FadeOut ());
	}
	
	public IEnumerator _FadeOut() {
		paused = true;
		yield return null;
		float timer = 0f;
		while (true) {
			if(fader.color == Color.black)
				break;
			fader.color = Color.Lerp (Color.clear, Color.black, timer);
			yield return null;
			timer += Time.deltaTime;
		}
	}

	public void FadeIn() {
		StartCoroutine (_FadeIn ());
	}
	public IEnumerator _FadeIn() {
		yield return null;
		float timer = 0f;
		while (true) {
			if(fader.color == Color.clear)
				break;
			fader.color = Color.Lerp (Color.black, Color.clear, timer);
			yield return null;
			timer += Time.deltaTime;
		}
		paused = false;
	}
}
