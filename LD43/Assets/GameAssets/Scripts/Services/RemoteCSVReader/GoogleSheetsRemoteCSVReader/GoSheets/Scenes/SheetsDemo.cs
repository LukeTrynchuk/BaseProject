using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SheetsDemo : MonoBehaviour {

	public string url;
	public InputField input;
	public Text result;

	// Use this for initialization
	public void GetSheet () {
		url = input.text;
		string[][] sheet = GoSheets.GetGoogleSheet (url);
		result.text = "(A1): " + sheet [0] [0] + "\n(B1): " + sheet [0] [1] + "\n(A2): " + sheet [1] [0];
	}

}
