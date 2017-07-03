using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform target;
    

    private Camera camera;
	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
	}

    // Update is called once per frame
    private void LateUpdate()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        if (target != null)
        {
            float smoothSpeed = .125f;
            Vector3 offset = new Vector3(1f, 1f, -10f);
            Vector3 desiredPosition = target.transform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        else
        {
            camera.backgroundColor = Color.red;
        }
    }   
}
