using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	//Prefabs
	public Transform endPointPref; //has 1 cp_l
	public Transform startPointPref; //has 1 cp_r
	public Transform corridorPref; //has both a cp_l and cp_r


	//References to the instantiated clones
	private Transform levelStart;
	private Transform levelEnd;
	private ArrayList level;
	private List<Transform> prefabList;

	void Start () {

		prefabList = new List<Transform>();
		prefabList.Add (startPointPref);
		prefabList.Add (endPointPref);
		prefabList.Add (corridorPref);

		generateLevel (3);
//		levelStart = (Transform) Instantiate(startPointPref, new Vector3 (0, 0, 0), Quaternion.identity);
//		//levelEnd = (Transform) Instantiate(endPointPref, new Vector3 (0, 0, 0), Quaternion.identity);
//		levelPiece = (Transform) Instantiate(corridorPref, new Vector3 (0, 0, 0), Quaternion.identity);
//		//levelPiece2 = (Transform) Instantiate(corridorPref, new Vector3 (0, 0, 0), Quaternion.identity);
//
//		Vector3 cpLeftNewPiece = levelStart.transform.FindChild ("cp_r").transform.position;
//
//		levelStart.position = level.transform.FindChild ("cp_l").transform.position - cpLeftNewPiece;

	}

	void generateLevel(int size){
		Transform piece = (Transform) Instantiate(prefabList[0], new Vector3 (0, 0, 0), Quaternion.identity);

		for (int i = 0; i <= size; i++) {
			piece = generateNextPiece(piece);
		}
	}

	Transform generateNextPiece(Transform prev){
		//add all free Controlpoints to a list
		List<Transform> controlPoints = getAllControlPoints (prev);
		//randomly choose cp to connect
		Transform cp = getRandomCPofType (controlPoints);
		//choose prefab to connect
		int pos = Random.Range (2, prefabList.Count - 1);
		Transform newPiece = (Transform) Instantiate (prefabList[pos], new  Vector3 (0, 0, 0), Quaternion.identity);

		//AQUI VAI DAR POIO 
	
		Transform cpNewPiece = newPiece.transform.FindChild (connectTo(cp));

		newPiece.position = cp.position - cpNewPiece.position;

		cpNewPiece.GetComponent<ControlPoint>().connected = true;
		cp.GetComponent<ControlPoint>().connected = true;

		return newPiece;
	}

	//Returns all of the non connected control points
	static List<Transform> getAllControlPoints(Transform t){
	//	Debug.Log ("Child_count of t: " + t.childCount); 
		List<Transform> cps = new List<Transform>(); 
		Debug.Log (t.GetChild(0).tag);
		foreach (Transform child in t){
			if (child.tag == "cp" && child.GetComponent<ControlPoint>().connected == false)
				cps.Add(child);
		}
		Debug.Log ("Number of CPs: "+ cps.Count);
		return cps;	
	}

	Transform getRandomCPofType(List<Transform> cp){
		Debug.Log ("Size: "+ cp.Count);
		int pos = Random.Range (0, cp.Count - 1);
		return cp [pos];		
	}

	static string connectTo(Transform cp){
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
			return "";
		}
	}
	
}
