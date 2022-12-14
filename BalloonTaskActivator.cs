using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by Zane
public class BalloonTaskActivator : MonoBehaviour
{
    [SerializeField] private List<Rigidbody2D> balloons;
    [SerializeField] private List<GameObject> alertIcons;
    [SerializeField] private List<Animator> balloonAnimators;
    [SerializeField] private List<GameObject> arrowTargets;

    [SerializeField] public float balloonSpeed;
    [SerializeField] private float minimumActivationInterval;
    [SerializeField] private float maximumActivationInterval;

    private float activationInterval;
    private int balloonsIndex;

    private void Start()
    {
        // balloons start to be activated
        activationInterval = Random.Range(minimumActivationInterval, maximumActivationInterval);
        InvokeRepeating("ActivateBalloon", 5f, activationInterval);
    }

    private void ActivateBalloon()
    {
        // checks if balloon has been destroyed
        if (balloons == null || balloonAnimators[balloonsIndex] == null)
        {
            // removes balloon from each list when activated
            balloons.Remove(balloons[balloonsIndex]);
            balloonAnimators.Remove(balloonAnimators[balloonsIndex]);
            arrowTargets.Remove(arrowTargets[balloonsIndex]);
            alertIcons.Remove(alertIcons[balloonsIndex]);
        }

        // checks if there are no balloons in the list
        if (balloons.Count == 0 || balloonAnimators.Count == 0)
        {
            CancelInvoke();
        }
        else
        {
            // gets random index from balloons list
            balloonsIndex = Random.Range(0, balloons.Count);

            // random balloon starts to float upwards
            balloons[balloonsIndex].velocity = new Vector2(0f, 1f * balloonSpeed);
            balloonAnimators[balloonsIndex].SetBool("Fixed", false);
            balloonAnimators[balloonsIndex].SetTrigger("Danger");
            alertIcons[balloonsIndex].SetActive(true);
            arrowTargets[balloonsIndex].SetActive(true);
        }
    }
}
