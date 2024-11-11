using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepAndWolfs
{
    public enum TerritorioType
    {

    }
    public class Utils
    {
        private Random random = new Random();


        public static void GenerateRandomWorld(Mundo mundo)
        {
            if (mundo == null) 
                return;

            for(int y = 0; y < mundo.GetHeight(); y++) 
            {
                for(int x = 0; x < mundo.GetWidth(); x++)
                {
                    TerritorioType type = Utils.GenerateRandomType(type);
                    Casilla? casilla = mundo.GetCasillaAt(x, y);
                    casilla.type = type;
                }
            }
        }

        private TerritorioType GenerateRandomType()
        {
            TerritorioType[] terreno = { TerritorioType.AGUA, TerritorioType.HIERBA, TerritorioType.VACIO };
            int index = random.Next((int)TerritorioType.Count);
            return terreno[index];
            //mejor opcion return (TerrainType)index;

        }

        public void Init()
        {

        }
    }
}
