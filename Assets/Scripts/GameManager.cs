using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Static Singleton Instance
	private static GameManager _Instance = null;

	private GameManager() {

	}

	// Property to get instance
	public static GameManager Instance {
		get {
			// If we don't have an instance yet find it in the scene hierarchy
			if(_Instance==null) 
				_Instance = FindObjectOfType<GameManager>();
			return _Instance;
		}
	}

	public int GetNextLevel() {
		return (Application.loadedLevel+1);
	}
}
