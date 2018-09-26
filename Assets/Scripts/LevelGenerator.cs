﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;
    //all level pieces blueprints used to copy from
    public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
    //starting point of the very first level piece
    public Transform levelStartPoint;
    //all level pieces that are currently in the level
    public List<LevelPiece> pieces = new List<LevelPiece>();

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GenerateInitialPieces();
    }

    public void StartGame()
    {
        RemoveAllPieces();
        GenerateInitialPieces();
    }

    public void AddPiece()
    {
        //pick random number
        int randomeIndex = Random.Range(0, levelPrefabs.Count);

        //Instantiate copy of random level prefab and store it in piece variable
        LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[randomeIndex]);
        piece.transform.SetParent(transform, false);

        Vector3 spawnPosition = Vector3.zero;

        //position
        if (pieces.Count == 0)
        {
            //first piece
            spawnPosition = levelStartPoint.position;
        }
        else
        {
            //take exit point from last piece as a spawn point to new piece
            spawnPosition = pieces[pieces.Count - 1].exitPoint.position;
        }

        piece.transform.position = spawnPosition;
        pieces.Add(piece);
    }

    public void RemoveOldestPiece()
    {
        LevelPiece oldestPiece = pieces[0];

        pieces.Remove(oldestPiece);
        Destroy(oldestPiece.gameObject);
    }

    public void RemoveAllPieces()
    {
        while (pieces.Count != 0)
        {
            RemoveOldestPiece();
        }
    }

    public void GenerateInitialPieces()
    {
        for (int i = 0; i < 2; i++)
        {
            AddPiece();
        }
    }
}
