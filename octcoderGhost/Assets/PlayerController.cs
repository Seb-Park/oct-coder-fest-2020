using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed = 10f;
    public int score;
    public TextMeshProUGUI scoreText;
    public GameObject graphic;
    public SpriteRenderer playerGraphic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        rb.AddRelativeForce(new Vector3(Input.GetAxis("Vertical") * speed, 0, 0));
        if(rb.velocity.x>0){
            playerGraphic.flipX = false;
            //graphic.transform.localScale = new Vector3(1f, 1f, 1);
        }
        else if(rb.velocity.x < 0){
            playerGraphic.flipX = true;
            //graphic.transform.localScale = new Vector3(-1f, 1f, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Candy"))
        {
            score += 100;
            scoreText.text = "Score: " + score.ToString();
            Destroy(collision.gameObject);
        }
    }

    void LookAt(Vector2 p2)
    {
        float forwardAngle = 0;
        Vector2 p1 = transform.position;
        float opp = p2.y - p1.y;
        float adj = p2.x - p1.x;
        float zRadians = Mathf.Atan((p2.y - p1.y) / (p2.x - p1.x));
        if (adj < 0)
            zRadians += Mathf.PI;
        Quaternion q = Quaternion.Euler(0, 0, Mathf.Rad2Deg * zRadians);
        transform.rotation = q;
        transform.Rotate(0, 0, -forwardAngle);
    }
}
