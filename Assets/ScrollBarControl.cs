using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarControl : MonoBehaviour
{

    public Scrollbar targetScrollBar;  // Reference to the scrollbar component
    public float targetValue = 0.5f;   // Target value to which you want to set the scrollbar

    // Call this function to set the scrollbar's position to the target value
    public void SetScrollbarPosition()
    {
        targetScrollBar.value = targetValue;
    }

    public void MoveForward()
    {
        targetValue = Mathf.Clamp(targetScrollBar.value + 0.2f, 0f, 1f);
        SetScrollbarPosition();
    }

    public void MoveBackward()
    {
        targetValue = Mathf.Clamp(targetScrollBar.value - 0.2f, 0f, 1f);
        SetScrollbarPosition();
    }


    // If you want to move the scrollbar over time, you can use a coroutine
    public void LerpToTargetValue(float duration)
    {
        StartCoroutine(LerpValue(targetValue, duration));
    }

    private IEnumerator LerpValue(float target, float duration)
    {
        float startValue = targetScrollBar.value;
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            targetScrollBar.value = Mathf.Lerp(startValue, target, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        targetScrollBar.value = target;  // Set the final value to ensure it reaches the target
    }
}
