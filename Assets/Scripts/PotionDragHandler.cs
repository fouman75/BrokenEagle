using UnityEngine;
using UnityEngine.EventSystems;

public class PotionDragHandler : MonoBehaviour, IDragHandler
{
    [SerializeField] private Transform potionContainer;
    [SerializeField] private float maxRotationX = 45f;
    [SerializeField] private float maxRotationZ = 45f;

    private float _angleX;
    private float _angleZ;

    public void OnDrag(PointerEventData eventData)
    {
        var drag = eventData.delta;

        _angleX = Mathf.Clamp(_angleX + drag.y, -maxRotationX, maxRotationX);
        _angleZ = Mathf.Clamp(_angleZ - drag.x, -maxRotationZ, maxRotationZ);
        
        potionContainer.rotation = Quaternion.Euler(_angleX, 0, _angleZ);
    }
}
