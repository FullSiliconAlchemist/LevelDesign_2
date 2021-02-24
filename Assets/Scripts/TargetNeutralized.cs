using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetNeutralized : MonoBehaviour
{
    private AttackScript attack;
    private HealthScript health;

    private void Awake()
    {
        attack = GameObject.Find("AttackTarget").GetComponent<AttackScript>();
        GameObject go = GameObject.Find("/FirstPersonPlayer/MainCamera");
        Debug.Log(go.name);

        health = go.GetComponent<HealthScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collObj = collision.collider.gameObject;
        Vector3 punchForce = collObj.transform.forward;
        punchForce.Normalize();
        if (collObj.name == "Fist" && attack.punching)
        {
            GetComponent<Rigidbody>().AddForce(punchForce * 1000);
        }
        else if (collObj.name == "Cylinder")
        {
            Debug.Log("Ouch!");
            health.TakeDamage(500f);
        }
    }

}
