using System.Collections;
using UnityEngine;

namespace UniVRM10
{
    public class Blinker : MonoBehaviour
    {
        [SerializeField] float interval = 5;
        [SerializeField] float closingTime = 0.1f;
        [SerializeField] float openingSeconds = 0.05f;
        [SerializeField] float closeSeconds = 0.1f;
        Vrm10Instance vrmInstance;

        void Awake()
        {
            vrmInstance = GetComponent<Vrm10Instance>();
        }

        void Start()
        {
            StartCoroutine(BlinkRoutine());
        }

        IEnumerator BlinkRoutine()
        {
            while(true)
            {
                float waitTime = Time.time + Random.value * interval;

                while(waitTime > Time.time)
                {
                    yield return null;
                }

                float value = 0.0f;
                float closeSpeed = 1.0f / closeSeconds;

                while(true)
                {
                    value += Time.deltaTime * closeSpeed;
                    
                    if (value >= 1.0f)
                    {
                        break;
                    }

                    vrmInstance.Runtime.Expression.SetWeight(ExpressionKey.Blink, value);

                    yield return null;
                }

                yield return new WaitForSeconds(closingTime);

                value = 1.0f;

                float openSpeed = 1.0f / openingSeconds;

                while(true)
                {
                    value -= Time.deltaTime * openSpeed;

                    if(value < 0)
                    {
                        break;
                    }

                    vrmInstance.Runtime.Expression.SetWeight(ExpressionKey.Blink, value);

                    yield return null;
                }
            }
        }
    }
}
