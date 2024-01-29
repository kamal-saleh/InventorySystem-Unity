using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeleteChildren
{
    public static class TransformExtension
    {
        public static Transform ClearChildren(this Transform transform, List<string> skippedNames = null)
        {
            if (transform == null || transform.gameObject == null || transform.gameObject.activeSelf == false)
            {
                return transform;
            }

            skippedNames = skippedNames ?? new List<string>();
            foreach (Transform child in transform)
            {
                if (skippedNames.Contains(child.name) == false)
                {
                    GameObject.Destroy(child.gameObject);
                }
            }

            return transform;
        }
    }
}