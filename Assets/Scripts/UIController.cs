using UnityEngine;
// Import UI code framework.
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	// Reference text object in scene to set text property.
	[SerializeField] private Text scoreLabel;

	// Popup window to adjust settings.
	[SerializeField] private SettingsPopup settingsPopup;

	// Use this for initialization
	void Start () {
		// Close popup when game starts.
		settingsPopup.Close();
	}
	
	// Update is called once per frame
	void Update () {
		scoreLabel.text = Time.realtimeSinceStartup.ToString();
	}

	// Method called by settings button.
	public void OnOpenSettings() {
		settingsPopup.Open();
	}

	// Method called by Event																																																																																																																																																																																																												 Trigger on settings button.
	public void OnPointerDown() {
		Debug.Log("pointer down");
	}
}
