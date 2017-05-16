using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFoodItem : MonoBehaviour {


	public GameObject collidedItem;
	public int Grains, vegetables, fruits, oils, milk, meat, fats, total;
	public UnityEngine.UI.Text grainsText, vegetableText, fruitsText, oilText, milkText, meattext, fatsText, totalText;
	public GameObject foodscorePanel;
	// Use this for initialization
	void Start () {
		
		//Debug.Log (GameObject.Find ("Menu").gameObject.transform.GetChild (4));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){


		if (col.GetComponent<Collider2D> ().name == "Game Finish Point") {

			foodscorePanel = GameObject.Find ("Menu").gameObject.transform.GetChild(4).gameObject;

			grainsText = foodscorePanel.gameObject.transform.GetChild (0).gameObject.GetComponent<UnityEngine.UI.Text> ();
			vegetableText = foodscorePanel.gameObject.transform.GetChild (1).gameObject.GetComponent<UnityEngine.UI.Text> ();
			fruitsText = foodscorePanel.gameObject.transform.GetChild (2).gameObject.GetComponent<UnityEngine.UI.Text> ();
			oilText = foodscorePanel.gameObject.transform.GetChild (3).gameObject.GetComponent<UnityEngine.UI.Text> ();
			milkText = foodscorePanel.gameObject.transform.GetChild (4).gameObject.GetComponent<UnityEngine.UI.Text> ();
			meattext = foodscorePanel.gameObject.transform.GetChild (5).gameObject.GetComponent<UnityEngine.UI.Text> ();
			fatsText = foodscorePanel.gameObject.transform.GetChild (6).gameObject.GetComponent<UnityEngine.UI.Text> ();
			totalText = foodscorePanel.gameObject.transform.GetChild (7).gameObject.GetComponent<UnityEngine.UI.Text> ();

			total = Grains + vegetables + fruits + oils + milk + meat + fats;
			foodscorePanel.gameObject.SetActive (true);
			grainsText.text = "Points from grains = " + Grains;
			vegetableText.text = "Points from Vegetables = " + vegetables;
			fruitsText.text = "Points from fruits = " + fruits;
			oilText.text = "Points from oils = " + oils;
			milkText.text = "Points from milk = " + milk;
			meattext.text = "Points from meat = " + meat;
			fatsText.text = "Points from fats = " + fats;
			totalText.text = "Total Points = "+total;

		}

		if (col.GetComponent<Collider2D>().name == "grains") {
			col.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			col.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			col.gameObject.transform.GetChild (1).gameObject.SetActive (true);
			StartCoroutine (Wait());
			collidedItem = col.gameObject;

			Grains += 100;
			fruits += 50;
		}

		if (col.GetComponent<Collider2D>().name == "excessfat") {
			col.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			col.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			col.gameObject.transform.GetChild (1).gameObject.SetActive (true);
			StartCoroutine (Wait());
			collidedItem = col.gameObject;

			fats -= 100;
			oils += 200;
		}

		if (col.GetComponent<Collider2D>().name == "fruits") {
			col.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			col.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			col.gameObject.transform.GetChild (1).gameObject.SetActive (true);
			StartCoroutine (Wait());
			collidedItem = col.gameObject;

			fruits += 100;
		}

		if (col.GetComponent<Collider2D>().name == "meat") {
			col.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			col.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			col.gameObject.transform.GetChild (1).gameObject.SetActive (true);
			StartCoroutine (Wait());
			collidedItem = col.gameObject;

			meat += 200;
			oils += 100;
		}

		if (col.GetComponent<Collider2D>().name == "milk") {
			col.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			col.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			col.gameObject.transform.GetChild (1).gameObject.SetActive (true);
			StartCoroutine (Wait());
			collidedItem = col.gameObject;

			milk += 200;
			//fats += 100;
		}

		if (col.GetComponent<Collider2D>().name == "vegetables") {
			col.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			col.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			col.gameObject.transform.GetChild (1).gameObject.SetActive (true);
			StartCoroutine (Wait());
			collidedItem = col.gameObject;

			vegetables += 100;
			Grains += 50;
		}
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (1.5f);
		collidedItem.gameObject.SetActive (false);
	}
}
