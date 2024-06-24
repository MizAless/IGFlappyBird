using AppsFlyerSDK;
using System.Collections.Generic;
using UnityEngine;

public class AppsFlyerTracker : MonoBehaviour
{
    [SerializeField] private Score _score;

    private void OnEnable()
    {
        _score.Changed += TrackClick;
    }

    private void OnDisable()
    {
        _score.Changed -= TrackClick;
    }

    private void TrackClick(int score)
    {
        Dictionary<string, string> eventValues = new Dictionary<string, string>();
        string eventName = "af_score";
        eventValues.Add(eventName, score.ToString());
        AppsFlyer.sendEvent(AFInAppEvents.SCORE, eventValues);
        print("Score tracked: " + eventName + " " + score.ToString());
    }
}
