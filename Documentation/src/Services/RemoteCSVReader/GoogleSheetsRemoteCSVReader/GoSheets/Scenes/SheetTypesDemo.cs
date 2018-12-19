using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SheetTypesDemo : MonoBehaviour {

	public string url;
	public InputField input;
	public GameObject c1;
	public GameObject c2;
	public GameObject c3;
	
	public void LoadValues () {
		url = input.text;
		string[][] sheet = GoSheets.GetGoogleSheet (url);
		c1.transform.position = GoSheets.CellToVector3 (sheet [1] [0]);
		c1.GetComponent<Renderer>().material.color = GoSheets.CellToColor (sheet [2] [0]);
		c2.transform.position = GoSheets.CellToVector3 (sheet [1] [1]);
		c2.GetComponent<Renderer>().material.color = GoSheets.CellToColor (sheet [2] [1]);
		c3.transform.position = GoSheets.CellToVector3 (sheet [1] [2]);
		c3.GetComponent<Renderer>().material.color = GoSheets.CellToColor (sheet [2] [2]);
	}
}
