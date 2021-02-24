using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject fist;
    public GameObject fistTarget;
    public StaminaScript stamina;

    public bool punching = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("mouse 0") && stamina.GetCurrentStamina() > 200f)
        {
            stamina.UseStamina(200f);
            StartCoroutine(Punch(0.15f, 3f, fist.transform.forward));
        }
    }

    IEnumerator Punch(float time, float distance, Vector3 direction)
    {
        punching = true;
        float timer = 0.0f;
        direction.Normalize();
        while (timer <= time)
        {
            fist.transform.position = fistTarget.transform.position + (Mathf.Sin(timer / time * Mathf.PI) + 1.0f) * direction;
            yield return null;
            timer += Time.deltaTime;
        }
        fist.transform.position = fistTarget.transform.position;
        punching = false;
    }
}
