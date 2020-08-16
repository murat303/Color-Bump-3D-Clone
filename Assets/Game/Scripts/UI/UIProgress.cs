using ColorBump;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIProgress : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Image progressBar;
    [SerializeField] TextMeshProUGUI txtCurrentLevel;
    [SerializeField] TextMeshProUGUI txtNextLevel;

    Level currentLevel;
    float lastProgress;

    public float EntireDistance { get; private set; }
    public float DistanceLeft { get; private set; }

    void Start()
    {
        currentLevel = LevelManager.ins.GetLevel();
        EntireDistance = currentLevel.finishLine.position.z - currentLevel.startLine.position.z;

        currentLevel.txtStage.text = "STAGE " + currentLevel.level.ToString();
        txtCurrentLevel.text = currentLevel.level.ToString();
        txtNextLevel.text = (currentLevel.level + 1).ToString();
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
