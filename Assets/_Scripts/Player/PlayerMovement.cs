using UnityEngine;

namespace JustGame.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerInput m_input;
        [SerializeField] private float m_moveSpeed;
        [SerializeField] private Transform m_rotateBody;
        
        private void Update()
        {
            if (!m_input.IsAllowInput) return;
            
            transform.Translate(m_input.MovingDirection * (m_moveSpeed * Time.deltaTime));
            m_rotateBody.rotation = m_input.MouseBasedRotation;
        }
    }
}

