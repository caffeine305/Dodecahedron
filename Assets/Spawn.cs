using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject poli;
    public GameObject scoreText;
    int score;
	// Use this for initialization
	void Start () {
        score = 0;
	}

    public void SumarScore(int sumarValorScore)
    {
        score += sumarValorScore;
        scoreText.GetComponent<TextMesh>().text = "Count:" + score;
    }

    void Update () {
        //if (Input.touchCount > 0) //subst -- 1
        //{
        //Touch touch = Input.GetTouch(0); //subst -- 2
        //Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position); // subst -- 3

        //Quaternion oriented = Random.Range 
        

        if (Input.GetMouseButtonDown(0))  //borrar -- 1
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //borrer -- 2
            touchPos.x = Random.Range(-93, 88);
            touchPos.y = Random.Range(-1, 90);
            touchPos.z = Random.Range(-9,94);

            //if (touch.phase == TouchPhase.Began)
                Instantiate(poli, touchPos, Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
                SumarScore(1);
        }

    }
}
 