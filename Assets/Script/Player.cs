using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float horizontalInput;
    public int Score = 0;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float speed;
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _text.text = "Player Score: " + Score;
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (horizontalInput < 0)
        {
            _rb.AddForce(new Vector2(horizontalInput * speed, 0f), ForceMode2D.Impulse);
        }
        else //(horizontalInput > 0)
        {
            _rb.AddForce(new Vector2(horizontalInput * speed, 0f), ForceMode2D.Impulse);
        }
    }

    // function to add points in text UI
    public void AddPoints(int Points)
    {
        Score += Points;
        _text.text = "Player Score: " + Score.ToString();
    }

}
