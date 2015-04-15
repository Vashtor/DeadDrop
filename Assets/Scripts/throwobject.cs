using UnityEngine;
using System.Collections;
namespace Exploder.Examples
{
public class throwobject : MonoBehaviour {

	public float radius = 5.0F;
	public float power = 10.0F;
	public float objMass;
	public Transform cameraTransform = Camera.main.transform;

	public bool destroyWeapon;

	public ExploderObject ExploderObjectInstance;
	private GameObject DestroyableObjects;

	public GameObject mainCamera;

	void Start() {
			destroyWeapon = false;
		ExploderObjectInstance = GameObject.Find ("GameManager").GetComponent<Manager> ().ExploderObjectInstance;
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
		DestroyableObjects = this.gameObject;
		//followCamera();
	}

		void Update()
		{
			if(destroyWeapon)
			ExplodeObject(DestroyableObjects);
		}

	void OnCollisionEnter(Collision obj){

		

		if (obj.gameObject.tag == "Exploder") {
			
			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
			
			foreach (Collider hit in colliders) {
				if (hit)
					obj.gameObject.GetComponent<Rigidbody> ().AddExplosionForce (power, explosionPos, radius, 0.0F);
			}

		}
			/*
		if (obj.gameObject.tag == "Ground") {

				ExplodeObject(DestroyableObjects);
		}*/
			mainCamera.GetComponent<cameraBehavior> ().isWeaponExist = false;
			destroyWeapon = true;
			DestroyObject(this.gameObject,1.5f);
	}

		/*
	void OnCollisionStay(Collision col)
	{
		if (col.gameObject.tag == "Ground") {
	
			DestroyObject(this.gameObject,1.0f);
		}
	}
		*/

	void followCamera()
	{
		cameraTransform.parent = transform;
		cameraTransform.localPosition = -Vector3.forward * 5;
		cameraTransform.LookAt(transform);
	}

	private void ExplodeObject(GameObject gameObject)
	{
		ExploderUtils.SetActive(ExploderObjectInstance.gameObject, true);
		ExploderObjectInstance.transform.position = ExploderUtils.GetCentroid(gameObject);
		ExploderObjectInstance.Radius = 1.0f;
		ExploderObjectInstance.Explode();
	}
	
	
 }
}
