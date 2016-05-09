using UnityEngine;
using System.Collections;
using System.Xml;
using UnityEngine.UI;

public class DataManager : MonoBehaviour {

	public delegate void LoadDataComplete();
	public static event LoadDataComplete OnLoadDataComplete;
	public TextAsset GameData;
	public GameObject StorePrefab;
	public GameObject StorePanel;

	public void Start() {
		LoadData ();
		if (OnLoadDataComplete != null) {
			OnLoadDataComplete ();
		}
	}
		
	public void LoadData() {
		//for json but will probably need some DTO instead of mapping directly to Stores class
		//YouObject[] objects = JsonHelper.getJsonArray<YouObject> (jsonString);

		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml (GameData.text);

		//game data
		LoadGameManagerData (xmlDoc);

		//store data
		LoadStoreData (xmlDoc);
	}

	public void LoadGameManagerData(XmlDocument xmlDoc) {
		XmlNodeList startingBalanceNode = xmlDoc.GetElementsByTagName ("StartingBalance");
		GameManager.instance.AddToBalance (float.Parse(startingBalanceNode [0].InnerText));
		string companyName = xmlDoc.GetElementsByTagName ("CompanyName") [0].InnerText;
		GameManager.instance.CompanyName = companyName;
	}

	public void LoadStoreData(XmlDocument xmlDoc) {
		XmlNodeList storeList = xmlDoc.GetElementsByTagName ("store");
		foreach (XmlNode storeInfo in storeList) {
			GameObject newStore = (GameObject)Instantiate (StorePrefab);
			//Store storeObj = newStore.GetComponent<Store> ();
			Store storeObj = new Store();

			XmlNodeList storeNodes = storeInfo.ChildNodes;
			foreach (XmlNode storeNode in storeNodes) {

				storeObj = CreateStoreObject (newStore, storeNode);
				storeObj.setNextStoreCost (storeObj.baseStoreCost);
				newStore.transform.SetParent (StorePanel.transform, false);
			}
		}	
	}

	private Store CreateStoreObject(GameObject newStore, XmlNode storeNode) {
		Store storeObj = newStore.GetComponent<Store> ();
		if (storeNode.Name == "name") {
			string nameOfStore = storeNode.InnerText;
			Text storeNameText = storeObj.transform.Find ("StoreNameText").GetComponent<Text> ();
			storeNameText.text = nameOfStore;
		}
		if (storeNode.Name == "image") {
			Sprite storeSprite = Resources.Load<Sprite> (storeNode.InnerText);
			Image storeImage = storeObj.transform.Find ("StoreButtonImage").GetComponent<Image> ();
			storeImage.sprite = storeSprite;
		}
		if (storeNode.Name == "BaseStoreProfit") {
			storeObj.baseStoreProfit = float.Parse(storeNode.InnerText);
		}
		if (storeNode.Name == "BaseStoreCost") {
			storeObj.baseStoreCost = float.Parse(storeNode.InnerText);
		}
		if (storeNode.Name == "StoreTimer") {
			storeObj.storeTimer = float.Parse(storeNode.InnerText);
		}
		if (storeNode.Name == "StoreMultiplier") {
			storeObj.storeMultiplier = float.Parse (storeNode.InnerText);
		}
		if (storeNode.Name == "StoreTimerDivisor") {
			storeObj.storeTimerDivisor = int.Parse (storeNode.InnerText);
		}
		if (storeNode.Name == "StoreUnlocked") {
			storeObj.storeUnlocked = bool.Parse (storeNode.InnerText);
		}
		return storeObj;
	}
}
