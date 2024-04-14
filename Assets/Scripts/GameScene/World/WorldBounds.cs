using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World
{
    public class WorldBounds : MonoBehaviour
    {
        void Start()
        {
            Physics2D.IgnoreLayerCollision(9, 10);
        }
    }
}
