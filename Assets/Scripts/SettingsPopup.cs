using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour {

	// Slider object to choose the speed.
	[SerializeField] private Slider speedSlider;

	// Use this for initialization
	void Start () {
		// Get speed value from saved storage.
		speedSlider.value = PlayerPrefs.GetFloat("speed", 1);
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

	// Will trigger when user types in the input field.
	public void OnSubmitName(string name) {
		Debug.Log(name);
	}

	// Will trigger when user adjusts slider.
	public void OnSpeedValue(float speed) {
		Debug.Log("Speed: " + speed);
		// Save the speed value, to reload on start.
		PlayerPrefs.SetFloat("speed", speed);
	}
}
