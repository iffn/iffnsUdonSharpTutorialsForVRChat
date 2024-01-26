// MIT License
// Copyright (c) 2021 Merlin

using System.Collections.Generic;
using UdonSharp;
using UnityEngine;

[DefaultExecutionOrder(1000000000)]
public class GlobalProfileHandler : UdonSharpBehaviour
{
    TMPro.TextMeshProUGUI timeText;
    GlobalProfileKickoff kickoff;

    private void Start()
    {
        kickoff = GetComponent<GlobalProfileKickoff>();
        timeText = GetComponentInChildren<TMPro.TextMeshProUGUI>();
    }

    int currentFrame = -1;
    float elapsedTime = 0f;

    private void FixedUpdate()
    {
        if (currentFrame != Time.frameCount)
        {
            elapsedTime = 0f;
            currentFrame = Time.frameCount;
        }

        if (kickoff)
            elapsedTime += (float)kickoff.stopwatch.Elapsed.TotalSeconds * 1000f;
    }

    private void Update()
    {
        if (currentFrame != Time.frameCount) // FixedUpdate didn't run this frame, so reset the time
            elapsedTime = 0f;

        elapsedTime += (float)kickoff.stopwatch.Elapsed.TotalSeconds * 1000f;
    }

    private void LateUpdate()
    {
        elapsedTime += (float)kickoff.stopwatch.Elapsed.TotalSeconds * 1000f;

        timeText.text = $"U# Update time:\n{elapsedTime:F4}ms";
    }
}