using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BubbleSort : MonoBehaviour {
	public GameObject cube;
	public GameObject lineObj;
	public int[] num = new int[10];
	public GameObject[] numObj = new GameObject[10];

	// Use this for initialization
	void Start () {
		for (int i = 0;i < 10;i++){
			Instantiate(cube,new Vector3(1f * i*2,0,0),Quaternion.identity);
			numObj[i] = GameObject.Find ("Cube(Clone)");
			num [i] = Random.Range (0, 10);
			numObj[i].transform.FindChild("count").GetComponent<TextMesh>().text = num[i].ToString(); 
			numObj[i].name = num[i].ToString ();
			numObj [i].GetComponent<MeshRenderer> ().material.color = new Color (Random.Range (0, 1f), Random.Range (0, 1f), Random.Range (0, 1f), 1f);
		}
		Instantiate (lineObj, new Vector3 (0, -2, 0), Quaternion.identity);
		lineObj = GameObject.Find ("lineObj(Clone)");
		StartCoroutine("bubble");

	}
	IEnumerator bubble(){
		int count = 0;
		for (int i = 0; i < 9; i++) {
			if (num [i + 1] > num [i]) { 
				moveObj (i);
				count++;
			}
			lineObj.transform.position = new Vector3 (numObj [i].transform.position.x + 1f, -2f, 0);
			if (count == 0 && i == 8) {
				Debug.Log ("fin");
				return false;
			}
			yield return new WaitForSeconds(0.3f);
		}
		re ();
	}
	void re(){StartCoroutine("bubble");}
	void moveObj(int i){
		int q = num [i];
		num [i] = num [i + 1];
		num [i + 1] = q;
		Vector3 v;
		v = numObj [i].transform.position;
		numObj [i].transform.position = numObj [i + 1].transform.position;
		numObj [i + 1].transform.position = v;
		GameObject ob;
		ob = numObj [i];
		numObj [i] = numObj [i + 1];
		numObj [i + 1] = ob;
	}
		

}
