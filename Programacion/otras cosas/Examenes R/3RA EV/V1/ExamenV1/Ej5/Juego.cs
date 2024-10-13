using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    internal class Juego
    {
        private List<Jugador> jugadores;
        private Casilla[] casillas;



        public Juego(List<Jugador> jugadoresList, Casilla[] casillas)
        {
            casillas = new Casilla[63];
            jugadoresList = new List<Jugador>(4);
        }

        public void AddPlayer(Jugador jugador)
        {
            if (jugador == null)
                return;
            jugadores.Add(jugador);
        }
        
        public void RemovePlayer(List<Jugador> jugadoreslist)
        {
            if (jugadores == null || jugadores.Count != 0)
                return;

            for (int i = 0; i < jugadoreslist.Count; i++)
            {
                jugadoreslist.RemoveAt(i);
            }
        }

        public void CreateTablero(List<Jugador> jugadoresList, Casilla[] casillas)
        {


            Casilla[] ganadora = new CasillaGanadora[63];
            //Casilla[] oca = new CasillaOca[6, 12, 18, 24, 30, 36, 42, 48, 54, 60];
            //Casilla[] puente = new Puente[]();
            Casilla[] castigo = new CasillaCastigo[] { };
            Casilla[] dado = new CasillaDado[] { };
            Casilla[] muerte = new CasillaMuerte[] { };

        }

        

        //creartablero()

        //ordenarjugadores()

        public void Simulate()
        {

        }


    }
}
