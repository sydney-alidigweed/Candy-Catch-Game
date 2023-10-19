using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candies : MonoBehaviour
{
    float _timer = 0.0f;
    private float waitTime;
    public GameObject _candy;
    [SerializeField] GameObject _candyPrefab;

    void Start()
    {
        //set wait time to be random within 1-3s
        waitTime = Random.Range(1f, 3f);
    }

    void Update()
    {
        _timer += Time.deltaTime;

        //if the timer is within the wait time parameters set above, it will call the drop function
        if (_timer > waitTime)
        {
            _timer = _timer - waitTime;
            drop();
        }
    }

    // drops candy prefab
    void drop()
    {
        Debug.Log("Dropped");
        Instantiate(_candyPrefab);
    }

    //if the candy touches the game objects with the appropriate tags it will be destroyed
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Destroy(_candyPrefab);
            //when the candy is destroyed by the player, 1 point is added to the score
            other.GetComponent<Player>().AddPoints(1);
        }
        if (other.transform.tag == "Ground")
        {
            Destroy(_candyPrefab);
        }
    }
}
