using UnityEngine;
using System.Collections;

public class bladeRotator : MonoBehaviour {

	// So we know when the blade should spin
	public bool isActive;

	void Start() {
		isActive = false;
	}
		
	void Update () 
	{
		// Listen for spacebar (enable/disable blade spin)
		if (Input.GetKeyDown (KeyCode.Space)) {
			setActive ();
		}
		// Spin the blade if it should be spinning. Duh.
		if (isActive) {
			transform.Rotate (new Vector3 (0, 0, -2160) * Time.deltaTime);
		}
	}

	void setActive() {
		isActive = !isActive;
	}

}	