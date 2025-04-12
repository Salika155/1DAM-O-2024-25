using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallEx
{
    interface ITorneo
    {
        
//Init() → Es un método que inicia un torneo con 16 participantes.Cada participante
//será de una de las clases que se especifica a continuación de manera random.
//○ Execute() : List<string> → Realiza la serie de combates pertinentes, y devuelve una
//lista con cada combate realizado (y el ganador). Los combates se organizan de esta
//manera:
//Por ejemplo, una posible lista devuelta por esta función puede ser:
//Persona1 vs Persona2 -> Ganador Persona1
//Persona34 vs Persona2 -> Ganador Persona34

        void Init();
        List<string> Execute();

    }
}
