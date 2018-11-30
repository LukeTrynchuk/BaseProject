using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SheetsLocalization : MonoBehaviour {

	public string url;
	public InputField input;
	public Text spanish;
	public Text english;

	public void Localization(){
		url = input.text;
		string[][] sheet = GoSheets.GetGoogleSheet (url);
		spanish.text = sheet [0] [0] + "\n" + sheet [1] [0] + "\n" + sheet [2] [0] + "\n" + sheet [3] [0] + "\n" + sheet [4] [0];
		english.text = sheet [0] [1] + "\n" + sheet [1] [1] + "\n" + sheet [2] [1] + "\n" + sheet [3] [1] + "\n" + sheet [4] [1];
	}
}
