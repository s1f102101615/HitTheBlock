using UnityEngine;
using System.Collections;

public class random : MonoBehaviour {


        //プレハブを変数に代入
	public GameObject cube;


	void Start () {


                //オブジェクトの座標
		float x = Random.Range(-12.0f, 12.0f);
		float y = Random.Range(-5.0f, 5.0f);

                //オブジェクトを生産
		Instantiate(cube, new Vector2(x, y), Quaternion.identity);
	
	}
	
}