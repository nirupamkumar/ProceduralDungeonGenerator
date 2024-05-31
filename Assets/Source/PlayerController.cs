using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private LayerMask obstacleLayerMask;
    private Vector2 targetPos;
    private Transform playerSprite;
    private float flipX;
    private bool isMoving;

    public float speed;

    private void Start()
    {
        obstacleLayerMask = LayerMask.GetMask("Wall", "Enemy");
        playerSprite = GetComponentInChildren<SpriteRenderer>().transform;
        flipX = playerSprite.localScale.x;
    }

    private void Update()
    {
        float horz = System.Math.Sign(Input.GetAxisRaw("Horizontal"));
        float vert = System.Math.Sign(Input.GetAxisRaw("Vertical"));

        if (Mathf.Abs(horz) > 0 || Mathf.Abs(vert) > 0) 
        {
            if (Mathf.Abs(horz) > 0)
            {
                playerSprite.localScale = new Vector2(flipX * horz, playerSprite.localScale.y);
            }

            if (!isMoving)
            {
                if (Mathf.Abs(horz) > 0)
                {
                    targetPos = new Vector2(transform.position.x + horz, transform.position.y);
                }
                else if (Mathf.Abs(vert) > 0)
                {
                    targetPos = new Vector2(transform.position.x, transform.position.y + vert);
                }

                // Check for collision
                Vector2 hitSize = Vector2.one * 0.8f;
                Collider2D hit = Physics2D.OverlapBox(targetPos, hitSize, 0, obstacleLayerMask);

                if (!hit)
                {
                    StartCoroutine(SmoothMove());
                }
            }
        }
    }

    IEnumerator SmoothMove()
    {
        isMoving = true;

        while (Vector2.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }
}
