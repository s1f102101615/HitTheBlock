using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokeController : MonoBehaviour
{
    [SerializeField] Material lineMaterial;
    [SerializeField] Color lineColor;
    [Range(0.1f, 0.5f)]
    [SerializeField] float lineWidth;

    GameObject lineObj;
    LineRenderer lineRenderer;
    EdgeCollider2D lineCollider;
    Rigidbody2D lineRigidbody; // 線のRigidbody2D

    List<Vector2> linePoints;

    bool isDrawing = false;

    public float ballSpeed = 20f;

    void Start()
    {
        // Listの初期化
        linePoints = new List<Vector2>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopDrawing();
        }

        if (isDrawing && Input.GetMouseButton(0))
        {
            AddPositionDataToLineRenderer();
        }
    }

    private void StartDrawing()
    {
        if (!isDrawing)
        {
            lineObj = new GameObject();
            lineObj.name = "Line";
            lineObj.tag = "Line"; // Lineオブジェクトに"Line"タグを設定
            lineObj.transform.SetParent(transform);

            lineRenderer = lineObj.AddComponent<LineRenderer>();
            lineRenderer.material = lineMaterial;
            lineRenderer.material.color = lineColor;
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;

            lineCollider = lineObj.AddComponent<EdgeCollider2D>();
            lineRigidbody = lineObj.AddComponent<Rigidbody2D>(); // 線のRigidbody2Dを追加
            lineRigidbody.isKinematic = true; // 線のRigidbody2Dをキネマティックに設定

            isDrawing = true;
        }
    }

    private void StopDrawing()
    {
        if (isDrawing)
        {
            isDrawing = false;

            lineRenderer.enabled = false;
            linePoints.Clear();
            lineCollider.enabled = false;

            Destroy(lineRigidbody); // 線のRigidbody2Dを破棄
        }
    }

    private void AddPositionDataToLineRenderer()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0f;

        lineRenderer.positionCount = linePoints.Count + 1;
        lineRenderer.SetPosition(linePoints.Count, worldPos);
        linePoints.Add(worldPos);
        lineCollider.points = linePoints.ToArray();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Line"))
        {
            Debug.Log("これはラインです！");
            Vector2 direction = GetCollisionNormal(collision);
            direction.y = Mathf.Abs(direction.y); // y成分を正の値にする

            Rigidbody2D ballRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 reflectedVelocity = Vector2.Reflect(ballRigidbody.velocity, direction.normalized);
            ballRigidbody.velocity = reflectedVelocity;
        }
        else if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("これはボールです！");
            Vector2 direction = GetCollisionNormal(collision);
            direction.y = Mathf.Abs(direction.y); // y成分を正の値にする
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * ballSpeed, ForceMode2D.Impulse);
        }
    }

    private Vector2 GetCollisionNormal(Collision2D collision)
    {
        Vector2 contactPoint = collision.GetContact(0).point;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(contactPoint);
        return (worldPos - (Vector2)transform.position).normalized;
    }
}
