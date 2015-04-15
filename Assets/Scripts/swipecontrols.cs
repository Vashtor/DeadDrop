using UnityEngine;
using System.Collections;

public class swipecontrols : MonoBehaviour {

	public bool isThrow;
	public Vector3 origin;

	public bool isHolding;
	public float power ;
	private Vector3 startPos;
	public float startTime;
	public float throwCounter;

	public Vector3 force ;

	public GameObject CameraPos;
	public GameObject gameManager;

	// Use this for initialization
	void Start () {
		isHolding = false;
		throwCounter = 0;

		isThrow = false;
		origin = transform.position;
		CameraPos = GameObject.Find("Main Camera");
		gameManager = GameObject.Find("GameManager");

	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.R))
			ReturnBall();

		if(isHolding)
			startTime += Time.deltaTime;
		//Debug.Log (startTime);
	
}


	void OnMouseDrag()		
	{		
		CameraPos.GetComponent<cameraBehavior> ().OnHold = true;		
	}

	void OnMouseDown() {
		isHolding = true;
		startPos = Input.mousePosition;
		startPos.z = transform.position.z - Camera.main.transform.position.z;
		startPos = Camera.main.ScreenToWorldPoint(startPos);

	}
	
	void OnMouseUp() {
		Vector3 endPos = Input.mousePosition;
		endPos.z = transform.position.z - Camera.main.transform.position.z;
		endPos = Camera.main.ScreenToWorldPoint(endPos);
		
		force = endPos - startPos;
		force.z = force.magnitude;
		force.Normalize();
		CameraPos.GetComponent<cameraBehavior>().Things = this.gameObject;

	
		//force /= (Time.time - startTime);

		force *= startTime;
		GetComponent<Rigidbody> ().useGravity = true;
		GetComponent<Rigidbody>().AddForce(force * power);

		Debug.Log (force * power);
		isHolding = false;
		CameraPos.GetComponent<cameraBehavior> ().OnHold = false;
	}
	
	public void ReturnBall() {
		GetComponent<Rigidbody> ().useGravity = false;
		//transform.position = Vector3.zero;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		transform.position = origin;
	}

}
