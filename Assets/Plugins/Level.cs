using UnityEngine;


[System.Serializable]
public class Level : System.Object {
	public string name;
	public string audio;
	public string previewAudio;
	public string sketch;
	public Block[] blocks;

	public static Level CreateFromJSON(string jsonString) {
		return JsonUtility.FromJson<Level> (jsonString);
	}
}