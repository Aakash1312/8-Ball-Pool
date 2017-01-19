using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
public class camscript : MonoBehaviour {
	private Rigidbody refer;
	private GameObject cuestick;
	public float perspectiveZoomSpeed = 0.1f;
	public float orthoZoomSpeed = 0.1f;
	private Camera camera;
	private cue cuescript;
	// Use this for initialization
	void Start () {
		GameObject s = GameObject.Find ("Sphere");
		cuestick = GameObject.Find ("Cylinder");
		cuescript = cuestick.GetComponent<cue> ();
		refer = s.GetComponent<Rigidbody> ();
		//cuestick = c.GetComponent<Rigidbody> ();
		camera = GetComponent<Camera> ();
		cuescript.camRotation = transform.rotation;
		//green = GameObject.Find ("glowy");
	}
	private bool IsPointerOverUIObject() {
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}
	// Update is called once per frame
	void Update () {
		//if (EventSystem.current.IsPointerOverGameObject () || EventSystem.current.currentSelectedGameObject != null) {
		//	return;
		//}
		if (!IsPointerOverUIObject()) {
			if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Moved) {
				Vector2 delta = Input.GetTouch (0).deltaPosition;
				//transform.RotateAround (refer.position, new Vector3 (0, 1, 0), -0.5F * delta.x);
				cuestick.transform.RotateAround (refer.position, new Vector3 (0, 1, 0), -0.5F * delta.x);
				cuescript.initialPosition = cuestick.transform.position;

			}
			// If there are two touches on the device...
			if (Input.touchCount == 2) {
				// Store both touches.
				Touch touchZero = Input.GetTouch (0);
				Touch touchOne = Input.GetTouch (1);

				// Find the position in the previous frame of each touch.
				Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
				Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

				// Find the magnitude of the vector (the distance) between the touches in each frame.
				float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
				float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

				// Find the difference in the distances between each frame.
				float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
				if ((camera.transform.position.y < 100.0F && deltaMagnitudeDiff > 0) || (camera.transform.position.y > 1.0F && deltaMagnitudeDiff < 0)) {
					transform.Translate (0.4F * deltaMagnitudeDiff * ((new Vector3(-30,  100, 0) - refer.position).normalized), Space.World);
					//transform.Translate (0.4F * deltaMagnitudeDiff * ((camera.transform.position - refer.position).normalized) + new Vector3 (0, 0.5F*deltaMagnitudeDiff, 0), Space.World);
					Debug.Log(transform.localRotation);
					if ((transform.localRotation.x <= 0.65 && deltaMagnitudeDiff > 0) || (transform.localRotation.x >= 0 && deltaMagnitudeDiff < 0) ) {
						transform.Rotate (0.4F * deltaMagnitudeDiff, 0, 0);
					}
				}
				// If the camera is orthographic...
				//if (camera.orthographic)
				//{
				// ... change the orthographic size based on the change in distance between the touches.
				//	camera.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

				// Make sure the orthographic size never drops below zero.
				//	camera.orthographicSize = Mathf.Max(camera.orthographicSize, 0.1f);
				//}
				//else
				//{
				// Otherwise change the field of view based on the change in distance between the touches.
				//	camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

				// Clamp the field of view to make sure it's between 0 and 180.
				//	camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 0.1f, 140.9f);
				//}
				//if (camera.transform.position.y < 12.0F) {
				//	transform.Translate (0, 0.1F * deltaMagnitudeDiff, 0);
				//}
			}
		}
	}
}
