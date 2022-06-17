/*
*   Chess pieces 3 ver 3
*   With classes, factory and enum
*   DKY 25.04.2021 
*/

using System;
using System.Collections.Generic;

namespace Chess4
{
    public enum ChessPieces
    {
        King,
        Queen,
        Bishop,
        Knight,
        Rook,
        Pawn
    }

    public static class PieceMaker
    {
        private static readonly Dictionary<string, ChessPieces> ChessPiecesCode;

        static PieceMaker()
        {
            ChessPiecesCode = new Dictionary<string, ChessPieces>()
            {
                { "King",  ChessPieces.King},
                { "K",  ChessPieces.King},
                { "Queen",  ChessPieces.Queen},
                { "Q",  ChessPieces.Queen},
                { "Bishop",  ChessPieces.Bishop},
                { "B",  ChessPieces.Bishop},
                { "Knight",  ChessPieces.Knight},
                { "N",  ChessPieces.Knight},
                { "Rook",  ChessPieces.Rook},
                { "R",  ChessPieces.Rook},
                { "Pawn",  ChessPieces.Pawn},
                { "P",  ChessPieces.Pawn}
            };
        }

        static public Piece Make(ChessPieces pieceCode, int x, int y)
        {
            Piece piece = null;

            switch (pieceCode)
            {
                case ChessPieces.King:
                    piece = new King(x, y);
                    break;
                case ChessPieces.Queen:
                    piece = new Queen(x, y);
                    break;
                case ChessPieces.Bishop:
                    piece = new Bishop(x, y);
                    break;
                case ChessPieces.Knight:
                    piece = new Knight(x, y);
                    break;
                case ChessPieces.Rook:
                    piece = new Rook(x, y);
                    break;
                case ChessPieces.Pawn:
                    piece = new Pawn(x, y);
                    break;

                default:
                    throw new Exception("Unknown piece code");
            }

            return piece;
        }

        static public Piece Make(string pieceCode, int x, int y)
        {
            return Make(ChessPiecesCode[pieceCode], x, y);
        }

        static public Piece Make(string pieceCode, string position)
        {
            return Make(ChessPiecesCode[pieceCode], position);
        }

        static public Piece Make(ChessPieces pieceCode, string position)
        {
            (int x, int y) = Piece.Parse(position);
            return Make(pieceCode, x, y);
        }
    }
}
