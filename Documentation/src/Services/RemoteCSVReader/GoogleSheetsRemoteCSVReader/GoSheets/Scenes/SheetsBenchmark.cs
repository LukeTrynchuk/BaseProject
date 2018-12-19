using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SheetsBenchmark : MonoBehaviour {

	public string url;
	public InputField input;
	public Text result;

	// Use this for initialization
	public void Benchmark () {
		url = input.text;
		int t = Environment.TickCount;
		for (int i = 0; i < 100; i++) {
			string[][] sheet = GoSheets.GetGoogleSheet (url);
		}
		int t2 =  Environment.TickCount - t;

		int t3 = Environment.TickCount;
		for (int i = 0; i < 100; i++) {
			string[][] sheet = GoSheets.GetGoogleSheetNative (url);
		}
		int t4 =  Environment.TickCount - t3;
		result.text = "BENCHMARK RESULTS\nOriginal: " + (t2 / 1000f) + " s\nNative: " + (t4 / 1000f) + " s";
	}

}
