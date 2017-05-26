using UnityEngine;
using System.Collections;

public class ShakeCamera : MonoBehaviour
{

    public bool shakePosition;
    public bool shakeRotation;

    public float shakeIntensity = 0.5f;
    public float shakeDecay = 0.02f;

    private Vector3 OriginalPos;
    private Quaternion OriginalRot;
    public Quaternion resetRot;

    private bool isShakeRunning = false;


    public void DoShake()
    {
        OriginalPos = transform.position;
        OriginalRot = transform.rotation;

        StartCoroutine("ProcessShake");
    }

    IEnumerator ProcessShake()
    {
        if (!isShakeRunning)
        {
            isShakeRunning = true;
            float currentShakeIntensity = shakeIntensity;

            while (currentShakeIntensity > 0)
            {
                if (shakePosition)
                {
                    transform.position = OriginalPos + Random.insideUnitSphere * currentShakeIntensity;
                }
                if (shakeRotation)
                {
                    transform.rotation = new Quaternion(OriginalRot.x + Random.Range(-currentShakeIntensity, currentShakeIntensity) * .2f,
                                                        OriginalRot.y + Random.Range(-currentShakeIntensity, currentShakeIntensity) * .2f,
                                                        OriginalRot.z + Random.Range(-currentShakeIntensity, currentShakeIntensity) * .2f,
                                                        OriginalRot.w + Random.Range(-currentShakeIntensity, currentShakeIntensity) * .2f);
                }
                currentShakeIntensity -= shakeDecay;
                yield return null;
            }
            transform.rotation = resetRot;
            isShakeRunning = false;
        }
    }
}