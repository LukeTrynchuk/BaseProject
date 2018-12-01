using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VersionCheck : MonoBehaviour {

	public string url;
	public InputField input;
	public Text result;
	public int localVersion = 1;

	public void CheckVer(){
		url = input.text;
		string[][] sheet = GoSheets.GetGoogleSheet (url);
		if (GoSheets.CellToInt (sheet [1] [0]) > localVersion) {
			result.text = "Please, update your game.";
		} else {
			result.text = "Your game is up to date.";
		}
	}
}
