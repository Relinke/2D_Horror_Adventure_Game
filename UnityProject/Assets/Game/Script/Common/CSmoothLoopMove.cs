using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class CSmoothLoopMove : MonoBehaviour
    {
        public enum EMoveDirectionType
        {
            HORIZONTAL,
            VERTICAL
        }
        public EMoveDirectionType MoveDirection;
        public float MoveRange;
        public float Speed;

        public float TimeOffset;

        private Vector2 OriginPosition;

        private void Awake()
        {
            OriginPosition = transform.localPosition;
        }

        private void Update()
        {
            Vector2 pos = transform.localPosition;
            switch (MoveDirection)
            {
                case EMoveDirectionType.HORIZONTAL:
                    pos.x = OriginPosition.x + Mathf.Sin((Time.time + TimeOffset) * Speed) * MoveRange;
                    break;
                case EMoveDirectionType.VERTICAL:
                    pos.y = OriginPosition.y + Mathf.Sin((Time.time + TimeOffset) * Speed) * MoveRange;
                    break;
            }
            transform.localPosition = pos;
        }
    }
}