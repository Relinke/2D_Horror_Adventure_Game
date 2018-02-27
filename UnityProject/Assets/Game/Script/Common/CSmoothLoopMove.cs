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

        private void Update()
        {
            Vector2 pos = transform.localPosition;
            switch (MoveDirection)
            {
                case EMoveDirectionType.HORIZONTAL:
                    pos.x = Mathf.Sin(Time.time * Speed) * MoveRange;
                    break;
                case EMoveDirectionType.VERTICAL:
                    pos.y = Mathf.Sin(Time.time * Speed) * MoveRange;
                    break;
            }
            transform.localPosition = pos;
        }
    }
}