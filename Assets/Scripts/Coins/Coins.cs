using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Coins : MonoBehaviour
{
    [SerializeField] private TMP_Text _textCurrentCoins;
    [SerializeField] private GameObject _coins;

    [SerializeField] private int _currentCoins;

    [SerializeField] private float _minTime;
    [SerializeField] private float _maxTime;

    public void AddCoins()
    {
        int amountCoins = Random.Range(1, 11);
        _currentCoins += amountCoins;
        AnimCoins();
        SetProgress(_currentCoins - amountCoins, _currentCoins, amountCoins);
    }

    public void SetProgress(float value, float maxValue, int amountPoints)
    {
        float normalizedValue = value / maxValue;
        float duration = Mathf.Lerp(_minTime, _maxTime, normalizedValue);

        StartCoroutine(LerpValueCoins(_currentCoins - amountPoints, _currentCoins, duration, SetTextValue));
    }

    private IEnumerator LerpValueCoins(float startValue, float endValue, float duration, UnityAction<float> action)
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
        _textCurrentCoins.text = _currentCoins.ToString();
    }

    private void SetTextValue(float value)
    {
        value = (int)value;
        _textCurrentCoins.text = value.ToString();
    }

    private void AnimCoins()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(1.3f);
        sequence.Append(_coins.transform.DOScale(1.5f, 0.25f));
        sequence.Append(_coins.transform.DOScale(1f, 0.25f));
    }
}
