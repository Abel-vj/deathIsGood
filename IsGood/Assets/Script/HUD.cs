using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public Texture[] p0img = new Texture[5];
	public Texture[] p1img = new Texture[5];
	public Texture[] p2img = new Texture[5];
	public Texture[] p3img = new Texture[5];

	public PlayerController p0ctr;
	public PlayerController p1ctr;
	public PlayerController p2ctr;
	public PlayerController p3ctr;

	private int totalPlayers;

	private int[] deaths = new int[4];

	// Use this for initialization
	void Start () {
		
		deaths [0] = 0;
		deaths [1] = 0;
		deaths [2] = 0;
		deaths [3] = 0;
		
		//totalPlayers = Input.GetJoystickNames().Length;
		totalPlayers = 4;
	}
	
	// Update is called once per frame
	void Update () {
		
		deaths [0] = p0ctr.countDeath;
		deaths [1] = p1ctr.countDeath;
		deaths [2] = p2ctr.countDeath;
		deaths [3] = p3ctr.countDeath;

	}

	void OnGUI(){
		if (totalPlayers >= 1) {
			GUI.Label (new Rect (10, 0, 100, 100), p0img[deaths[0]]);	
		}
		if (totalPlayers >= 2) {
			GUI.Label (new Rect (10, 100, 100, 100), p1img[deaths[1]]);
		}
		if (totalPlayers >= 3) {
			GUI.Label (new Rect (Camera.current.pixelWidth - 100, 0, 100, 100), p2img[deaths[2]]);
		}
		if (totalPlayers >= 4) {
			GUI.Label (new Rect (Camera.current.pixelWidth - 100, 100, 100, 100), p3img[deaths[3]]);
		}
	}
}
