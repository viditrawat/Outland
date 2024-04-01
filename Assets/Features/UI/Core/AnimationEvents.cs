using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvents : MonoBehaviour
{
    public List<UnityEvent> animationEvents;

    public void PlayAnimation(int _index)
    {
        if (TryGetEvent(_index, out var _event))
        {
            _event?.Invoke();
        }
    }

    private bool TryGetEvent(int _index, out UnityEvent _event)
    {
        if (_index < animationEvents.Count)
        {
            _event = animationEvents[_index];
        }
        else
        {
            _event = null;

        }

        return _event != null;
    }
}
