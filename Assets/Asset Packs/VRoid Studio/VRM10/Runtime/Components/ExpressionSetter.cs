using UnityEngine;

namespace UniVRM10
{
    public class ExpressionSetter : MonoBehaviour
    {
        [SerializeField] [Range(0, 1)] float happy;
        [SerializeField] [Range(0, 1)] float angry;
        [SerializeField] [Range(0, 1)] float sad;
        [SerializeField] [Range(0, 1)] float relaxed;
        [SerializeField] [Range(0, 1)] float surprised;
        Vrm10Instance vrmInstance;

        void Awake()
        {
            vrmInstance = GetComponent<Vrm10Instance>();
        }

        void Update()
        {
            vrmInstance.Runtime.Expression.SetWeight(ExpressionKey.Happy, happy);
            vrmInstance.Runtime.Expression.SetWeight(ExpressionKey.Angry, angry);
            vrmInstance.Runtime.Expression.SetWeight(ExpressionKey.Sad, sad);
            vrmInstance.Runtime.Expression.SetWeight(ExpressionKey.Relaxed, relaxed);
            vrmInstance.Runtime.Expression.SetWeight(ExpressionKey.Surprised, surprised);
        }
    }
}