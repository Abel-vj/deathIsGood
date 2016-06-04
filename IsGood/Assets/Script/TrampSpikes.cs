using UnityEngine;
using System.Collections;

public class TrampSpikes : MonoBehaviour {

	bool enableSpikes;
	public GameObject gameObectSpikes;
	public float timeToToggle;

	// Use this for initialization
	void Start () {
		enableSpikes = true;
		StartCoroutine( "ToogleSpikes" );
	}
		
	IEnumerator ToogleSpikes() {
		while (true) {
			yield return new WaitForSeconds(timeToToggle);
			gameObectSpikes.SetActive( enabled );
			enabled = !enabled;
		}
	}


}
