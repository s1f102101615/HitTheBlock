using UnityEngine;

public class aitu : MonoBehaviour
{
    public GameObject cubePrefab; // 再生成するキューブのプレハブ

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Ballに接触しました");
            GenerateCube(); // キューブの再生成を行う
            Destroy(gameObject); // aituオブジェクトを破棄する
        }
    }

    private void GenerateCube()
    {
        float x = Random.Range(-10.0f, 10.0f);
        float y = Random.Range(-5.0f, 5.0f);
        Instantiate(cubePrefab, new Vector2(x, y), Quaternion.identity);
        score.scoreValue = score.scoreValue + 1;
    }
}
