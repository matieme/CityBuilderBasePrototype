using System;
using UnityEngine;

[Serializable]
public struct StructurePrefabWeighted
{
    public GameObject prefab;
    [Range(0,1)]
    public float weight;
}
