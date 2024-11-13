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

        private static TerritorioType GenerateRandomType()
        {
            //TerritorioType[] terreno = { TerritorioType.AGUA, TerritorioType.HIERBA, TerritorioType.VACIO };
            int index = random.Next((int)TerritorioType.COUNT);
            //return terreno[index];
            //mejor opcion
            return (TerritorioType)index;
        }

        //public void Init()
        //{

        //}

        //funcion drawworld
    }
}
