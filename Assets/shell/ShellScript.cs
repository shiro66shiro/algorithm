using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShellScript : MonoBehaviour {
	public GameObject cube;
	public GameObject checkObj1;
	public GameObject checkObj2;

	public int[] num = new int[10];
	public int[] shellCount = new int[3];
	public GameObject[] numObj = new GameObject[10];

	private List<int> shellList = new List<int>();
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
		Instantiate (checkObj1, new Vector3 (0, -2f, 0), Quaternion.identity);
		Instantiate (checkObj2, new Vector3 (0, -4f, 0), Quaternion.identity);
		checkObj1 = GameObject.Find ("Cube1(Clone)");
		checkObj2 = GameObject.Find ("Cube2(Clone)");
		StartCoroutine("shell");
	}

	IEnumerator shell(){
		for (int i = 0; i < 3; i++) {
			for(int j = 9;j > -1;j--){
				if (j - shellCount [i] > -1) {
					Debug.Log (j - shellCount [i]);
					if (num [j] < num [j - shellCount [i]]) {
						checkObj1.transform.position = new Vector3 (numObj [j].transform.position.x + 1f, 0, 0);
						checkObj2.transform.position = new Vector3 (numObj [j - shellCount [i]].transform.position.x + 1f, 0, 0);
						moveObj(i,j);
					}
				}
				yield return new WaitForSeconds(0.3f);
			}
			yield return new WaitForSeconds(0.3f);
		}
		re ();
	}

	void re(){shell();}

	void moveObj(int i,int j){
		int q = num [j];
		num [j] = num [j - shellCount[i]];
		num [j - shellCount[i]] = q;
		Vector3 v;
		v = numObj [j].transform.position;
		numObj [j].transform.position = numObj [j - shellCount[i]].transform.position;
		numObj [j - shellCount[i]].transform.position = v;
		GameObject ob;
		ob = numObj [j];
		numObj [j] = numObj [j - shellCount[i]];
		numObj [j - shellCount[i]] = ob;
	}

	void shellTest(int i,int j){
		for(int q = 0;i < 3;i++){
			if (j - shellCount [i] > -1) {
				shellList.Add (j);

			}
		}

	
	}

}
