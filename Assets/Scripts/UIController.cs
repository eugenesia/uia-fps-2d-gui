using UnityEngine;
// Import UI code framework.
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	// Reference text object in scene to set text property.
	[SerializeField] private Text scoreLabel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		scoreLabel.text = Time.realtimeSinceStartup.ToString();
	}

	// Method called by settings button.
	public void OnOpenSettings() {
		Debug.Log("open settings");
	}

	// Method called by Event Trigger on settings button.
	public void OnPointerDown() {
		Debug.Log("pointer down");
	}
}
