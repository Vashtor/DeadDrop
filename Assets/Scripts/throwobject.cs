using UnityEngine;
using System.Collections;

public class throwobject : MonoBehaviour {

	public float radius = 5.0F;
	public float power = 10.0F;
	public float objMass;
	public Transform cameraTransform = Camera.main.transform;

	public GameObject mainCamera;
	void Start() {

		mainCamera = GameObject.Find("Main Camera");
		mainCamera.GetComponent<cameraBehavior>().isWeaponExist = true;

					/*
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
		
		foreach (Collider hit in colliders) {
			if (hit && hit.GetComponent<Rigidbody> ())
				hit.GetComponent<Rigidbody> ().AddExplosionForce (power, explosionPos, radius, 3.0F);
			Debug.Log (hit.name);
		}
		*/
		objMass = GetComponent<Rigidbody>().mass;
		power = objMass;

		//followCamera();
	}

	void OnCollisionEnter(Collision obj){
		Debug.Log (obj.gameObject.name);
		if (obj.gameObject.tag == "Enemy") {
			
			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
			
			foreach (Collider hit in colliders) {
				if (hit)
					obj.gameObject.GetComponent<Rigidbody> ().AddExplosionForce (power, explosionPos, radius, 0.0F);
			}

		}
		if(obj.gameObject.tag == "Ground")
			mainCamera.GetComponent<cameraBehavior>().isWeaponExist = false;
	}

	void OnCollisionStay(Collision col)
	{
		if (col.gameObject.tag == "Ground") {
	
			DestroyObject(this.gameObject,1.0f);
		}
	}
	void followCamera()
	{
		cameraTransform.parent = transform;
		cameraTransform.localPosition = -Vector3.forward * 5;
		cameraTransform.LookAt(transform);
	}
	
	
}
