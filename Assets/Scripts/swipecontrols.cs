using UnityEngine;
using System.Collections;

public class swipecontrols : MonoBehaviour {

	public bool isThrow;
	public Vector3 origin;

	public float power ;
	private Vector3 startPos;
	public float startTime;

	public GameObject CameraPos;

	// Use this for initialization
	void Start () {
		isThrow = false;
		origin = transform.position;
		CameraPos = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.R))
			ReturnBall();
}
	
	void OnMouseDown() {
		startPos = Input.mousePosition;
		startPos.z = transform.position.z - Camera.main.transform.position.z;
		startPos = Camera.main.ScreenToWorldPoint(startPos);
	}
	
	void OnMouseUp() {
		Vector3 endPos = Input.mousePosition;
		endPos.z = transform.position.z - Camera.main.transform.position.z;
		endPos = Camera.main.ScreenToWorldPoint(endPos);
		
		Vector3 force = endPos - startPos;
		force.z = force.magnitude;
		force.Normalize();
		CameraPos.GetComponent<cameraBehavior>().Things = this.gameObject;
		GetComponent<Rigidbody> ().useGravity = true;
		GetComponent<Rigidbody>().AddForce(force * power);

	}

	
	public void ReturnBall() {
		GetComponent<Rigidbody> ().useGravity = false;
		//transform.position = Vector3.zero;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		transform.position = origin;
	}

}
