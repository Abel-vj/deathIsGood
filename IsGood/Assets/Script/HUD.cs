using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public Texture p1;
	public Texture p2;
	public Texture p3;
	public Texture p4;

	private int totalPlayers = 4;

	// Use this for initialization
	void Start () {

		//totalPlayers = Input.GetJoystickNames().Length;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (totalPlayers >= 1) {
			GUI.Label (new Rect (10, 0, 200, 200), p1);	
		}
		if (totalPlayers >= 2) {
			GUI.Label (new Rect (10, 100, 200, 200), p2);
		}
		if (totalPlayers >= 3) {
			GUI.Label (new Rect (Camera.current.pixelWidth - 100, 0, 200, 200), p3);
		}
		if (totalPlayers >= 4) {
			GUI.Label (new Rect (Camera.current.pixelWidth - 100, 100, 200, 200), p4);
		}



	}

}
