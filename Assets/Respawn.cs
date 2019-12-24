using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {

    public GameObject poli;
    public GameObject piso;
    public GameObject scoreText;
    int score;
    float speed;
    float amplitude;
    Vector3 posInicial;
    Vector3 trepidar;
    Gyroscope gyro; 
    Quaternion posTel;

    void Start() {

        speed = 0.0f;
        amplitude = 2.0f;
        posInicial = piso.transform.position;
        score = 0;
        gyro = Input.gyro;
        gyro.enabled = true;
        posTel = gyro.attitude;
    }

    public void SumarScore(int sumarValorScore)
    {
        score += sumarValorScore;
        scoreText.GetComponent<TextMesh>().text = "Count:" + score;
    }

    void FixedUpdate () {

        //trepidar = posInicial + new Vector3(0.0f, amplitude * Mathf.Sin(speed * Time.time), 0.0f);

        //if (Input.touchCount > 0) //subst -- 1
        if (Input.GetMouseButtonDown(0))
        {
        //Touch touch = Input.GetMouseButtonDown(0); //subst -- 2 
        Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // subst -- 3
        
        //if (Input.GetMouseButtonDown(0))  //borrar -- 1
        //{
        //    Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //borrer -- 2
            touchPos.x = Random.Range(-93, 88);
            touchPos.y = Random.Range(-1, 90);
            touchPos.z = Random.Range(-9,94);

            //if (touch.phase == TouchPhase.Began)
                Instantiate(poli, touchPos, Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
                SumarScore(1);
        }

        if (Tremor() )
        {
            piso.transform.position = trepidar;
        }


    }

    bool Tremor()
    {
        if (posTel.x > 0.8 || posTel.y > 0.8 || posTel.z > 0.8 || posTel.w > 0.8 || posTel.x < -0.8 || posTel.y < -0.8 || posTel.z < -0.8 || posTel.w < -0.8)

            return true;

        else return false;
    }
}
 