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


        public void MoveAnimalType(IAType type, Animal animal)
        {
            if (animal.food <= 100)
                type = IAType.Comer;
            if (animal.water <= 100)
                type = IAType.Beber;
            if (animal.sleep <= 100)
                type = IAType.Dormir;

        }

        //TODO: necesario para que funcione por turnos
        public void ExecuteTurns(Mundo mundo)
        {
            for (int i = 0; i < 20; i++)
            {
                foreach (Animal animal in mundo.GetAllAnimals())
                {
                    var actiondecided = DecideAnimalAccion(animal, mundo);
                    Console.WriteLine($"Animal {animal} decide: {actiondecided}");

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

                mundo.ActualizarEstadoAnimalesPorTurno();
                mundo.EliminarAnimalesmuertos();
                Utils.DrawWorld(mundo);
                Thread.Sleep(500);
            }

        }

        //TODO: necesario para que funcione por turnos
        private IAType DecideAnimalAccion(Animal animal, Mundo mundo)
        {
            if (animal.food <= 200 && mundo.EstaCercaHierba(animal, mundo))
                return IAType.Comer;
            if (animal.water <= 200 && mundo.EstaAguaCercaDelAnimal(animal, mundo))
                return IAType.Beber;
            if (animal.sleep <= 200)
                return IAType.Dormir;
            return IAType.Mover;
        }

        public Casilla? EstaAguaCerca(Animal animal, Mundo mundo)
        {
            Casilla? casillaAgua = null;
            double minDistance = double.MaxValue;
            var _casillasArray = mundo.GetAllCasillas();
            for (int i = 0; i < _casillasArray.Length; i++)
            {
                Casilla casilla = _casillasArray[i];
                if (casilla.type == TerritorioType.AGUA)
                {
                    double distance = Utils.GetDistance(animal.coordenada, casilla.coordenada);
                    if (distance < 2 && distance < minDistance)
                    {
                        minDistance = distance;
                        casillaAgua = casilla;
                    }
                }
            }
            return casillaAgua;
        }

        //TODO: necesario para que funcione por turnos
        public void ComerHierbaCercanaAnimal(Animal animal, Mundo mundo)
        {
            Casilla? casillaHierba = EstaCercaHierba(animal, mundo);
            if (casillaHierba != null)
            {
                animal.food += 50;

            }
        }

        //esto hay que replantearselo
        public Casilla? EstaCercaHierba(Animal animal, Mundo mundo)
        {
            Casilla? casillaHierba = null;
            double minDistance = double.MaxValue;
            var _casillasArray = mundo.GetAllCasillas();
            for (int i = 0; i < _casillasArray.Length; i++)
            {
                Casilla casilla = _casillasArray[i];
                if (casilla.type == TerritorioType.HIERBA)
                {
                    double distance = Utils.GetDistance(animal.coordenada, casilla.coordenada);
                    if (distance < 2 && distance < minDistance)
                    {
                        minDistance = distance;
                        casillaHierba = casilla;
                    }
                }
            }
            return casillaHierba;
        }

        //TODO: necesario para que funcione por turnos
        public void BeberAguaCercanaAnimal(Animal animal, Mundo mundo)
        {
            Casilla? casillaAgua = EstaAguaCerca(animal, mundo);
            if (casillaAgua != null)
            {
                animal.water += 50;
            }
        }

        public static void DormiAnimal(Animal animal, Mundo mundo)
        {
            animal.sleep += 50;
        }
    }
}
