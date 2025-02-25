using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashProject
{
    class Funciones
    {
        public static int GetHash(string s)
        {

            long hash = 5381;
            int c;

            if (s == null)
                return 0;
            while ()

                return hash;
        }

        /*
         public override int GetHashCode()
        {
        return Id * base.GetHashCode()
        }


        Hash => obtener un numero o string pequeño de manera que sea increíblemente difícil de descifrar
de algo puedo calcular el hash, pero del hash no puedo calcular algo para leerlo

Abre con el filereader el archivo para hashear los bytes de los archivos y compararlos, si el tamaño y el hash coincide
entonces son el mismo archivo -> dotar de un mecanismo que permita ahorrar comprobaciones

función le paso un string y me devuelve un entero con el hash de ese string

        clave AES para cifrado -> necesario tener la clave para poder leerlo 
            basado en numeros primos -> genera dos claves: privada y publica
        RSA-4096
         */
        //base64 poder convertir un array de bytes de string a un string con caracteristicas especiales que tienen los caracteres de A-Z, a-z, 0 a 9
    }
}
