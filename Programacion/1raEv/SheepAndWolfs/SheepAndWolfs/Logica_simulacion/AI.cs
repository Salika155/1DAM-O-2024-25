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
        }

        private readonly IAType[] _iATypes = [IAType.Mover, IAType.Comer, IAType.Beber, IAType.Dormir];

        //Hacer funcion si oveja puede moverse, o si lobo puede moverse

        //world w = new world
        //utils.InitializeRandomWorld(w)
        //while (w.ContainsSheeps() || w.ContainsWater()
        //w.ExecuteTurns();

        //TODO: necesario para que funcione por turnos
        public void ExecuteTurns(Mundo mundo)
        {
            for (int i = 0; i < 30; i++)
            {
                var animales = mundo.GetAllAnimals();
                for (int j = animales.Count - 1; j >= 0; j--)
                {
                    var animal = animales[j];
                    var actionDecidida = DecideAnimalAccion(animal, mundo);
                    Console.WriteLine($"Animal {animal} decide: {actionDecidida}");
                    HacerAccionCercanaAnimal(animal, mundo);
                }
                mundo.ActualizarEstadoAnimalesPorTurno();
                mundo.EliminarAnimalesmuertos();
                Utils.DrawWorld(mundo);
                Thread.Sleep(500);
            }
        }

        //TODO: necesario para que funcione por turnos
        private static IAType DecideAnimalAccion(Animal animal, Mundo mundo)
        {
            if (animal.GetSaciedad() <= 150 && mundo.EstaCercaHierba(animal))
                return IAType.Comer;
            if (animal.GetHidratacion() <= 150 && mundo.EstaAguaCercaDelAnimal(animal))
                return IAType.Beber;
            if (animal.GetSueño() <= 150)
                return IAType.Dormir;
            return IAType.Mover;
        }

        //TODO:ESTO LO HE USADO Y FUNCIONA
        public void HacerAccionCercanaAnimal(Animal animal, Mundo mundo)
        {
            IAType accionDecidida = DecideAnimalAccion(animal, mundo);

            if (accionDecidida == IAType.Mover)
                mundo.MoveAnimal(animal);
            else
            {
                Casilla? casillaCercana = EncontrarCasillaTipoCercana(animal, mundo, TerritorioType.HIERBA);
                switch (accionDecidida)
                {
                    case IAType.Comer:
                        if (accionDecidida == IAType.Comer)
                            ComerHierbaCercanaAnimal(animal, mundo);
                        break;
                    case IAType.Beber:
                        if (accionDecidida == IAType.Beber)
                            BeberAguaCercanaAnimal(animal, mundo);
                        break;
                    case IAType.Dormir:
                        if (accionDecidida == IAType.Dormir)
                            DormirAnimal(animal, mundo);
                        break;
                }
            }
        }

        //A PARTIR DE AQUI ES NUEVO
        //TODO: ESTO FUNCIONA Y SE USA
        public static Casilla? EncontrarCasillaTipoCercana(Animal animal, Mundo mundo, TerritorioType type)
        {
            Casilla? casillaTipoObjetivo = null;
            double minDistance = double.MaxValue;
            var _casillasArray = mundo.GetAllCasillas();
            for (int i = 0; i < _casillasArray.Length; i++)
            {
                Casilla casilla = _casillasArray[i];
                if (casilla.Type == type)
                {
                    double distance = Utils.GetDistance(animal.GetCoordenada(), casilla.Coord);
                    if (distance < 2 && distance < minDistance)
                    {
                        minDistance = distance;
                        casillaTipoObjetivo = casilla;
                    }
                }
            }
            return casillaTipoObjetivo;
        }

        //TODO:ESTO LO HE USADO Y FUNCIONA
        public static void ComerHierbaCercanaAnimal(Animal animal, Mundo mundo)
        {
            Casilla? casillaHierba = EncontrarCasillaTipoCercana(animal, mundo, TerritorioType.HIERBA);
            if (casillaHierba != null && DecideAnimalAccion(animal, mundo) == IAType.Comer)
            {
                animal.SetSaciedad(animal.GetSaciedad() + 50);
                casillaHierba.ValorHierba = casillaHierba.ValorHierba - 5;
            }
        }

        //TODO:ESTO LO HE USADO Y FUNCIONA
        public static void BeberAguaCercanaAnimal(Animal animal, Mundo mundo)
        {
            Casilla? casillaAgua = EncontrarCasillaTipoCercana(animal, mundo, TerritorioType.AGUA);
            if (casillaAgua != null && DecideAnimalAccion(animal, mundo) == IAType.Beber)
            {
                animal.SetHidratacion(animal.GetHidratacion() + 50);
            }
        }

        //TODO:ESTO LO HE USADO Y FUNCIONA
        public static void DormirAnimal(Animal animal, Mundo mundo)
        {
            Casilla? casillaDormir = EncontrarCasillaTipoCercana(animal, mundo, TerritorioType.TIERRA);
            if (DecideAnimalAccion(animal, mundo) == IAType.Dormir)
            {
                animal.SetSueño(animal.GetSueño() + 50);
            }
        }
    }
}
