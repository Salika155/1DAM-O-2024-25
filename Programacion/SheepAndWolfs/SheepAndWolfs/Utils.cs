using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepAndWolfs
{
    public enum TerritorioType
    {
        VACIO,
        HIERBA,
        AGUA,
        COUNT
    }

    public class Utils
    {
        private static Random random = new Random();

        //GetCasillaAt
        public static Casilla? GetCasillaAt(Mundo mundo, int x, int y)
        {
            if (mundo == null)
                return null;
            if (x < 0 || y < 0 || x >= mundo.GetWidth() || y >= mundo.GetHeight())
                return null;
            return mundo.GetCasillaAt(x, y);
        }

        public static int GetRandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        public static void GenerateRandomWorld(Mundo mundo)
        {
            if (mundo == null) 
                return;

            for(int y = 0; y < mundo.GetHeight(); y++) 
            {
                for(int x = 0; x < mundo.GetWidth(); x++)
                {
                    TerritorioType type = GenerateRandomType();
                    Casilla? casilla = mundo.GetCasillaAt(x, y);
                    if (casilla != null)
                    {
                        casilla.type = type;
                    }
                }
            }
        }

        public static int IndexOfCasilla(int x, int y, int width)
        {
            if (x < 0 || y < 0 || width <= 0)
                return -1;

            return y * width + x;
        }

        private static TerritorioType GenerateRandomType()
        {
            //TerritorioType[] terreno = { TerritorioType.AGUA, TerritorioType.HIERBA, TerritorioType.VACIO };
            int index = random.Next((int)TerritorioType.COUNT);
            //return terreno[index];
            //mejor opcion
            return (TerritorioType)index;
        }

        public static bool EqualsToCoordenada(Coordenada coor, int x, int y)
        {
            return coor.X == x && coor.Y == y;
        }

        public static (int x, int y) GetCoordinatesFromIndex(int index, int width)
        {
            if (width == 0)
                return (int.MinValue, int.MinValue);
            return (index % width, index / width);
        }


    }
}
