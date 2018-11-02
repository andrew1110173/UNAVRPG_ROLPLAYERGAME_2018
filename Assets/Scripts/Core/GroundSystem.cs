using System.Collections;
using UnityEngine;

namespace Core.GroundSystem
{
    [System.Serializable]
    public class GroundSystem
    {
        [SerializeField]
        Color rayColor;
        [SerializeField, Range(0.1f, 10f)]
        float rayLenght;
        [SerializeField]
        LayerMask groundLayer;
        [SerializeField]
        Vector3 startPosition;
        RaycastHit hit;

        public bool CheckGround(Transform transform)
        {
            return Physics.Raycast(transform.position,Vector3.down,out hit, rayLenght, groundLayer);
        }

        public void DrawRay(Transform transform)
        {
            Gizmos.color = rayColor;
            Gizmos.DrawRay(transform.position + startPosition, Vector3.down * rayLenght);
        }
    }
}
