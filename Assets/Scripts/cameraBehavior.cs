using UnityEngine;
using System.Collections;

public class cameraBehavior : MonoBehaviour {

	public GameObject Things;
	public Transform PlayerPos;
	public Transform DefaultPos;
	private bool once;
	public GameObject defaultPosition;
	public GameObject Weapon;
	public bool isWeaponExist;


	// Use this for initialization
	void Start () {
		defaultPosition = GameObject.Find ("WeaponPosition");
	}
	
	// Update is called once per frame
	void Update () {
	
		Camera.main.transform.rotation = Quaternion.identity;

		if (Things == null) {
			this.transform.position = DefaultPos.position;
			transform.LookAt (PlayerPos);
			once = false;
			
		} 
		else {
			transform.LookAt(Things.transform);
			Vector3 TempPos = this.transform.position;
			if(!once)
			{
				//TempPos.x = Things.transform.position.x;
				TempPos.z = Things.transform.position.z;
				once = true;
			}this.transform.position = TempPos;
		}
	}

	public void newWeapon()
	{
		if(isWeaponExist == false)
		Instantiate (Weapon, defaultPosition.transform.position, Quaternion.identity);
	}

}

