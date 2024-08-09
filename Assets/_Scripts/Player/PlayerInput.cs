using System;
using UnityEngine;

namespace JustGame.Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private bool m_allowInput;
        [SerializeField] private Vector2 m_movingDirection;
        [SerializeField] private Vector2 m_aimDirection;
        [SerializeField] private float m_offsetAngle;
        [SerializeField] private Camera m_mainCamera;

        public Quaternion MouseBasedRotation => Quaternion.AngleAxis(m_rotAngle, Vector3.forward);
        public bool IsAllowInput => m_allowInput;
        public Vector2 MovingDirection => m_movingDirection;

        private float m_rotAngle;
        
        private void Start()
        {
            m_allowInput = true;
        }

        private void Update()
        {
            if (!m_allowInput) return;

            m_movingDirection = Vector2.zero;
            
            if (Input.GetKey(KeyCode.D))
            {
                m_movingDirection.x = 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                m_movingDirection.x = -1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                m_movingDirection.y = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                m_movingDirection.y = -1;
            }

            m_aimDirection = (GetWorldMousePos() - transform.position).normalized;
            m_rotAngle = Mathf.Atan2(m_aimDirection.y, m_aimDirection.x) * Mathf.Rad2Deg + m_offsetAngle;
        }
        
        #region Public
        
        /// <summary>
        /// Toggle player input, make them react to input
        /// </summary>
        /// <param name="toggleValue"></param>
        public void ToggleInput(bool toggleValue)
        {
            m_allowInput = toggleValue;
        }
        
        #endregion

        #region Private
        /// <summary>
        /// Get mouse position in world position
        /// </summary>
        /// <returns></returns>
        private Vector3 GetWorldMousePos()
        {
            if (m_mainCamera == null)
            {
#if UNITY_EDITOR
                Debug.LogError("Camera not found!");
#endif
                return Vector3.zero;
            }
           
            
            var pos = m_mainCamera.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            return pos;
        }
        

        #endregion

    }
}
