using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using TMPro;

public class Datamanager : MonoBehaviour
{
    private string connectionString;
    private IDbConnection dbConnection;
    [SerializeField] private TMP_Text textArea;
    // Start is called before the first frame update
    void Start()
    {
        connectionString = "URI=file:Assets/Videopelit.db";

        dbConnection = new SqliteConnection(connectionString);
        dbConnection.Open();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FetchData()
    {

        using (IDbCommand dbCmd = dbConnection.CreateCommand())
        {
            dbCmd.CommandText = "SELECT * FROM Tulostaulu ORDER BY pisteet DESC limit 5";
            using (IDataReader reader = dbCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string pealaajaNimi = reader.GetString(1);
                    int pisteet = reader.GetInt32(2);

                    Debug.Log($"Pelaajan nimi: {pealaajaNimi}, pisteet: {pisteet}");
                    textArea.text += ($"Pelaajan nimi: {pealaajaNimi}, pisteet: {pisteet}<br>"); 
                }
            }
        }
    }
}
