using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InternetAccess : MonoBehaviour
{
    DatabaseManager databaseManager;

    [SerializeField] private GameObject noInternetConnection;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        databaseManager = FindObjectOfType<DatabaseManager>();
    }

    //private void Start()
    //{
    //    //CheckInternetConnection();
    //}
    ////IEnumerator Start()
    ////{
    ////    while (true)
    ////    {
    ////        if (Application.internetReachability != NetworkReachability.NotReachable)
    ////        {
    ////            internetAccess.NoInternetConnectionIsActiveFalse();
    ////            Debug.Log("�������� ��������!");
    ////            // ����� �� ������ ��������� ������ ��������, ��������� � �������� ���������
    ////        }
    ////        else
    ////        {
    ////            internetAccess.NoInternetConnectionIsActiveTrue();
    ////            Debug.Log("��� ����������� � ���������");
    ////        }
    ////        yield return new WaitForSeconds(2f); // ����� �������� �������� ��������
    ////    }
    ////}
    

    //public void CheckInternetConnection()
    //{
    //    StartCoroutine(CheckInternetAlways());
    //}//��������� �������� ������ 2 �������
    //private IEnumerator CheckInternetAlways()
    //{
    //    while (true)
    //    {
    //        if (Application.internetReachability != NetworkReachability.NotReachable)
    //        {
    //            Debug.Log("�������� ��������!");
    //            // ����� �� ������ ��������� ������ ��������, ��������� � �������� ���������
    //        }
    //        else
    //        {
    //            NoInternetConnectionIsActiveTrue();
    //            Debug.Log("��� ����������� � ���������");
    //        }
    //        yield return new WaitForSeconds(2f); // ����� �������� �������� ��������
    //    }
    //}

    public void CheckInternetConnectionScoreboard()
    {
        StartCoroutine(CheckInternet());
    }
    private IEnumerator CheckInternet()
    {
        UnityWebRequest www = new("http://www.google.com");
        DownloadHandler dh = new DownloadHandlerBuffer();
        www.downloadHandler = dh;

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            databaseManager.SaveStatsDB();
            databaseManager.LoadScoreboardDB();
            Debug.Log("�������� ���������� �����������!");
        }
        else
        {
            NoInternetConnectionIsActiveTrue();
            Debug.Log("��� ����������� � ���������!");
        }
    }

    public void NoInternetConnectionIsActiveTrue()
    {
        noInternetConnection.SetActive(true);
    }
    public void NoInternetConnectionIsActiveFalse()
    {
        noInternetConnection.SetActive(false);
    }
}
