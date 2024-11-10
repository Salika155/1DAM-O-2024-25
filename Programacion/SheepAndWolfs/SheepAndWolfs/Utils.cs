using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepAndWolfs
{
    public class Utils
    {
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
                    casilla.type = type;
                }
            }
        }

        private static TerritorioType GenerateRandomType()
        {
            throw new NotImplementedException();    
        }

        public void Init()
        {

        }
    }
}
