using UnityEngine;
using System.Collections;

public class SettingsPopup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// When settings popup is opened, show the popup sprite.
	public void Open() {
		gameObject.SetActive(true);
	}

		// When settings popup is closed, hide everything.
		public void Close() {
		gameObject.SetActive(false);
	}
}
