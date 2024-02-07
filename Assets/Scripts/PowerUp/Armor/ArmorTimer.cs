using TMPro;
using UnityEngine;

public class ArmorTimer : MonoBehaviour
{
    Armor armor;
    [SerializeField] private float _timeTimer;
    [SerializeField] private float _timeStart;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private GameObject _timerPanel;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        armor = FindObjectOfType<Armor>();
    }
    void Start()
    {
        _timeTimer = _timeStart;
        _timerText.text = _timeTimer.ToString();
    }

    void Update()
    {
        TimerActive();
    }
    public void TimerActive()
    {
        if (_timeTimer <= 0)
        {
            armor.ArmoreOff();
        }
        _timeTimer -= Time.deltaTime;
        _timerText.text = Mathf.Round(_timeTimer).ToString();
    }

    public void OnTimerScript()
    {
        enabled = true;
        _timerPanel.SetActive(true);
    }
    public void OffTimerScript()
    {
        enabled = false;
        _timerPanel.SetActive(false);
        _timeTimer = _timeStart;
        _timerText.text = _timeTimer.ToString();
    }

    public void StopTimer()
    {
        enabled = false;
    }
    public void StartTimer()
    {
        enabled = true;
    }
}
