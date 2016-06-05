using UnityEngine;
using System.Collections;
// Include UI system code frameworks.
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour {
	private Camera _camera;

	void Start() {
		_camera = GetComponent<Camera>();

		// Don't lock and hide cursor as we need it for the GUI now.
		// Cursor.lockState = CursorLockMode.Locked;
		// Cursor.visible = false;
	}

	void OnGUI() {
		int size = 12;
		float posX = _camera.pixelWidth/2 - size/4;
		float posY = _camera.pixelHeight/2 - size/2;
		GUI.Label(new Rect(posX, posY, size, size), "*");
	}

	void Update() {
		if (Input.GetMouseButtonDown(0) &&

			// Check that GUI isn't being used before we trigger shooting code.
			! EventSystem.current.IsPointerOverGameObject()) {

			Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
			Ray ray = _camera.ScreenPointToRay(point);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				if (target != null) {
					target.ReactToHit();
					// Broadcast event that enemy has been hit, so listeners can react,
					// e.g. by incrementing the score.
					Messenger.Broadcast(GameEvent.ENEMY_HIT);
				} else {
					StartCoroutine(SphereIndicator(hit.point));
				}
			}
		}
	}

	private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = pos;

		yield return new WaitForSeconds(1);

		Destroy(sphere);
	}
}