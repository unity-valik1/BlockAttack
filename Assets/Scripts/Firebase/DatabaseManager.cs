//using Firebase.Database;
//using System;
//using System.Collections;
//using System.Linq;
//using UnityEngine;

//public class DatabaseManager : MonoBehaviour
//{
//    GameManager gameManager;
//    UILogicMainMenu uILogicMainMenu;
//    DatabaseReference dbReference;
//    //UILogicTopBar uILogicTopBar;

//    private string userID;
//    //public int _id;

//    public GameObject scoreElement;
//    public Transform scoreContent;

//    private void Awake()
//    {
//        Init();
//    }
//    private void Init()
//    {
//        gameManager = FindObjectOfType<GameManager>();
//        uILogicMainMenu = FindObjectOfType<UILogicMainMenu>();
//        //uILogicTopBar = FindObjectOfType<UILogicTopBar>();
//    }

//    void Start()
//    {
//        userID = SystemInfo.deviceUniqueIdentifier;
//        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
//    }

//    ////Статистика
//    //public void LoadStatsDB()
//    //{
//    //    StartCoroutine(Load());
//    //}
//    //public IEnumerator Load()
//    //{
//    //    var userLoad = dbReference.Child("user").Child(userID).GetValueAsync();

//    //    yield return new WaitUntil(predicate: () => userLoad.IsCompleted);

//    //    if (userLoad.Exception != null)
//    //    {

//    //    }
//    //    else if (userLoad.Result.Value == null)
//    //    {
//    //        gameManager.StandartGameManager();

//    //        SaveStatsDB();
//    //    }
//    //    else
//    //    {
//    //        //DataSnapshot snapshot = userLoad.Result;

//    //        //gameManager._playerCoins = int.Parse(snapshot.Child("coins").Value.ToString());
//    //        //gameManager._playerArmor = int.Parse(snapshot.Child("armor").Value.ToString());
//    //        //gameManager._playerBomb = int.Parse(snapshot.Child("bomb").Value.ToString());
//    //        //gameManager._playerBestScore = int.Parse(snapshot.Child("bestScore").Value.ToString());
//    //        //gameManager._playerName = snapshot.Child("userName").Value.ToString();

//    //        //uILogicTopBar._textPlayerCoins.text = gameManager._playerCoins.ToString();
//    //        //uILogicTopBar._textPlayerArmor.text = gameManager._playerArmor.ToString();
//    //        //uILogicTopBar._textPlayerBomb.text = gameManager._playerBomb.ToString();
//    //        //uILogicMainMenu._textBestScore.text = gameManager._playerBestScore.ToString();
//    //    }
//    //}

//    public void SaveStatsDB()
//    {
//        StartCoroutine(SaveCoins(gameManager._playerCoins));
//        StartCoroutine(SaveArmor(gameManager._playerArmor));
//        StartCoroutine(SaveBomb(gameManager._playerBomb));
//        StartCoroutine(SavePick(gameManager._playerPick));
//        StartCoroutine(SaveBestScore(gameManager._playerBestScore));
//        StartCoroutine(SaveName(gameManager._playerName));
//    }
//    public IEnumerator SaveCoins(int _coins)
//    {
//        var userCoins = dbReference.Child("user").Child(userID).Child("coins").SetValueAsync(_coins);

//        yield return new WaitUntil(predicate: () => userCoins.IsCompleted);

//        if (userCoins.Exception != null)
//        {
//        }
//        else
//        {
//        }
//    }
//    public IEnumerator SaveArmor(int _armor)
//    {
//        var userArmor = dbReference.Child("user").Child(userID).Child("armor").SetValueAsync(_armor);

//        yield return new WaitUntil(predicate: () => userArmor.IsCompleted);

//        if (userArmor.Exception != null)
//        {

//        }
//        else
//        {

//        }
//    }
//    public IEnumerator SaveBomb(int _bomb)
//    {
//        var userBomb = dbReference.Child("user").Child(userID).Child("bomb").SetValueAsync(_bomb);

//        yield return new WaitUntil(predicate: () => userBomb.IsCompleted);

//        if (userBomb.Exception != null)
//        {

//        }
//        else
//        {

//        }
//    }
//    public IEnumerator SavePick(int _pick)
//    {
//        var userpick = dbReference.Child("user").Child(userID).Child("pick").SetValueAsync(_pick);

//        yield return new WaitUntil(predicate: () => userpick.IsCompleted);

//        if (userpick.Exception != null)
//        {

//        }
//        else
//        {

//        }
//    }
//    public IEnumerator SaveBestScore(int _bestScore)
//    {
//        var userBestScore = dbReference.Child("user").Child(userID).Child("bestScore").SetValueAsync(_bestScore);

//        yield return new WaitUntil(predicate: () => userBestScore.IsCompleted);

//        if (userBestScore.Exception != null)
//        {

//        }
//        else
//        {

//        }
//    }
//    public IEnumerator SaveName(string _userName)
//    {
//        var userName = dbReference.Child("user").Child(userID).Child("userName").SetValueAsync(_userName);

//        yield return new WaitUntil(predicate: () => userName.IsCompleted);

//        if (userName.Exception != null)
//        {

//        }
//        else
//        {

//        }
//    }

//    ////id
//    //public void LoadIdDB()
//    //{
//    //    StartCoroutine(Id());
//    //}
//    //public IEnumerator Id()
//    //{
//    //    var id = dbReference.Child("id").GetValueAsync();

//    //    yield return new WaitUntil(predicate: () => id.IsCompleted);

//    //    if (id.Exception != null)
//    //    {

//    //    }
//    //    else
//    //    {
//    //        DataSnapshot snapshot = id.Result;

//    //        _id = int.Parse(snapshot.Child("number").Value.ToString());
//    //        _id++;
//    //        SaveIdDB();
//    //        SaveStatsDB();
//    //    }
//    //}

//    //public void SaveIdDB()
//    //{
//    //    StartCoroutine(SaveId(_id));
//    //}
//    //public IEnumerator SaveId(int _id)
//    //{
//    //    var userId = dbReference.Child("id").Child("number").SetValueAsync(_id);

//    //    yield return new WaitUntil(predicate: () => userId.IsCompleted);

//    //    if (userId.Exception != null)
//    //    {
//    //    }
//    //    else
//    //    {
//    //    }
//    //}

//    ////Таблмца рейтинга
//    //public void LoadScoreboardDB()
//    //{
//    //    StartCoroutine(ScoreboardUserBestScore());
//    //}
//    //public IEnumerator ScoreboardUserBestScore()
//    //{
//    //    uILogicMainMenu.ScoreboardLoadingIsActiveTrue();
//    //    var userBestScore = dbReference.Child("user").OrderByChild("bestScore").GetValueAsync();

//    //    yield return new WaitUntil(predicate: () => userBestScore.IsCompleted);

//    //    if (userBestScore.Exception != null)
//    //    {

//    //    }
//    //    else if (userBestScore.Result.Value == null)
//    //    {

//    //    }
//    //    else
//    //    {
//    //        DataSnapshot snapshot = userBestScore.Result;

//    //        foreach (Transform child in scoreContent.transform)
//    //        {
//    //            Destroy(child.gameObject);
//    //        }

//    //        int numberPlace = 1;
//    //        foreach (DataSnapshot childSnapshot in snapshot.Children.Reverse<DataSnapshot>())
//    //        {
//    //            string userName = childSnapshot.Child("userName").Value.ToString();
//    //            int bestScore = int.Parse(childSnapshot.Child("bestScore").Value.ToString());
//    //            if (numberPlace == 1)
//    //            {
//    //                GameObject scoreboardElement = Instantiate(scoreElement, scoreContent);
//    //                scoreboardElement.GetComponent<ScoreboardElement>().NewScoreElement(userName, bestScore, numberPlace);
//    //                scoreboardElement.GetComponent<ScoreboardElement>().UpdateImgPlace(numberPlace);
//    //            }
//    //            else if (numberPlace == 2)
//    //            {
//    //                GameObject scoreboardElement = Instantiate(scoreElement, scoreContent);
//    //                scoreboardElement.GetComponent<ScoreboardElement>().NewScoreElement(userName, bestScore, numberPlace);
//    //                scoreboardElement.GetComponent<ScoreboardElement>().UpdateImgPlace(numberPlace);
//    //            }
//    //            else if (numberPlace == 3)
//    //            {
//    //                GameObject scoreboardElement = Instantiate(scoreElement, scoreContent);
//    //                scoreboardElement.GetComponent<ScoreboardElement>().NewScoreElement(userName, bestScore, numberPlace);
//    //                scoreboardElement.GetComponent<ScoreboardElement>().UpdateImgPlace(numberPlace);
//    //            }
//    //            else
//    //            {
//    //                GameObject scoreboardElement = Instantiate(scoreElement, scoreContent);
//    //                scoreboardElement.GetComponent<ScoreboardElement>().NewScoreElement(userName, bestScore, numberPlace);
//    //            }
//    //            //GameObject scoreboardElement = Instantiate(scoreElement, scoreContent);
//    //            //scoreboardElement.GetComponent<ScoreboardElement>().NewScoreElement(userName, bestScore, numberPlace);
//    //            if (numberPlace == 100)
//    //            {
//    //                break;
//    //            }
//    //            numberPlace++;
//    //        }
//    //        uILogicMainMenu.ScoreboardPanelIsActiveTrue();
//    //        uILogicMainMenu.ScoreboardLoadingIsActiveFalse();
//    //    }
//    //}
//}
