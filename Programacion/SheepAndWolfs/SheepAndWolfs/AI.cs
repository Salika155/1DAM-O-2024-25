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
            MoverOvejaArriba,
            MoverOvejaDerecha,
            MoverOvejaAbajo,
            MoverOvejaIzquierda,
            MoverLoboArriba,
            MoverLoboDerecha,
            MoverLoboAbajo,
            MoverLoboIzquierda,
            Comer,
            Beber,
            Dormir

            //posible que si hago mover animal acorte y solo tenga que pasarle el tipo para saber si es un lobo o una oveja
        }

        private IAType[] _iATypes = new IAType[] {IAType.MoverOvejaArriba, IAType.MoverOvejaDerecha, IAType.MoverOvejaAbajo, IAType.MoverOvejaIzquierda,
            IAType.MoverLoboArriba, IAType.MoverLoboDerecha, IAType.MoverLoboAbajo, IAType.MoverLoboIzquierda, IAType.Comer, IAType.Beber, IAType.Dormir};
    }
}
