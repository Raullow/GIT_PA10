using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public float force;
    private Vector3 screenbounds;
    public GameObject Obstacle;
    private GameManager theGameManager;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        theGameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            GetComponent<Rigidbody>().AddForce(Vector3.up * force);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle" || other.tag == "Ground")
        {
            SceneManager.LoadScene("GameOver");
        }

        if(other.tag == "Point")
        {
            Debug.Log("Pass");
            theGameManager.AddScore(1);
        }
    }
}
