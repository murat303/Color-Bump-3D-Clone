using ColorBump;
using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Image progressBar;

    Level currentLevel;
    float lastProgress;

    public float EntireDistance { get; private set; }
    public float DistanceLeft { get; private set; }

    void Start()
    {
        currentLevel = LevelManager.ins.GetLevel();
        EntireDistance = currentLevel.finishLine.position.z - currentLevel.startLine.position.z;
    }

    void Update()
    {
        if (LevelManager.ins.IsGameStarted)
        {
            DistanceLeft = Vector3.Distance(player.position, currentLevel.finishLine.position);

            if (DistanceLeft > EntireDistance)
                DistanceLeft = EntireDistance;

            if (player.position.z > currentLevel.finishLine.position.z)
                DistanceLeft = 0;

            var traveledDistance = EntireDistance - DistanceLeft;
            var progress = traveledDistance / EntireDistance;

            if (progress < lastProgress) return; //if the player goes back, stop progress 

            progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, progress, 5 * Time.deltaTime);
            lastProgress = progress;

            Logger.LogDistance(DistanceLeft, EntireDistance);
        }
    }
}
