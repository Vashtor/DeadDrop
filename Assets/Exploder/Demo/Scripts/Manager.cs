using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Exploder.Examples
{
public class Manager : MonoBehaviour {


	public int score;
	public ExploderObject ExploderObjectInstance;
	public Text ScoreText;
	public Slider powerSlider;
	public int powerLevel;


	// Use this for initialization
	void Start () {
		powerLevel = 0;
	}
	
	// Update is called once per frame
	void Update () {
			ScoreText.text = score.ToString ();
			powerSlider.value = powerLevel;
	}
}

}