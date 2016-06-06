using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
	private GameObject _enemy;

	// Add listener to our custom messaging system.
	void Awake() {
		Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	// Clean up listeners on this MonoBehaviour being destroyed.
	void OnDestroy() {
		Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	// Event handler.
	private void OnSpeedChanged(float value) {
		// On changing speed value in UI, set the new speed for later cloned enemies.
		enemyPrefab.GetComponent<WanderingAI>().speed = WanderingAI.baseSpeed * value;
	}

	void Update() {
		if (_enemy == null) {
			_enemy = Instantiate(enemyPrefab) as GameObject;
			_enemy.transform.position = new Vector3(0, 1, 0);
			float angle = Random.Range(0, 360);
			_enemy.transform.Rotate(0, angle, 0);
		}
	}
}
