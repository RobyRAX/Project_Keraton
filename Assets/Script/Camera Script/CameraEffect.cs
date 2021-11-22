using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraEffect : MonoBehaviour
{
    public Animator anim;

    public IEnumerator Shake(float duration, float magnitude)
    {
        Debug.Log("Camera Goyang");
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = originalPos;
    }

    public void CallShake(float inputDuration, float inputMagnitude)
    {
        StartCoroutine(Shake(inputDuration, inputMagnitude));       
    }

    public void Attack1FX()
    {
        anim.SetTrigger("att1");
    }
    public void Attack2FX()
    {
        anim.SetTrigger("att2");
    }
    public void Attack3FX()
    {
        anim.SetTrigger("att3");
    }
    public void Attack4FX()
    {
        anim.SetTrigger("att4");
    }

    public void WalkEffectOn()
    {
        anim.SetBool("isWalking", true);
    }

    public void WalkEffectOff()
    {
        anim.SetBool("isWalking", false);
    }
}
