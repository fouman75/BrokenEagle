using UnityEngine;

namespace FOUOne.PotionCreator
{
    public class Wobble : MonoBehaviour
    {
        [SerializeField] private float maxWobble = 0.03f;
        [SerializeField] private float wobbleSpeed = 1f;
        [SerializeField] private float recovery = 1f;
    
        private float _wobbleAmountX;
        private float _wobbleAmountZ;
        private float _wobbleAmountToAddX;
        private float _wobbleAmountToAddZ;
        private float _pulse;
        private float _time = 0.5f;
    
        private Renderer _rend;
        private Vector3 _lastPos;
        private Vector3 _velocity;
        private Vector3 _lastRot;
        private Vector3 _angularVelocity;
    
        private static readonly int ShaderWobbleX = Shader.PropertyToID("_WobbleX");
        private static readonly int ShaderWobbleZ = Shader.PropertyToID("_WobbleZ");

        // Use this for initialization
        void Start()
        {
            _rend = GetComponent<Renderer>();
        }
        private void Update()
        {
            _time += Time.deltaTime;
            // decrease wobble over time
            _wobbleAmountToAddX = Mathf.Lerp(_wobbleAmountToAddX, 0, Time.deltaTime * (recovery));
            _wobbleAmountToAddZ = Mathf.Lerp(_wobbleAmountToAddZ, 0, Time.deltaTime * (recovery));

            // make a sine wave of the decreasing wobble
            _pulse = 2 * Mathf.PI * wobbleSpeed;
            _wobbleAmountX = _wobbleAmountToAddX * Mathf.Sin(_pulse * _time);
            _wobbleAmountZ = _wobbleAmountToAddZ * Mathf.Sin(_pulse * _time);

            // send it to the shader
            _rend.material.SetFloat(ShaderWobbleX, _wobbleAmountX);
            _rend.material.SetFloat(ShaderWobbleZ, _wobbleAmountZ);

            // velocity
            var t = transform;
            var pos = t.position;
            var rot = t.rotation;
            _velocity = (_lastPos - pos) / Time.deltaTime;
            _angularVelocity = rot.eulerAngles - _lastRot;

            // add clamped velocity to wobble
            _wobbleAmountToAddX += Mathf.Clamp((_velocity.x + (_angularVelocity.z * 0.2f)) * maxWobble, -maxWobble, maxWobble);
            _wobbleAmountToAddZ += Mathf.Clamp((_velocity.z + (_angularVelocity.x * 0.2f)) * maxWobble, -maxWobble, maxWobble);

            // keep last position
            _lastPos = pos;
            _lastRot = rot.eulerAngles;
        }
    }
}