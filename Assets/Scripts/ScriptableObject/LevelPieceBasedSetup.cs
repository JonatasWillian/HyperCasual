using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelPieceBasedSetup : ScriptableObject
{
    public ArtManager.ArtType artType;

    [Header("Pieces")]
    public List<LevelPieceBase> levelPieceStart;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPieceEnd;

    public int piecesStartNumber = 3;
    public int piecesNumber = 3;
    public int piecesEndNumber = 3;
}
