using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace ExListaEV2Ex1BienHecho
{
    class Texto
    {
    //Implementa una clase que sea una lista hecha con genéricos.
    //● La clase se llamará ExList
    //● (A) La lista se implementará usando un array. 

    //El número de elementos que tiene el array no tiene por qué coincidir con el
    // número de elementos de la lista.
    //● Las properties que hay que implementar son: 
    //	○ (A) Count → Devuelve el número de elementos que hay en la lista. 
    //	○ (A) Capacity → Devuelve la capacidad interna de la lista.
    //	○ (A) First → Devuelve el primer elemento de la lista, si no se
    //    puede, hay que lanzar una excepción.
    //	○ (A) Last → Devuelve el último elemento de la lista, si no se
    //    puede, hay que lanzar una excepción.
    //	○ (D) Reversed → Devuelve una copia de la lista pero con los
    //    elementos en el orden inverso.
    //● Los métodos a implementar son: 
    //	○ (A) GetElementAt(index) → Devuelve el elemento que está en la
    //    posición “index”. En caso de que no se pueda, se debe devolver un
    //    valor por defecto.
    //	○ (A) SetElementAt(index, element) → Pone (remplaza) el elemento
    //    en la posición “index”. 
    //	○ (A) Add(element) → Añade un elemento al final de la lista. 
    //	○ (B) RemoveAt(index) → Quita de la lista el elemento que está
    //    en la posición “index”. Esta función no crea un array nuevo.
    //	○ (A) Clear() → Quita todos los elementos de la lista.
    //    Esta función no crea un array nuevo.
    //	○ (A) Insert(index, element) → Inserta el nuevo elemento en
    //    la posición especificada. Por ejemplo, si inserto “hola” en la
    //    posición 2, y luego llamo a GetElementAt(2) me devolverá hola.
    //    Esta función hará que la lista tenga un elemento más.
    //	○ (C) IndexOf(element) → Devuelve la posición en la que se
    //    encuentra un elemento. 
    //	○ (C) Contains(element) → Dice si un elemento está en la lista. 
    //	○ (C) IndexOf(delegate) → Devuelve la posición en la que se
    //    encuentra un elemento.
    //	○ (C) Contains(delegate) → Dice si un elemento está en la lista.
    //	○ (C) Visit(delegate) → Pasa por todos los elementos de la
    //    lista invocando a una lambda que se le pasa como parámetro con
    //    cada elemento recorrido.
    //	○ (D) Sort(delegate) → Ordena la lista con el criterio de un
    //    delegado que se le tiene que pasar como parámetro.
    //	○ (B) Filter(delegate) → Devuelve una ExList con los elementos
    //    que superen el filtro que es un delegado.
    //	○ (D) Reverse() → Le da la vuelta a la lista.
    //	○ (D) Clone() → Devuelve una copia de la lista. 
    //	○ (A) ToArray() → Devuelve un array (una copia, no el array
    //    interno) con todos los elementos de la lista y sólo con los
    //    elementos de la lista.
    }
}
