using UnityEngine;
using System.Collections;
namespace Exploder.Examples
{
public class enemy : MonoBehaviour {

	public bool isHit;
	public Rigidbody[] bodies;

	public GameObject explodeParticle;
	
	public ExploderObject ExploderObjectInstance = null;
//	private GameObject[] DestroyableObjects;
	private GameObject DestroyableObjects;
	
	private int counter;
	private int counterFinished;

	// Use this for initialization
	void Start () {
	
		bodies =  gameObject.GetComponentsInChildren<Rigidbody>();
		isHit = false;
		foreach (Rigidbody rig in bodies)
		for (int i=0; i < bodies.Length; i++) {
			bodies[i].isKinematic = true;
		}
		
			//DestroyableObjects = GameObject.FindGameObjectsWithTag("Exploder");
			DestroyableObjects = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		if (isHit) {

		
			foreach (Rigidbody rig in bodies)
				//for (int i=0; i < bodies.Length; i++) {
						//bodies[i].isKinematic = false;
				//}

				rig.isKinematic = false;

				/*
					foreach (var o in DestroyableObjects)
					{
						ExplodeObject(o);
				 		}
				*/

				ExplodeObject(DestroyableObjects);
				GameObject parti= Instantiate (explodeParticle,new Vector3(this.transform.position.x, 0, this.transform.position.z) , Quaternion.identity) as GameObject;

			
		}
	}
	
	void OnCollisionEnter(Collision obj){

		if (obj.gameObject.tag == "Weapon") {
			/*
			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
			
			foreach (Collider hit in colliders) {
				if (hit)
					this.GetComponent<Rigidbody> ().AddExplosionForce (power, explosionPos, radius, 0.0F);
					*/
				isHit = true;
			//GetComponent<Collider>().enabled = false;
			StartCoroutine("waitDestroy");
				/*
				if(obj.gameObject.GetComponent<Rigidbody>().mass > 500)
				{
					foreach (var o in DestroyableObjects)
					{
						ExplodeObject(o);
					}
					
					
				}
				*/

			}
		}

	IEnumerator waitDestroy() {
		yield return new WaitForSeconds(0.5f);
		GetComponent<Collider>().enabled = false;
		GetComponent<Rigidbody> ().isKinematic = true;
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