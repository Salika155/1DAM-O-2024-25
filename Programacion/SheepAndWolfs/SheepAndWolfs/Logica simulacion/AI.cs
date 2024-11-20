using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepAndWolfs
{
    internal class AI
    {
        public enum IAType
        {
            Mover,
            Comer,
            Beber,
            Dormir

            //posible que si hago mover animal acorte y solo tenga que pasarle el tipo para saber si es un lobo o una oveja
        }

        private readonly IAType[] _iATypes = [IAType.Mover, IAType.Comer, IAType.Beber, IAType.Dormir];

        //Hacer funcion si oveja puede moverse, o si lobo puede moverse

        //world w = new world
        //utils.InitializeRandomWorld(w)
        //while (w.ContainsSheeps() || w.ContainsWater()
        //w.ExecuteTurns();

        //public IAType GetIAType(AI ai)
        //{
        //    for (int i = 0; i < _iATypes.Length; i++)
        //    {
        //        if (_iATypes[i] == IAType.MoverAbajo)
        //            return IAType.MoverAbajo;
        //        if (_iATypes[i] == IAType.MoverArriba)
        //            return IAType.MoverArriba;
        //        if (_iATypes[i] == IAType.MoverDerecha)
        //            return IAType.MoverDerecha;
        //        if (_iATypes[i] == IAType.MoverIzquierda)
        //            return IAType.MoverIzquierda;
        //        if (_iATypes[i] == IAType.Beber)
        //            return IAType.Beber;
        //        if (_iATypes[i] == IAType.Comer)
        //            return IAType.Comer;
        //        else
        //            return IAType.Dormir;
        //    }

        //}

        public void MoveAnimalType(IAType type, Animal animal)
        {
            if (animal.food <= 200)
                type = IAType.Comer;
            if (animal.water <= 200)
                type = IAType.Beber;
            if (animal.sleep <= 200)
                type = IAType.Dormir;

        }

        public void ExecuteTurns()
        {
            

        }
    }
}
