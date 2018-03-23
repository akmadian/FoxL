using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform target;
	public Vector3 offsetPosition;
	public Space offsetPositionSpace = Space.Self;
	public bool lookAt = true;

	float curZoomPos, zoomTo;
	float zoomFrom = 20f;
	float minFov= 15f;
	float maxFov = 90f;
	float sensitivity = 10f;

	/*
	void Update(){
		float fov = Camera.main.fieldOfView;
		fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
		fov = Mathf.Clamp(fov, minFov, maxFov);
		Camera.main.fieldOfView = fov;
	}
*/

	private void LateUpdate()
	{
		Refresh();
	}

	public void Refresh(){
		if (target == null){
			Debug.LogWarning("Missing target ref !", this);

			return;
		}
		if (offsetPositionSpace == Space.Self){
			transform.position = target.TransformPoint(offsetPosition);
		}
		else{
			transform.position = target.position - offsetPosition;
		}

		if (lookAt){
			transform.LookAt(target);
		}
		else{
			transform.rotation = target.rotation;
		}
	}
}