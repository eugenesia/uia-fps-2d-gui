using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour {
	// Base speed adjusted by speed setting.
	public const float baseSpeed = 3.0f;
	public float speed = 3.0f;
	public float obstacleRange = 5.0f;

	[SerializeField] private GameObject fireballPrefab;
	private GameObject _fireball;
	
	private bool _alive;
	
	void Start() {
		_alive = true;
	}

	// Add listener to our custom messaging system.
	void Awake() {
		// <float> defines a type which allows the listener to be passed a value.
		Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	// Clean up listeners on this MonoBehaviour being destroyed.
	void OnDestroy() {
		Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	// Event handler.
	private void OnSpeedChanged(float value) {
		// On changing speed value in UI, set speed of wandering AI.
		speed = baseSpeed * value;
	}
	
	void Update() {
		if (_alive) {
			transform.Translate(0, 0, speed * Time.deltaTime);
			
			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.SphereCast(ray, 0.75f, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				if (hitObject.GetComponent<PlayerCharacter>()) {
					if (_fireball == null) {
						_fireball = Instantiate(fireballPrefab) as GameObject;
						_fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
						_fireball.transform.rotation = transform.rotation;
					}
				}
				else if (hit.distance < obstacleRange) {
					float angle = Random.Range(-110, 110);
					transform.Rotate(0, angle, 0);
				}
			}
		}
	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}
}
