using UnityEngine;
// Import UI code framework.
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	// Reference text object in scene to set text property.
	[SerializeField] private Text scoreLabel;

	// Popup window to adjust settings.
	[SerializeField] private SettingsPopup settingsPopup;

	// Count of enemies hit.
	private int _score;

	// Called when the MonoBehaviour is awoken.
	void Awake() {
		// Add listener to our custom messaging system.
		// Declare which method responds to event ENEMY_HIT.
		Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
	}

	// Called when the MonoBehaviour is destroyed.
	// When an object is destroyed, use the cleanup listener to avoid errors.
	void OnDestroy() {
		Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
	}

	// Use this for initialization
	void Start () {
		// Initialize score to 0.
		_score = 0;
		scoreLabel.text = _score.ToString();

		// Close popup when game starts.
		settingsPopup.Close();
	}

	// Event handler for when enemy is hit.
	private void OnEnemyHit() {
		// Increment score in response to event.
		_score += 1;
		scoreLabel.text = _score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
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
