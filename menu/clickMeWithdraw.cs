using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class clickMeWithdraw : MonoBehaviour {

	public Button button3;
	public bankAcct ba;

	public void Start ()
	{
		Button b2 = button3.GetComponent<Button> ();
		b2.onClick.AddListener (FuckMe);

	}
	public void FuckMe ()
	{
		//Debug.Log ("You clicked shit");
		//button1.GetComponentInChildren<Text>().text = "blah";
		StartCoroutine (ChangeTheText ());
	}

	// Use this for initialization
	IEnumerator ChangeTheText () 
	{

		const string URL = "http://api.reimaginebanking.com/accounts/58e9b1e7ceb8abe24250bde7/deposits";
		string urlParameters = "?key=bb90ff71e2f3e4089a2706b77b15ae01";
		WWWForm form = new WWWForm ();
		form.AddField ("medium", "balance");
		form.AddField ("amount", "20.05");
		using (UnityWebRequest www = UnityWebRequest.Post(URL + urlParameters, form))
		{
			yield return www.Send();

			if (www.isError)
			{
				Debug.Log(www.error);
			}
			else
			{
				// Show results as text
				Debug.Log("Withdraw of $5 complete!");
				//Set shit equal to shit here

				//ba = bankAcct.CreateFromJSON (www.downloadHandler.text);

				//button1.GetComponentInChildren<Text> ().text = ba.getBalance().ToString();
			}
		}
	}


	// Update is called once per frame

}
/*
public class bankAcct
{
	public string _id;
	public string type;
	public string nickname;
	public int rewards;
	public double balance;
	public string customer_id;

	public static bankAcct CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<bankAcct>(jsonString);
	}
	public double getBalance ()
	{
		return balance;
	}

	// Given JSON input:
	// {"name":"Dr Charles","lives":3,"health":0.8}
	// this example will return a PlayerInfo object with
	// name == "Dr Charles", lives == 3, and health == 0.8f.
}
*/