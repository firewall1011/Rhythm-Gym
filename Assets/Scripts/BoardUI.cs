using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardUI : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text pointsText;
    [SerializeField] TMPro.TMP_Text StageText;

    private void Start()
    {
        RythimGenerator.OnPointsChanged += HandlePoints;
        RythimGenerator.OnStateChange += HandleStage;
    }

    private void HandleStage(int stage)
    {
        StageText.text = $"Stage: {stage}";
    }

    private void HandlePoints(int points)
    {
        pointsText.text = $"Points: {points}";
    }
}
