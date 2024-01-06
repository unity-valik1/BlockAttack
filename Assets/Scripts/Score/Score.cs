using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _textCurrentScore;
    [SerializeField] private GameObject _score;

    [SerializeField] public int _currentScore;

    [SerializeField] private float _minTime;
    [SerializeField] private float _maxTime;

    public void ResetScore()
    {
        _currentScore = 0;
        _textCurrentScore.text = _currentScore.ToString();
    }
    public void AddPoints(int amountPoints)
    {
        _currentScore += amountPoints;
        AnimScore();
        SetProgress(_currentScore - amountPoints, _currentScore, amountPoints);
    }

    public void SetProgress(float value, float maxValue, int amountPoints)
    {
        float normalizedValue = value / maxValue;
        float duration = Mathf.Lerp(_minTime, _maxTime, normalizedValue);

        StartCoroutine(LerpValue(_currentScore - amountPoints, _currentScore, duration, SetTextValue));
    }

    private IEnumerator LerpValue(float startValue, float endValue, float duration, UnityAction<float> action)
    {
        //yield return new WaitForSeconds(1.3f);
        float elapsed = 0;
        float nextValue;

        while (elapsed < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            action?.Invoke(nextValue);
            elapsed += Time.deltaTime;
            yield return null;
        }
        _textCurrentScore.text =_currentScore.ToString();
    }

    private void SetTextValue(float value)
    {
        value = (int)value;
        _textCurrentScore.text =value.ToString();
    }

    private void AnimScore()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(1.3f);
        sequence.Append(_score.transform.DOScale(1.5f, 0.25f));
        sequence.Append(_score.transform.DOScale(1f, 0.25f));
    }
}
