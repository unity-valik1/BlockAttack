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
    ////            Debug.Log("Интернет доступен!");
    ////            // Здесь вы можете выполнить нужные действия, связанные с наличием интернета
    ////        }
    ////        else
    ////        {
    ////            internetAccess.NoInternetConnectionIsActiveTrue();
    ////            Debug.Log("Нет подключения к интернету");
    ////        }
    ////        yield return new WaitForSeconds(2f); // Можно изменить интервал проверки
    ////    }
    ////}
    

    //public void CheckInternetConnection()
    //{
    //    StartCoroutine(CheckInternetAlways());
    //}//проверяет интернет каждые 2 секунды
    //private IEnumerator CheckInternetAlways()
    //{
    //    while (true)
    //    {
    //        if (Application.internetReachability != NetworkReachability.NotReachable)
    //        {
    //            Debug.Log("Интернет доступен!");
    //            // Здесь вы можете выполнить нужные действия, связанные с наличием интернета
    //        }
    //        else
    //        {
    //            NoInternetConnectionIsActiveTrue();
    //            Debug.Log("Нет подключения к интернету");
    //        }
    //        yield return new WaitForSeconds(2f); // Можно изменить интервал проверки
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
            Debug.Log("Интернет соединение установлено!");
        }
        else
        {
            NoInternetConnectionIsActiveTrue();
            Debug.Log("Нет подключения к интернету!");
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
