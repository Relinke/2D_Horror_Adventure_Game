using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class CSmoothLoopMove : MonoBehaviour
    {
        public enum MoveDirectionType
        {
            HORIZONTAL,
            VERTICAL
        }
        public MoveDirectionType MoveDirection;
        public float MoveRange;
        public float Speed;

        private void Update()
        {
            Vector2 pos = transform.position;
            switch (MoveDirection)
            {
                case MoveDirectionType.HORIZONTAL:
                    pos.x = Mathf.Sin(Time.time * Speed) * MoveRange;
                    break;
                case MoveDirectionType.VERTICAL:
                    pos.y = Mathf.Sin(Time.time * Speed) * MoveRange;
                    break;
            }
            transform.position = pos;
        }
    }
}