using UnityEngine;
using System.Collections;

public class MainGameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60; //Max FPS on Mobile
		StartCoroutine ("checkWinnerLoop");

	}

	IEnumerator checkWinnerLoop(){
		GameObject[] playerObjs = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] baseObjs = GameObject.FindGameObjectsWithTag ("Base");
		Player winner = null;
		while (winner == null) {
			winner = checkWinner(playerObjs, baseObjs);
			yield return new WaitForSeconds(1);
		}
		onWin (winner);
	}

	Player checkWinner(GameObject[] playerObjs, GameObject[] baseObjs){
		Player winner = null;
		foreach (GameObject playerObj in playerObjs) {
			Player p = playerObj.GetComponent<Player>();
			
			foreach (GameObject gameObj in baseObjs) {
				Base b = gameObj.GetComponent<Base>();
				
				if(b.owner == p){
					if(winner == null){
						winner = p;
						break;
					}
					else{
						return null;
					}
				}
			}
		}

		//Make sure there are no units still alive
		if (winner != null) {
			GameObject[] gos = GameObject.FindGameObjectsWithTag("Unit");
			foreach (GameObject go in gos){
				Unit unit = go.GetComponent<Unit>();
				if(unit.owner != winner){
					return null;
				}
			}
		}

		return winner;
	}

	private void onWin(Player winner){
		print ("winner player:" + winner.name);
	}


}
