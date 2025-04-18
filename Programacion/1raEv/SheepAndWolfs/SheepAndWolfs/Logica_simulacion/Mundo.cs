﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SheepAndWolfs
{
    public class Mundo
    {
        //TODO: esto funciona
        private Casilla[] _casillas = [];
        private int _width;
        private int _height;
        private List<Animal> _animals;

        //TODO: esto funciona
        public Mundo(int width, int height)
        {
            this._width = width;
            this._height = height;
            this._casillas = new Casilla[width * height];
            this._animals = new List<Animal>();

            CrearCasillas();
        }

        //esto tiene que ir en private, y deberia de crear una copia de cada uno
        //pero como trabajo con la lista directamente en este caso tengo dudas, ya que quiero eliminar
        //los animales muertos de la lista original en el caso de que suceda, no creo que sea necesario
        //hacer una copia.

        //ESTO ESTA MAL ASI -> PROHIBIDO HACER ESTO
        public Casilla[] GetAllCasillas() => _casillas;
        public List<Animal> GetAllAnimals() => _animals;

        //TODO: esto funciona
        public void CrearCasillas()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    int index = Utils.IndexOfCasilla(x, y, _width);
                    _casillas[index] = new Casilla(new Coordenada(x, y))
                    {
                        Type = Utils.GenerateRandomType()
                    };
                }
            }
        }

        //TODO: esto funciona
        public int GetWidth() => _width;

        //TODO: esto funciona
        public int GetHeight() => _height;

        //TODO: esto funciona
        public Casilla? GetCasillaAt(int x, int y)
        {
            if (!Utils.IsValidCoordinates(x, y, _width, _height))
                return null;

            int index = Utils.IndexOfCasilla(x, y, _width);
            return index >= 0 && index < _casillas.Length ? _casillas[index] : null;
        }

        //TODO: esto funciona
        public Animal? GetAnimalAt(int x, int y)
        {
            if (!Utils.IsValidCoordinates(x, y, _width, _height))
                return null;
            for (int i = 0; i < _animals.Count; i++)
            {
                Animal? animal = _animals[i];
                if (animal.GetCoordenada()!.EqualsToCoordenada(x, y))
                    return animal;
            }
            return null;
        }

        //TODO: esto funciona
        public void AddAnimal(Animal animal, int x, int y)
        {
            if (animal == null || Utils.IsValidCoordinates(x, y, _width, _height) is false)
                return;

            animal.SetCoordenada(x, y); // Asignar coordenadas al animal
            _animals.Add(animal);
        }

        //hace falta un removeAnimal para cuando un lobo se coma una oveja o un animal se muera por atributos
        public void RemoveAnimal(Animal animal)
        {
            if (animal == null)
                return;
            _animals.Remove(animal);
        }

        //TODO: esto funciona
        public Animal? RemoveAnimalAt(int index)
        {
            if (index < 0 || index >= _animals.Count)
                return null;
            Animal animal = _animals[index];
            _animals.RemoveAt(index);
            return animal;
        }

        //Experimento  con CreateAnimals ---------------------------------------------------------------------
       //ESTO AQUI NO VA, EL MUNDO TIENE QUE ESTAR LO MAS LIMPIO POSIBLE PARA EVITAR PROBLEMAS
        public void CreateAnimals2(int count, AnimalType type)
        {
            for (int i = 0; i < count; i++)
            {
                int x = Utils.GetRandomNumber(0, _width);
                int y = Utils.GetRandomNumber(0, _height);

                if (GetAnimalAt(x, y) == null) // Evitar duplicados
                {
                    Animal animal;
                    if (type == AnimalType.LOBO)
                        animal = CreateWolf2();
                    else if (type == AnimalType.OVEJA)
                        animal = CreateSheep2();
                    else
                        throw new ArgumentException("No existe eel tipo de animal");
                    animal.SetCoordenada(x, y);
                    AddAnimal(animal, x, y);
                }
            }
        }

        private Lobo CreateWolf2()
        {
            int food = Utils.GetRandomNumber(150, 500);
            int water = Utils.GetRandomNumber(150, 500);
            int stamina = Utils.GetRandomNumber(150, 500);
            int sleep = Utils.GetRandomNumber(150, 500);
            string name = "Lobo " + CountAnimalsType(AnimalType.LOBO);
            int velocidad = 100;

            return new Lobo(food, water, stamina, sleep, AnimalType.LOBO, name, velocidad);
        }

        private Oveja CreateSheep2()
        {
            int food = Utils.GetRandomNumber(150, 500);
            int water = Utils.GetRandomNumber(150, 500);
            int stamina = Utils.GetRandomNumber(150, 500);
            int sleep = Utils.GetRandomNumber(150, 500);
            string name = "Oveja " + CountAnimalsType(AnimalType.OVEJA);
            int velocidad = 50;

            return new Oveja(food, water, stamina, sleep, AnimalType.OVEJA, name, velocidad);
        }

        //TODO:ESTO LO HE USADO Y FUNCIONA
        public void MoveAnimal(Animal? animal)
        {
            if (animal == null)
                return;

            //ESTO FUNCIONA MAL, SE MUEVE 4 VECES CADA TURNO POR CADA MOVIMIENTO
            int[] XMovs = [-1, 0, 1, 0];
            int[] YMovs = [0, -1, 0, 1];

            for (int i = 0; i < 4; i++)
            {
                int direction = Utils.GetRandomNumber(0, 4);
                int newX = animal.GetCoordenada()!.X + XMovs[direction];
                int newY = animal.GetCoordenada()!.Y + YMovs[direction];

                if (Utils.IsValidCoordinates(newX, newY, GetWidth(), GetHeight()))
                {
                    Animal? targetAnimal = GetAnimalAt(newX, newY);
                    Casilla? targetCasilla = GetCasillaAt(newX, newY);

                    //FALTA SI OVEJA COME LOBO QUE HACER, PORQUE COMO NO HACE NADA SE SALE POR EL RETURN
                    if (targetAnimal != null)
                    {
                        ComerOvejaSiendoLobo(animal, targetAnimal);
                        return;
                    }
                    if (targetAnimal == null)
                    {
                        if (CanAnimalMoveTo(animal, new Coordenada(newX, newY)))
                        {
                            animal.SetCoordenada(newX, newY);
                            return;
                        }
                    }
                }
            }
        }

        #region comentarios viejos
        //CanAnimalMove? -> esto esta mal por el animaltype animal
        //AQUI ME FALTA COMPROBAR QUE LA CASILLA A LA QUE ME QUIERO MOVER TENGA UN ANIMAL, SI ES DEL MISMO TIPO NO MOVERME
        //SI SOY UN LOBO SI ME MUEVO A LA DE LA OVEJA, SI SOY UNA OVEJA NO ME MUEVO HACIA LA DEL LOBO.
        #endregion

        //TODO:ESTO LO HE USADO Y FUNCIONA
        public bool CanAnimalMoveTo(Animal? animal, Coordenada coor)
        {
            if (animal == null || coor == null)
                return false;

            Casilla? targetCasilla = GetCasillaAt(coor.X, coor.Y);
            Animal? targetAnimal = GetAnimalAt(coor.X, coor.Y);

            if (targetCasilla == null || targetCasilla.Type == TerritorioType.ROCA ||
                targetCasilla.Type == TerritorioType.AGUA)
                return false;
            if (targetAnimal != null)
            {
                if (animal.GetType() == targetAnimal.GetType())
                    return false;
                else if (animal is Lobo && targetAnimal is Oveja)
                    return true;
                else if (animal is Oveja && targetAnimal is Lobo)
                    return false;
            }
            return true;
        }

        //TODO:ESTO LO HE USADO Y FUNCIONA
        public void ComerOvejaSiendoLobo(Animal animal, Animal targetAnimal)
        {
            if (animal is Lobo && targetAnimal is Oveja)
            {
                Coordenada posicionOveja = targetAnimal.GetCoordenada()!;
                RemoveAnimal(targetAnimal); // Elimina la oveja
                animal.SetCoordenada(posicionOveja.X, posicionOveja.Y);
                animal.SetSaciedad(animal.GetSaciedad() + 100); // Aumenta la saciedad
                Console.WriteLine($"El lobo {animal.GetNombre()} se comió a la oveja {targetAnimal.GetNombre()} en la posición {targetAnimal.GetCoordenada()}.");
            }
            else if (animal is Oveja && targetAnimal is Lobo)
            {
                Console.WriteLine($"La oveja {animal.GetNombre()} evita al lobo {targetAnimal.GetNombre()} en la posición {targetAnimal.GetCoordenada()}.");
            }
        }

        //TODO: esto lo he usado
        public int CountAnimals() => _animals.Count;

        //TODO: esto lo he usado
        public int CountAnimalsType(AnimalType type)
        {
            if (_animals.Count == 0)
                return 0;

            int aux = 0;
            for (int i = 0; i < _animals.Count; i++)
                if (_animals[i].GetType() == type)
                    aux += 1;
            return aux;
        }

        //TODO:ESTO LO HE USADO Y FUNCIONA
        //Para actualizar los atributos a cada turno que pasa a los animales
        public void ActualizarEstadoAnimalesPorTurno()
        {
            foreach (var animales in _animals)
            {
                animales.SetSaciedad(animales.GetSaciedad() - 10);
                animales.SetHidratacion(animales.GetHidratacion() - 10);
                animales.SetSueño(animales.GetSueño() - 10);

                if (animales.GetSaciedad() <= 0)
                    animales.SetSaciedad(0);
                if (animales.GetHidratacion() <= 0)
                    animales.SetHidratacion(0);
                if (animales.GetSueño() <= 0)
                    animales.SetSueño(0);
            }
        }

        //TODO:ESTO LO HE USADO Y FUNCIONA
        public void EliminarAnimalesmuertos()
        {
            for (int i = _animals.Count - 1; i >= 0; i--)
            {
                Animal animal = _animals[i];
                if (animal.GetSaciedad() <= 0 || animal.GetHidratacion() <= 0 || animal.GetSueño() <= 0)
                    RemoveAnimalAt(i);
            }
        }

        //TODO:ESTO LO HE USADO Y FUNCIONA
        public bool EstaCercaHierba(Animal animal)
        {
            foreach (var casilla in _casillas)
            {
                if (casilla.Type == TerritorioType.HIERBA)
                {
                    if (Utils.IsValidCoordinates(casilla.Coord.X, casilla.Coord.Y, GetWidth(), GetHeight()))
                    {
                        if (Utils.GetDistance(animal.GetCoordenada(), casilla.Coord) <= 2)
                            return true;
                    }
                }
            }
            return false;
        }

        //TODO:ESTO LO HE USADO Y FUNCIONA
        public bool EstaAguaCercaDelAnimal(Animal animal)
        {
            foreach (var casilla in _casillas)
            {
                if (casilla.Type == TerritorioType.AGUA)
                {
                    if (Utils.IsValidCoordinates(casilla.Coord.X, casilla.Coord.Y, GetWidth(), GetHeight()))
                    {
                        if (Utils.GetDistance(animal.GetCoordenada(), casilla.Coord) <= 2)
                            return true;
                    }
                }
            }
            return false;
        }

        //----------------------------------------------------------------------------------
        #region codigoantiguo
        //TODO: esto no lo he usado
        //ES POSIBLE QUE ME HAGA FALTA PARA COMPROBAR EL ANIMAL EN LA CASILLA Y QUE LOS LOBOS ATAQUEN
        //public AnimalType GetAnimalTypeAt(int x, int y, AnimalType type)
        //{
        //    Animal? animal = GetAnimalAt(x, y);
        //    return animal?.GetType() ?? AnimalType.ANIMAL;
        //}

        ////TODO: esto no lo he usado
        //public int IndexOfAnimal(Animal animal)
        //{
        //    for (int i = 0; i < _animals.Count; i++)
        //    {
        //        if (_animals[i].GetType() == animal.GetType() 
        //            && _animals[i].GetCoordenada() == animal.GetCoordenada())
        //            return i;
        //    }
        //    return -1;
        //}

        ////TODO: esto no lo he usado
        //public bool ContainsCasilla(int x, int y)
        //{
        //    return Utils.IndexOfCasilla(x, y, _width) != -1;
        //}

        ////TODO: esto no lo he usado
        //public int CountCasilla() => _casillas.Length;

        ////Comprobar casilla este ocupada
        ////TODO: esto no lo he usado
        //public bool IsCasillaOcupada(int x, int y)
        //{
        //    return (GetAnimalAt(x, y) != null || GetAnimalAt(x, y) != null) ? false : true;
        //}

        //Aqui creo que se puede hacer un createAnimals que cree los animales y los añada a la lista de animales
        //TODO: esto funciona
        //public void CreateAnimals(int count, AnimalType type)
        //{
        //    for (int i = 0; i < count; i++)
        //    {
        //        int x = Utils.GetRandomNumber(0, _width);
        //        int y = Utils.GetRandomNumber(0, _height);

        //        if (GetAnimalAt(x, y) == null)
        //        {
        //            if (type == AnimalType.LOBO)
        //            {
        //                int countlobo = 0;
        //                int food = Utils.GetRandomNumber(50, 500);
        //                int water = Utils.GetRandomNumber(50, 500);
        //                int stamina = Utils.GetRandomNumber(50, 500);
        //                int sleep = Utils.GetRandomNumber(50, 500);
        //                string name = "Lobo " + countlobo++;
        //                int velocidad = 100;
        //                Lobo lobo = new Lobo(food, water, stamina, sleep, AnimalType.LOBO, name, velocidad);
        //                lobo.SetCoordenada(x, y);
        //                AddAnimal(lobo, x, y);
        //            }
        //            else if (type == AnimalType.OVEJA)
        //            {
        //                int countoveja = 0;
        //                int food = Utils.GetRandomNumber(50, 500);
        //                int water = Utils.GetRandomNumber(50, 500);
        //                int stamina = Utils.GetRandomNumber(50, 500);
        //                int sleep = Utils.GetRandomNumber(50, 500);
        //                string name = "Oveja " + countoveja++;
        //                int velocidad = 50;
        //                Oveja oveja = new Oveja(food, water, stamina, sleep, AnimalType.OVEJA, name, velocidad);
        //                oveja.SetCoordenada(x, y);
        //                AddAnimal(oveja, x, y);
        //            }
        //        }
        //    }
        //}

        //TODO: esto funciona
        //public void CreateWolfs(int count)
        //{
        //    int countlobo = count;

        //    for (int i = 0; i <= countlobo; i++)
        //    {
        //        int x = Utils.GetRandomNumber(0, _width);
        //        int y = Utils.GetRandomNumber(0, _height);

        //        if (GetAnimalAt(x, y) == null)  // Evitar duplicados -> aqui hay que comprobar si la casilla a la que se mueve es roca o agua
        //        {
        //            Lobo lobo = new Lobo(100, 100, 100, 100, AnimalType.LOBO, "lobo" + CountAnimalsType(AnimalType.LOBO), 100);
        //            lobo.SetCoordenada(x, y);
        //            AddAnimal(lobo, x, y);
        //        }
        //    }
        //}

        //TODO: esto funciona
        //public void CreateSheeps(int count)
        //{
        //    int countoveja = count;
        //    for (int i = 0; i <= countoveja; i++)
        //    {
        //        int x = Utils.GetRandomNumber(0, _width);
        //        int y = Utils.GetRandomNumber(0, _height);

        //        if (GetAnimalAt(x, y) == null) // Evitar duplicados
        //        {
        //            Oveja oveja = new Oveja(100, 100, 100, 100, AnimalType.OVEJA, "oveja " + CountAnimalsType(AnimalType.OVEJA), 50);
        //            oveja.SetCoordenada(x, y);
        //            AddAnimal(oveja, x, y);
        //        }
        //    }
        //}

        //copia del viejo moveanimals
        //public void MoveAnimal2(Animal? animal)
        //{
        //    if (animal == null)
        //        return;

        //    int[] XMovs = [-1, 0, 1, 0];
        //    int[] YMovs = [0, -1, 0, 1];

        //    int direction = Utils.GetRandomNumber(0, 4);

        //    int newX = animal.GetCoordenada()!.X + XMovs[direction];
        //    int newY = animal.GetCoordenada()!.Y + YMovs[direction];

        //    if (Utils.IsValidCoordinates(newX, newY, GetWidth(), GetHeight()) &&
        //        CanAnimalMoveTo(animal, new Coordenada(newX, newY)))
        //    {
        //        animal.SetCoordenada(newX, newY);
        //    }
        //}

        //viejo cananimalmoveto
        //public bool CanAnimalMoveTo2(Animal? animal, Coordenada coor)
        //{
        //    if (animal == null || coor == null)
        //        return false;

        //    Casilla? targetCasilla = GetCasillaAt(coor.X, coor.Y);
        //    Animal? targetAnimal = GetAnimalAt(coor.X, coor.Y);

        //    if (targetCasilla == null || targetCasilla.type == TerritorioType.ROCA ||
        //        targetCasilla.type == TerritorioType.AGUA)
        //        return false;
        //    if (targetAnimal != null)
        //    {
        //        if (animal.GetType() == targetAnimal.GetType())
        //            return false;
        //        else if (animal is Lobo && targetAnimal is Oveja)
        //            return true;
        //        else if (animal is Oveja && targetAnimal is Lobo)
        //            return false;
        //    }
        //    return true;
        //}
        #endregion
    }
}
