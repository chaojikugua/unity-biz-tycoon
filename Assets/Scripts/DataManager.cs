﻿using UnityEngine;
using System.Collections;
using System.Xml;

public class DataManager : MonoBehaviour {

	public TextAsset GameData;
	public GameObject StorePrefab;
	public GameObject StorePanel;

	public void Start() {
		Invoke ("LoadData", .1f);
	}

	public void LoadData() {

		//for json but will probably need some DTO instead of mapping directly to Stores class
		//YouObject[] objects = JsonHelper.getJsonArray<YouObject> (jsonString);

		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml (GameData.text);

		XmlNodeList storeList = xmlDoc.GetElementsByTagName ("store");
		foreach (XmlNode storeInfo in storeList) {
			GameObject newStore = (GameObject)Instantiate (StorePrefab);
			Store storeObj = newStore.GetComponent<Store> ();

			XmlNodeList storeNodes = storeInfo.ChildNodes;
			foreach (XmlNode storeNode in storeNodes) {
				if (storeNode.Name == "BaseStoreProfit") {
					storeObj.baseStoreProfit = float.Parse(storeNode.InnerText);
				}
				if (storeNode.Name == "BaseStoreCost") {
					storeObj.baseStoreCost = float.Parse(storeNode.InnerText);
				}
				if (storeNode.Name == "StoreTimer") {
					storeObj.storeTimer = float.Parse(storeNode.InnerText);
				}
				newStore.transform.SetParent (StorePanel.transform, false);
			}
		}
	}
}