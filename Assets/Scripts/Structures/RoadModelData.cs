using UnityEngine;

[CreateAssetMenu(fileName = "RoadModelData", menuName = "ScriptableObjects/RoadModelData", order = 1)]
public class RoadModelData : ScriptableObject
{
    public GameObject DeadEnd;
    public GameObject RoadStraight;
    public GameObject Corner;
    public GameObject ThreeWay;
    public GameObject FourWay;
}
