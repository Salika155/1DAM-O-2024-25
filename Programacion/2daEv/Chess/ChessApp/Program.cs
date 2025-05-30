﻿using ChessLib;
using ChessLib.Figuras;
using ChessLib.Tablero;

namespace ChessApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Crear el tablero de ajedrez
            ChessBoard board = new ChessBoard(8, 8);
            board.InitBoard();
            board.PrintBoard();

            // Crear figuras (ejemplo)
            //Bishop bishop = new Bishop(FigureColor.WHITE, new Coord(0, 0), FigureType.BISHOP);

            // Imprimir algo para probar
            //Console.WriteLine($"Tablero: {board.Width}x{board.Height}");
            //Console.WriteLine($"Bishop coords: {bishop.Coords.X}, {bishop.Coords.Y}");
        }
    }
}
