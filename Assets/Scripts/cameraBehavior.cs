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


	public float rotateSpeed = 25.0f;
    public Vector3 Axis;
	public bool OnHold;

	// Use this for initialization
	void Start () {
		defaultPosition = GameObject.Find ("WeaponPosition");

		once = true;
		Axis.x = this.transform.eulerAngles.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (Things == null) {
			this.transform.position = DefaultPos.position;

			//transform.LookAt (PlayerPos);
			//once = false;
			if(once)
			{
				transform.LookAt (PlayerPos);
					 once = false;    
			}
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

	
		if (Input.GetTouch (0).phase == TouchPhase.Moved) 

		{
			if(Things == null && !OnHold)
			{
				Drag();
			}
		}

	}
	
	void Drag()
	{
		Vector3 mosPos = Input.GetTouch(0).deltaPosition;
	    Axis.y -= mosPos.x * rotateSpeed * Time.deltaTime;
		Axis.x += mosPos.y * rotateSpeed * Time.deltaTime;
        this.transform.eulerAngles = new Vector3 (Axis.x,Axis.y,this.transform.rotation.y);        
	}

	public void newWeapon()
	{
		if(isWeaponExist == false)
		Instantiate (Weapon, defaultPosition.transform.position, Quaternion.identity);
	}

	public void resetLevel()
	{
		Application.LoadLevel (Application.loadedLevel);

	}

}

