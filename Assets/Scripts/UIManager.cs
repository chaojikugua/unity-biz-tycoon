using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager instance;
	public Text CurrentBalanceText;
	public Text CompanyNameText;

	// Use this for initialization
	void Start () {
	}

	void OnEnable() {
		GameManager.OnUpdateBalance += UpdateUI; //subscribe to OnUpdateBalance event
		DataManager.OnLoadDataComplete += UpdateUI;
	}

	void OnDisable() {
		GameManager.OnUpdateBalance -= UpdateUI; //unsubscribe to OnUpdateBalance event
		DataManager.OnLoadDataComplete -= UpdateUI;
	}		
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateUI() {
		CurrentBalanceText.text = GameManager.instance.GetCurrentBalance().ToString("C2");
		CompanyNameText.text = GameManager.instance.CompanyName;
	}
}
