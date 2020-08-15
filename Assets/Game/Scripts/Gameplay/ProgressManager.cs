using ColorBump;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public Transform player;
    Level currentLevel;

    public float EntireDistance { get; private set; }
    public float DistanceLeft { get; private set; }

    void Start()
    {
        currentLevel = LevelManager.ins.GetLevel();
        EntireDistance = currentLevel.finishLine.position.z - currentLevel.startLine.position.z;
    }

    void Update()
    {
        DistanceLeft = Vector3.Distance(player.position, currentLevel.finishLine.position);

        if (DistanceLeft > EntireDistance)
            DistanceLeft = EntireDistance;

        if (player.position.z > currentLevel.finishLine.position.z)
            DistanceLeft = 0;

        Debug.Log("Distance: " + DistanceLeft + " / " + EntireDistance);
    }
}
