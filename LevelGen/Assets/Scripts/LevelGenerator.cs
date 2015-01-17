using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	//Prefabs
	public List<Transform> startPrefabList;
	public List<Transform> endPrefabList;
	public List<Transform> prefabList;
	public int levelSize;

	//References to the instantiated clones
	private Transform levelStart;
	private Transform levelEnd;
	private List<Transform> level;

	void Start () {
		level = new List<Transform> ();
		generateLevel (levelSize);
	}

	void generateLevel(int size){
		Transform piece = (Transform) Instantiate(startPrefabList[0], new Vector3 (0, 0, 0), Quaternion.identity);

		levelStart = piece; //referece to the Start Piece

		level.Add (piece); //add the piece to the level Array

		for (int i = 0; i < size; i++) {
			piece = generateNextPiece(piece);
			level.Add (piece); //add the piece to the level Arra
		}

		//connectEndPoint ();
	}

	Transform generateNextPiece(Transform prev){
		//add all free Controlpoints to a list
		List<Transform> controlPoints = getAllControlPoints (prev);
		//randomly choose cp to connect
		Transform cp = getRandomCP (controlPoints);

		int pos;
		Transform newPiece, cpNewPiece;
		string ct;
		//choose prefab to connect

		do{
			pos = Random.Range (0, prefabList.Count);
			Debug.Log ("Chosen piece: "+ pos + "/" + (prefabList.Count - 1));
			newPiece = (Transform) Instantiate (prefabList[pos], new  Vector3 (0, 0, 0), Quaternion.identity);

			ct = connectTo (cp);
			cpNewPiece = newPiece.transform.Find(ct);

			if (cpNewPiece == null) {
				Debug.Log ("Connection inpossible! Trying other piece...");
				Destroy(newPiece.gameObject);
			}
		}while(cpNewPiece == null);


		//translate to correct position
		newPiece.position = cp.position - cpNewPiece.position;

		//mark moth connecting point as connected
		cpNewPiece.gameObject.GetComponent<ControlPoint>().connected = true;
		cp.gameObject.GetComponent<ControlPoint> ().connected = true;

		return newPiece;
	}

	//Returns all of the non connected control points
	static List<Transform> getAllControlPoints(Transform t){
	//	Debug.Log ("Child_count of t: " + t.childCount); 
		List<Transform> cps = new List<Transform>(); 
		Debug.Log (t.GetChild(0).tag);
		foreach (Transform child in t){
			ControlPoint cpProp = child.GetComponent<ControlPoint>();
			if (child.tag == "cp" && cpProp.connected == false)
				cps.Add(child);			
		}
		Debug.Log ("Number of CPs: "+ cps.Count);
		return cps;	
	}

	Transform getRandomCP(List<Transform> cp){
		Debug.Log ("Size: "+ cp.Count);
		int pos = Random.Range (0, cp.Count);
		return cp [pos];		
	}

	static string connectTo(Transform cp){
		Debug.Log (cp.name);
		switch(cp.name){
		case "cp_r":
			return "cp_l";
		case "cp_l":
			return "cp_r";
		case "cp_t":
			return "cp_b";
		case "cp_b":
			return "cp_t";
		default:
			return "invalid";
		}
	}

	Transform getRandomFreeCPoint(List<Transform> level){
		int area = Random.Range (0, level.Count);
		List<Transform> cps = getAllControlPoints (level [area]);
		int i = Random.Range (0, cps.Count);
		return cps [i];
	}

	void connectEndPoint(){
		Transform cp = getRandomFreeCPoint (level);

		int pos;
		Transform newPiece, cpNewPiece;
		string ct;
		//choose prefab to connect
		
		do{
			pos = Random.Range (0, endPrefabList.Count);
			newPiece = (Transform) Instantiate (endPrefabList[pos], new  Vector3 (0, 0, 0), Quaternion.identity);
			
			ct = connectTo (cp);
			cpNewPiece = newPiece.transform.Find(ct);
			
			if (cpNewPiece == null) {
				Debug.Log ("Connection inpossible! Trying other piece...");
				Destroy(newPiece.gameObject);
			}
		}while(cpNewPiece == null);
		
		
		//translate to correct position
		newPiece.position = cp.position - cpNewPiece.position;
		
		//mark moth connecting point as connected
		cpNewPiece.gameObject.GetComponent<ControlPoint>().connected = true;
		cp.gameObject.GetComponent<ControlPoint> ().connected = true;

	}
	
}
