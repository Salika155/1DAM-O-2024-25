using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepAndWolfs
{
    public class AI
    {
        public enum IAType
        {
            Mover,
            Comer,
            Beber,
            Dormir,
            COUNT

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

        public void ExecuteTurns(Mundo mundo)
        {
            for (int i = 0; i < 20; i++)
            {
                foreach (Animal animal in mundo.GetAllAnimals())
                {
                    var actiondecided = DecideAnimalAccion(animal, mundo);

                    switch (actiondecided)
                    {
                        case IAType.Mover:
                            Utils.MoveAnimal(animal, mundo);
                            break;
                        case IAType.Comer:
                            ComerHierbaCercanaAnimal(animal, mundo);
                            break;
                        case IAType.Beber:
                            BeberAguaCercanaAnimal(animal, mundo);
                            break;
                        case IAType.Dormir:
                            DormiAnimal(animal, mundo);
                            break;
                    }
                }

                ActualizarEstadoAnimalesPorTurno(mundo);
                EliminarAnimalesmuertos(mundo);

                Utils.DrawWorld(mundo);
            }

        }

        


        private void EliminarAnimalesmuertos(Mundo mundo)
        {
            throw new NotImplementedException();
        }


        //Para actualizar los atributos a cada turno que pasa a los animales
        private void ActualizarEstadoAnimalesPorTurno(Mundo mundo)
        {
            foreach (var animales in mundo.GetAllAnimals())
            {
                animales.food -= 10;
                animales.water -= 10;
                animales.sleep -= 10;
            }
        }

        private IAType DecideAnimalAccion(Animal animal, Mundo mundo)
        {
            if (animal.food <= 200 && mundo.EstaCercaHierba(animal, mundo))
                return IAType.Comer;
            if (animal.water <= 200 && EstaAguaCerca(animal, mundo))
                return IAType.Beber;
            if (animal.sleep <= 200)
                return IAType.Dormir;
            return IAType.Mover;
        }

        private bool EstaAguaCerca(Animal animal, Mundo mundo)
        {
            return true;
        }

        

        

        public void ComerHierbaCercanaAnimal(Animal animal, Mundo mundo)
        {
            Casilla? casillaHierba = EstaCercaHierba(animal, mundo);
            if (casillaHierba != null)
            {
                animal.food += 50;
            }
        }

        //esto hay que replantearselo
        private Casilla? EstaCercaHierba(Animal animal, Mundo mundo)
        {
           throw new NotImplementedException();

        }

        public void BeberAguaCercanaAnimal(Animal animal, Mundo mundo)
        {
            //Casilla? casillaAgua = EstaAguaCerca(animal, mundo);
            //if (casillaAgua != null)
            //{
            //    animal.water += 50;
            //}
            throw new NotImplementedException();
        }



        internal static void DormiAnimal(Animal animal, Mundo mundo)
        {
            animal.sleep += 50;
        }
    }
}
