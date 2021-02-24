using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetNeutralized : MonoBehaviour
{
    private AttackScript attack;
    private HealthScript health;
    private Text scoreText;
    int score;

    private void Awake()
    {
        attack = GameObject.Find("AttackTarget").GetComponent<AttackScript>();
        GameObject go = GameObject.Find("/FirstPersonPlayer/MainCamera");
        health = go.GetComponent<HealthScript>();
        scoreText = GameObject.Find("/PlayerCanvas/Score").GetComponent<Text>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collObj = collision.collider.gameObject;
        Vector3 punchForce = collObj.transform.forward;
        punchForce.Normalize();
        if (collObj.name == "Fist" && attack.punching)
        {
            GetComponent<Rigidbody>().AddForce(punchForce * 1000);
            score += 10;
        }
        else if (collObj.name == "Cylinder")
        {
            Debug.Log("Ouch!");
            health.TakeDamage(500f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 10;
        scoreText.text = "SCORE: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + score.ToString();
    }

}
