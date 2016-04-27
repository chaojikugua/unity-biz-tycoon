using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager instance;
	public Text CurrentBalanceText;


	// Use this for initialization
	void Start () {
	
	}

	void Awake(){
		if (instance == null)
			instance = this;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateUI() {
		CurrentBalanceText.text = GameManager.instance.GetCurrentBalance().ToString("C2");
	}
}
