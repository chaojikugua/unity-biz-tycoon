using UnityEngine;
using System.Collections;
using System.Xml;

public class DataManager : MonoBehaviour {

	public TextAsset GameData;

	public void Start() {
		Invoke ("LoadData", .1f);
	}

	public void LoadData() {
		Debug.Log ("here!");

		//for json but will probably need some DTO instead of mapping directly to Stores class
		//YouObject[] objects = JsonHelper.getJsonArray<YouObject> (jsonString);

		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml (GameData.text);

		XmlNodeList storeList = xmlDoc.GetElementsByTagName ("store");
		foreach (XmlNode storeNode in storeList) {

			XmlNodeList storeNodes = storeNode.ChildNodes;

			foreach (XmlNode store in storeNodes) {
				Debug.Log (store.Name);
				Debug.Log (store.InnerText);	
			}

		}


	}
}
