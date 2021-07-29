using UnityEngine;
using UnityEngine.EventSystems;

public class PotionRotationHandler : MonoBehaviour, IDragHandler
{
    [SerializeField] private Transform potionContainer;
    [SerializeField] private float maxRotationX = 45f;
    [SerializeField] private float maxRotationZ = 45f;

    private float _angleX;
    private float _angleZ;

    public void OnDrag(PointerEventData eventData)
    {
        RotatePotion(eventData.delta);
    }

    private void RotatePotion(Vector2 delta)
    {
        var drag = delta;

        _angleX = Mathf.Clamp(_angleX + drag.y, -maxRotationX, maxRotationX);
        _angleZ = Mathf.Clamp(_angleZ - drag.x, -maxRotationZ, maxRotationZ);
        
        potionContainer.rotation = Quaternion.Euler(_angleX, 0, _angleZ);
    }
}
