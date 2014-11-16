using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour
{
	public int RightMargin;
	public int BottomMargin;
	public int StartButtonWidth;
	public int StartButtonHeight;
	private Rect startButtonRect;
	public string StartButtonSceneToLoad;

	public Texture StartButtonNormal;
	public Texture StartButtonHover;
	public Texture StartButtonActive;

	//public AudioClip HoverSound;
	//private bool playingSound;
	//private float timeLeft;

	void Start ()
	{
		this.startButtonRect = new Rect(Screen.width - this.RightMargin - this.StartButtonWidth,
			                            Screen.height - this.BottomMargin - this.StartButtonHeight,
			                            this.StartButtonWidth,
			                            this.StartButtonHeight);

		// Get the game manager and make it persist through scenes
		GameManager gameManager = FindObjectOfType<GameManager> ();
		GameObject.DontDestroyOnLoad (gameManager);

		//playingSound = false;
		//timeLeft = 0.0f;

	}

	/*
	void Update() {
		if (!playingSound && this.startButtonRect.Contains (Input.mousePosition)) {
			audio.PlayOneShot (HoverSound);
			playingSound = true;
			timeLeft += HoverSound.length;
		}

		if (timeLeft > 0.0f) {
			timeLeft -= Time.deltaTime;
			playingSound = (timeLeft <= 0.0f) ? false : true;
		}

	}*/

	void OnGUI ()
	{
		GUIStyle buttonStyle = new GUIStyle("button");
		buttonStyle.normal.background = (Texture2D)this.StartButtonNormal;
		buttonStyle.hover.background = (Texture2D)this.StartButtonHover;
		buttonStyle.active.background = (Texture2D)this.StartButtonActive;
		if (GUI.Button (this.startButtonRect, "Start Game", buttonStyle))
		{
			Application.LoadLevel (Application.loadedLevel+1);
		}
	}
}
