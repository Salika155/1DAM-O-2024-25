using ChessLib;
using ChessLib.Figuras;
using System;
using System.Drawing;
using static ChessLib.Tablero.IChessBoard;

namespace ChessLib.Tablero
{
    
    public class ChessBoard : IChessBoard
    {
        private readonly Casilla[ , ] _casillas;
        private readonly Figure[] _figures;
        private readonly int _width;
        private readonly int _height;
        private int _figureCount = 0;
        public int Width => _width;
        public int Height => _height;

        private readonly List<IFigure> _capturedWhiteFigures = new();
        private readonly List<IFigure> _capturedBlackFigures = new();
        public ChessBoard(int width, int height)
        {
            _width = width;
            _height = height;
            _casillas = new Casilla[width, height];
            _figures = new Figure[32];
            _figureCount = 0;
            InitializeBoard();
            //metodo para iniciar fichas
        }

        //posiblemente lo borre
        public ChessBoard() : this (8, 8){}

        public void InitializeBoard()
        {
            //DrawBoard();
            CrearCasillas();
            CreateFigures();
            Execute();
        }

        public void ExecuteTurns()
        {
            //while (true)
            //{
            //    //que compruebe que se puede seguir jugando
            //    //que compruebe que no hay ningun jugador con 0 fichas
            //    //que compruebe el turno del jugador que le toca
            //    //que compruebe si puede mover la ficha
            //    //si puede, que la mueva.
            //}
            FigureColor turnoActual = FigureColor.WHITE;
            //posiblemente necesite aqui elegir el turno, aunque no me ha hecho falta para cambiarlo varias veces
            while (true)
            {
                Console.Clear();
                Utils.DrawBoard(this);

                // 🔽 Añade esta parte justo después de dibujar el tablero
                Console.WriteLine("\nPiezas blancas capturadas:");
                VisitCapturedFigures(FigureColor.WHITE, f =>
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(Utils.GetSymbol(f));
                    Console.ResetColor();
                });

                Console.WriteLine("\nPiezas negras capturadas:");
                VisitCapturedFigures(FigureColor.BLACK, f =>
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(Utils.GetSymbol(f));
                    Console.ResetColor();
                });

                Console.WriteLine();
                Console.WriteLine($"Turno de las piezas: {turnoActual}");

                // 1. Pedir ORIGEN
                Console.Write("\nIntroduce coordenadas de la pieza (ej. a2): ");
                string inputOrigen = Console.ReadLine().ToLower().Trim();

                if (inputOrigen.Length != 2)
                {
                    Console.WriteLine("¡Formato incorrecto! Debe ser letra+número (ej. a2)");
                    Console.ReadKey();
                    continue;
                }

                // Convertir ORIGEN y validar pieza
                Coord origen = new Coord(inputOrigen[0] - 'a', inputOrigen[1] - '0');
                IFigure figura = GetFigureAt(origen.X, origen.Y);
                if (figura == null || figura.GetColor() != turnoActual)
                {
                    Console.WriteLine("¡No hay pieza o no es tu turno!");
                    Console.ReadKey();
                    continue;
                }

                //AQUI EN MEDIO METER LA SELECCION
                // Obtener movimientos válidos y mostrarlos
                var movimientosValidos = figura.GetAllAvailablePosition(this);
                Utils.DrawBoardWithHighlight(this, origen, movimientosValidos); // Nueva función

                // 2. Pedir DESTINO
                Console.Write("Introduce coordenadas de destino (ej. a4): ");
                string inputDestino = Console.ReadLine().ToLower().Trim();

                if (inputDestino.Length != 2)
                {
                    Console.WriteLine("¡Formato incorrecto! Debe ser letra+número (ej. a4)");
                    Console.ReadKey();
                    continue;
                }

                // Convertir DESTINO (sin restar '1' o '0')
                Coord destino = new Coord(inputDestino[0] - 'a', inputDestino[1] - '0');

                // Mover pieza
                if (MoveFigure(origen.X, origen.Y, destino.X, destino.Y))
                {
                    turnoActual = (turnoActual == FigureColor.WHITE) ? FigureColor.BLACK : FigureColor.WHITE;
                }
                else
                {
                    Console.WriteLine("¡Movimiento no válido! Presiona cualquier tecla...");
                    Console.ReadKey();
                }
            }

        }
        

        public void CrearCasillas()
        {
            for (int y = 0; y < _height; y++)  // Ahora empieza desde arriba (y=7)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (Utils.IsValidCoordinates(x, y, _width, _height))
                    {
                        var color = (x + y) % 2 == 0 ? CasillaColor.WHITE : CasillaColor.RED;
                        _casillas[x, y] = new Casilla(new Coord(x, y), color);
                    }

                }
            }
        }

        //public void CrearCasillas()
        //{
        //    for (int y = _height - 1; y >= 0; y--)  // Ahora empieza desde arriba (y=7)
        //    {
        //        for (int x = 0; x < _width; x++)
        //        {
        //            var color = (x + y) % 2 == 0 ? CasillaColor.WHITE : CasillaColor.RED;
        //            _casillas[x, y] = new Casilla(new Coord(x, y), color);
        //        }
        //    }
        //}

        #region comentado
        //public void Execute()
        //{
        //    bool juegoEnCurso = true;
        //    FigureColor turnoActual = FigureColor.WHITE;

        //    while (juegoEnCurso)
        //    {
        //        Console.Clear();
        //        Utils.DrawBoard(this);

        //        Console.WriteLine($"Turno de las {turnoActual}");
        //        Console.Write("Introduce el movimiento (ej: e2 e4): ");
        //        string? input = Console.ReadLine();

        //        if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "salir")
        //            break;

        //        if (input.Length != 5 || input[2] != ' ')
        //        {
        //            Console.WriteLine("Formato inválido. Usa el formato 'e2 e4'.");
        //            continue;
        //        }

        //        string origenTexto = input.Substring(0, 2);
        //        string destinoTexto = input.Substring(3, 2);

        //        Coord origen, destino;
        //        try
        //        {
        //            origen = Utils.ParsearCoordenada(origenTexto);
        //            destino = Utils.ParsearCoordenada(destinoTexto);
        //        }
        //        catch
        //        {
        //            Console.WriteLine("Coordenadas inválidas.");
        //            continue;
        //        }

        //        IFigure? figura = GetFigureAt(origen.X, origen.Y);
        //        if (figura == null)
        //        {
        //            Console.WriteLine("No hay ninguna figura en esa posición.");
        //            continue;
        //        }

        //        if (figura.GetColor() != turnoActual)
        //        {
        //            Console.WriteLine("No puedes mover las piezas del oponente.");
        //            continue;
        //        }

        //        var movimientosValidos = figura.GetAvailablePosition(this);

        //        bool esMovimientoValido = false;
        //        foreach (var mv in movimientosValidos)
        //        {
        //            if (mv.X == destino.X && mv.Y == destino.Y)
        //            {
        //                esMovimientoValido = true;
        //                break;
        //            }
        //        }

        //        if (!esMovimientoValido)
        //        {
        //            Console.WriteLine("Movimiento inválido.");
        //            continue;
        //        }

        //        MoveFigure(origen.X, origen.Y, destino.X, destino.Y, _figureCount);

        //        turnoActual = (turnoActual == FigureColor.WHITE) ? FigureColor.BLACK : FigureColor.WHITE;
        //    }
        //}
        #endregion

        // Método Execute simplificado y funcional
        public void Execute()
        {
            while(true)
            {
                ExecuteTurns();
            }

            #region comentado
            //FigureColor turnoActual = FigureColor.WHITE;

            //while (true)
            //{
            //    Console.Clear();
            //    Utils.DrawBoard(this);
            //    Console.WriteLine($"Turno de las piezas: {turnoActual}");

            //    // 1. Pedir ORIGEN
            //    Console.Write("\nIntroduce coordenadas de la pieza (ej. a2): ");
            //    string inputOrigen = Console.ReadLine().ToLower().Trim();

            //    if (inputOrigen.Length != 2)
            //    {
            //        Console.WriteLine("¡Formato incorrecto! Debe ser letra+número (ej. a2)");
            //        Console.ReadKey();
            //        continue;
            //    }

            //    // 2. Pedir DESTINO
            //    Console.Write("Introduce coordenadas de destino (ej. a4): ");
            //    string inputDestino = Console.ReadLine().ToLower().Trim();

            //    if (inputDestino.Length != 2)
            //    {
            //        Console.WriteLine("¡Formato incorrecto! Debe ser letra+número (ej. a4)");
            //        Console.ReadKey();
            //        continue;
            //    }

            //    try
            //    {
            //        // Convertir coordenadas
            //        Coord origen = new Coord(inputOrigen[0] - 'a', inputOrigen[1] - '1');
            //        Coord destino = new Coord(inputDestino[0] - 'a', inputDestino[1] - '1');

            //        // Mover pieza
            //        if (MoveFigure(origen.X, origen.Y, destino.X, destino.Y, _figureCount))
            //        {
            //            turnoActual = (turnoActual == FigureColor.WHITE) ? FigureColor.BLACK : FigureColor.WHITE;
            //        }
            //        else
            //        {
            //            Console.WriteLine("¡Movimiento no válido! Presiona cualquier tecla...");
            //            Console.ReadKey();
            //        }
            //    }
            //    catch
            //    {
            //        Console.WriteLine("¡Coordenadas inválidas! Usa rango a1-h8");
            //        Console.ReadKey();
            //    }
            //}
            #endregion
        }

        //crear un metodo que le paso el color de la figura y la i, asi no tengo que hacer duplicacion de codigo.
        //public void CreateFiguresWithColor(FigureColor color)
        //{
        //    if (color == FigureColor.BLACK)
        //    {
        //        // Colocar las piezas negras
        //        CreateFigure(FigureType.TOWER, FigureColor.BLACK, new Coord(0, 7));
        //        CreateFigure(FigureType.KNIGHT, FigureColor.BLACK, new Coord(1, 7));
        //        CreateFigure(FigureType.BISHOP, FigureColor.BLACK, new Coord(2, 7));
        //        CreateFigure(FigureType.QUEEN, FigureColor.BLACK, new Coord(3, 7));
        //        CreateFigure(FigureType.KING, FigureColor.BLACK, new Coord(4, 7));
        //        CreateFigure(FigureType.BISHOP, FigureColor.BLACK, new Coord(5, 7));
        //        CreateFigure(FigureType.KNIGHT, FigureColor.BLACK, new Coord(6, 7));
        //        CreateFigure(FigureType.TOWER, FigureColor.BLACK, new Coord(7, 7));

        //        for (int x = 0; x < 8; x++)
        //        {
        //            CreateFigure(FigureType.PAWN, FigureColor.BLACK, new Coord(x, 6));
        //        }
        //    }
        //    else if (color == FigureColor.WHITE)
        //    {
        //        CreateFigure(FigureType.TOWER, FigureColor.WHITE, new Coord(0, 0));
        //        CreateFigure(FigureType.KNIGHT, FigureColor.WHITE, new Coord(1, 0));
        //        CreateFigure(FigureType.BISHOP, FigureColor.WHITE, new Coord(2, 0));
        //        CreateFigure(FigureType.QUEEN, FigureColor.WHITE, new Coord(3, 0));
        //        CreateFigure(FigureType.KING, FigureColor.WHITE, new Coord(4, 0));
        //        CreateFigure(FigureType.BISHOP, FigureColor.WHITE, new Coord(5, 0));
        //        CreateFigure(FigureType.KNIGHT, FigureColor.WHITE, new Coord(6, 0));
        //        CreateFigure(FigureType.TOWER, FigureColor.WHITE, new Coord(7, 0));

        //        for (int x = 0; x < 8; x++)
        //        {
        //            CreateFigure(FigureType.PAWN, FigureColor.WHITE, new Coord(x, 1));
        //        }
        //    }
        //}

        public void CreateFiguresWithColor(FigureColor color)
        {
            if (color == FigureColor.BLACK)
            {
                // Piezas NEGRAS en la parte SUPERIOR (y=0 y y=1)
                CreateFigure(FigureType.TOWER, FigureColor.BLACK, new Coord(0, 0)); // a8
                CreateFigure(FigureType.KNIGHT, FigureColor.BLACK, new Coord(1, 0)); // b8
                CreateFigure(FigureType.BISHOP, FigureColor.BLACK, new Coord(2, 0)); // c8
                CreateFigure(FigureType.QUEEN, FigureColor.BLACK, new Coord(3, 0)); // d8
                CreateFigure(FigureType.KING, FigureColor.BLACK, new Coord(4, 0)); // e8
                CreateFigure(FigureType.BISHOP, FigureColor.BLACK, new Coord(5, 0)); // f8
                CreateFigure(FigureType.KNIGHT, FigureColor.BLACK, new Coord(6, 0)); // g8
                CreateFigure(FigureType.TOWER, FigureColor.BLACK, new Coord(7, 0)); // h8

                for (int x = 0; x < 8; x++)
                {
                    CreateFigure(FigureType.PAWN, FigureColor.BLACK, new Coord(x, 1)); // a7-h7
                }
            }
            else if (color == FigureColor.WHITE)
            {
                // Piezas BLANCAS en la parte INFERIOR (y=6 y y=7)
                CreateFigure(FigureType.TOWER, FigureColor.WHITE, new Coord(0, 7)); // a1
                CreateFigure(FigureType.KNIGHT, FigureColor.WHITE, new Coord(1, 7)); // b1
                CreateFigure(FigureType.BISHOP, FigureColor.WHITE, new Coord(2, 7)); // c1
                CreateFigure(FigureType.QUEEN, FigureColor.WHITE, new Coord(3, 7)); // d1
                CreateFigure(FigureType.KING, FigureColor.WHITE, new Coord(4, 7)); // e1
                CreateFigure(FigureType.BISHOP, FigureColor.WHITE, new Coord(5, 7)); // f1
                CreateFigure(FigureType.KNIGHT, FigureColor.WHITE, new Coord(6, 7)); // g1
                CreateFigure(FigureType.TOWER, FigureColor.WHITE, new Coord(7, 7)); // h1

                for (int x = 0; x < 8; x++)
                {
                    CreateFigure(FigureType.PAWN, FigureColor.WHITE, new Coord(x, 6)); // a2-h2
                }
            }
        }
        public void CreateFigures()
        {
            CreateFiguresWithColor(FigureColor.BLACK);
            CreateFiguresWithColor(FigureColor.WHITE);
            #region comentado
            //for (int x = 0; x < 8; x++)
            //{
            // Colocar las piezas blancas

            //    CreateFigure(FigureType.TOWER, FigureColor.WHITE, new Coord(0, 0));
            //    CreateFigure(FigureType.KNIGHT, FigureColor.WHITE, new Coord(1, 0));
            //    CreateFigure(FigureType.BISHOP, FigureColor.WHITE, new Coord(2, 0));
            //    CreateFigure(FigureType.QUEEN, FigureColor.WHITE, new Coord(3, 0));
            //    CreateFigure(FigureType.KING, FigureColor.WHITE, new Coord(4, 0));
            //    CreateFigure(FigureType.BISHOP, FigureColor.WHITE, new Coord(5, 0));
            //    CreateFigure(FigureType.KNIGHT, FigureColor.WHITE, new Coord(6, 0));
            //    CreateFigure(FigureType.TOWER, FigureColor.WHITE, new Coord(7, 0));
            ////}

            //for (int x = 0; x < 8; x++)
            //{
            //    CreateFigure(FigureType.PAWN, FigureColor.WHITE, new Coord(x, 1));
            //}

            //// Colocar las piezas negras
            //CreateFigure(FigureType.TOWER, FigureColor.BLACK, new Coord(0, 7));
            //CreateFigure(FigureType.KNIGHT, FigureColor.BLACK, new Coord(1, 7));
            //CreateFigure(FigureType.BISHOP, FigureColor.BLACK, new Coord(2, 7));
            //CreateFigure(FigureType.QUEEN, FigureColor.BLACK, new Coord(3, 7));
            //CreateFigure(FigureType.KING, FigureColor.BLACK, new Coord(4, 7));
            //CreateFigure(FigureType.BISHOP, FigureColor.BLACK, new Coord(5, 7));
            //CreateFigure(FigureType.KNIGHT, FigureColor.BLACK, new Coord(6, 7));
            //CreateFigure(FigureType.TOWER, FigureColor.BLACK, new Coord(7, 7));

            //for (int x = 0; x < 8; x++)
            //{
            //    CreateFigure(FigureType.PAWN, FigureColor.BLACK, new Coord(x, 6));
            //}
            #endregion
        }

        public void CreateFigure(FigureType type, FigureColor color, Coord coord)
        {
            Console.WriteLine($"Añadiendo figura {type} en ({coord.X}, {coord.Y}). Contador: {_figureCount}");

            Figure figura;
                switch (type)
            {
                case FigureType.TOWER:
                    figura = new Tower(color, type, coord);
                    break;
                case FigureType.KNIGHT:
                    figura = new Knight(color, type, coord);
                    break;
                case FigureType.BISHOP:
                    figura = new Bishop(color, type, coord);
                    break;
                case FigureType.QUEEN:
                    figura = new Queen(color, type, coord);
                    break;
                case FigureType.KING:
                    figura = new King(color, type, coord);
                    break;
                case FigureType.PAWN:
                    figura = new Pawn(color, type, coord);
                    break;
                default:
                    throw new ArgumentException("Tipo de figura inválido");
            }

            if (_figureCount >= _figures.Length)
                throw new InvalidOperationException("No se pueden añadir más figuras");

            _figures[_figureCount] = figura;
            _casillas[coord.X, coord.Y].Figure = figura;
            _figureCount++;
        }

        #region comentado
        //NO ME FIO
        //public bool MoveFigure(int origenX, int origenY, int destinoX, int destinoY, int figureCount)
        //{
        //    // Verificar si las coordenadas están dentro del tablero
        //    if (!Utils.IsValidCoordinates(destinoX, destinoY, Width, Height))
        //        return false;

        //        // Obtener la figura en la posición actual
        //        var figure = _casillas[origenX, origenY].Figure;

        //    // Verificar si hay una figura en la posición actual
        //    if (figure == null)
        //        return false;

        //    // Obtener las posiciones disponibles para la figura
        //    var availablePositions = figure.GetAvailablePosition(this);

        //    // Verificar si la nueva posición está en las posiciones disponibles
        //    foreach (var pos in availablePositions)
        //    {
        //        if (pos.X == origenX && pos.Y == origenY)
        //        {
        //            // Mover la figura a la nueva posición
        //            _casillas[origenX, origenY].Figure = figure;
        //            _figureCount++;
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        #endregion

        //ME FALLAN LOS MOVIMIENTOS DE LAS FIGURAS

        public bool MoveFigure(int origenX, int origenY, int destinoX, int destinoY)
        {
            // 1. Validar que las coordenadas están dentro del tablero
            if (!Utils.IsValidCoordinates(origenX, origenY, Width, Height) ||
                !Utils.IsValidCoordinates(destinoX, destinoY, Width, Height))
                return false;

            // 2. Obtener la figura que se quiere mover
            IFigure? figura = _casillas[origenX, origenY].Figure;
            if (figura == null)
                return false;

            // 3. Obtener los movimientos válidos para la figura y verificar si el destino está permitido
            var movimientosValidos = figura.GetAllAvailablePosition(this);
            bool esMovimientoValido = movimientosValidos.Any(m => m.X == destinoX && m.Y == destinoY);
            if (!esMovimientoValido)
                return false;

            // 4. Gestionar captura si hay una figura enemiga en la casilla de destino
            IFigure? figuraEnDestino = _casillas[destinoX, destinoY].Figure;
            if (figuraEnDestino != null && figuraEnDestino.GetColor() != figura.GetColor())
            {
                if (figuraEnDestino.GetColor() == FigureColor.WHITE)
                    _capturedWhiteFigures.Add(figuraEnDestino);
                else
                    _capturedBlackFigures.Add(figuraEnDestino);
            }

            // 5. Realizar el movimiento: mover figura y vaciar la casilla de origen
            _casillas[destinoX, destinoY].Figure = figura;
            _casillas[origenX, origenY].Figure = null;

            // 6. Actualizar coordenadas internas de la figura
            figura.SetCoord(new Coord(destinoX, destinoY));

            // 7. Incrementar el contador de movimientos (relevante para peones, enroques, etc.)
            figura.IncrementCount();

            // 8. Redibujar visualmente las casillas afectadas
            Utils.RedibujarCasilla(this, origenX, origenY);
            Utils.RedibujarCasilla(this, destinoX, destinoY);

            // 9. Confirmar éxito
            Console.WriteLine($"Moviendo de ({origenX},{origenY}) a ({destinoX},{destinoY})");
            return true;
        }

        //public bool MoveFigure(int origenX, int origenY, int destinoX, int destinoY)
        //{
        //    // 1. Validar coordenadas
        //    if (!Utils.IsValidCoordinates(origenX, origenY, Width, Height) ||
        //        !Utils.IsValidCoordinates(destinoX, destinoY, Width, Height))
        //        return false;

        //    // 2. Obtener figura en origen
        //    IFigure? figura = _casillas[origenX, origenY].Figure;
        //    if (figura == null)
        //        return false;

        //    // 3. Verificar movimientos válidos
        //    var movimientosValidos = figura.GetAllAvailablePosition(this);
        //    bool esMovimientoValido = false;
        //    foreach (var movimiento in movimientosValidos)
        //    {
        //        if (movimiento.X == destinoX && movimiento.Y == destinoY)
        //        {
        //            esMovimientoValido = true;
        //            break;
        //        }
        //    }

        //    if (!esMovimientoValido)
        //        return false;


        //    // Mover la figura SIN modificar colores
        //    _casillas[destinoX, destinoY].Figure = figura;  // Pieza a nueva posición
        //    _casillas[origenX, origenY].Figure = null; // Limpiar posición original

        //    // 5. Actualizar la coordenada de la figura

        //    //figura.SetCoord(new Coord(destinoX, destinoY));
        //    //var cooordfig = figura.GetCoord();
        //    figura.SetCoord(new Coord(destinoX, destinoY));

        //    // Redibujar la casilla de origen
        //    //DibujarCasillas(obtenerCasilla(origen));

        //    // Redibujar la casilla de destino
        //    //DibujarCasilla(obtenerCasilla(destino));

        //    // 7. Actualizar contador de movimientos (si es necesario)

        //    figura.IncrementCount();
        //    Utils.RedibujarCasilla(this, origenX, origenY);
        //    Utils.RedibujarCasilla(this, destinoX, destinoY);
        //    Console.WriteLine($"Moviendo de ({origenX},{origenY}) a ({destinoX},{destinoY})");
        //    return true;
        //}

        //private void RedibujarCasilla(int destinoX, int destinoY)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool MoveFigure(int origenX, int origenY, int destinoX, int destinoY)
        //{
        //    // 1. Validar coordenadas
        //    if (!Utils.IsValidCoordinates(origenX, origenY, Width, Height) ||
        //        !Utils.IsValidCoordinates(destinoX, destinoY, Width, Height))
        //        return false;

        //    // 2. Obtener figura en origen
        //    IFigure? figura = _casillas[origenX, origenY].Figure;
        //    if (figura == null)
        //        return false;

        //    // 3. Verificar movimientos válidos
        //    var movimientosValidos = figura.GetAllAvailablePosition(this);
        //    bool esMovimientoValido = movimientosValidos.Any(m => m.X == destinoX && m.Y == destinoY);

        //    if (!esMovimientoValido)
        //        return false;


        //    // Mover la figura SIN modificar colores
        //    _casillas[destinoX, destinoY].Figure = figura;  // Pieza a nueva posición
        //    _casillas[origenX, origenY].Figure = null; // Limpiar posición original

        //    // Redibujar la casilla de origen
        //    DibujarCasillas(obtenerCasilla(origen));

        //    // Redibujar la casilla de destino
        //    DibujarCasilla(obtenerCasilla(destino));

        //    // 7. Actualizar contador de movimientos (si es necesario)
        //    var cooordfig = figura.GetCoord();

        //    cooordfig = new Coord(destinoX, destinoY);
        //    figura.IncrementCount();
        //    Console.WriteLine($"Moviendo de ({origenX},{origenY}) a ({destinoX},{destinoY})");
        //    return true;
        //}

        public void RemoveFigureAt(int x, int y)
        {
            if (x >= 0 && x < _width && y >= 0 && y < _height)
                _casillas[x, y].Figure = null;
        }

        public IFigure? GetFigureAt(int x, int y)
        {
            if (!Utils.IsValidCoordinates(x, y, _width, _height))
                return null; // Fuera del tablero.
            return _casillas[x, y].Figure;
        }

        public IFigure? GetFigureAt(int index)
        {
            if (index < 0 || index >= _figures.Length)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }
            return _figures[index];
        }
        public Casilla? GetCasillaAt(int x, int y)
        {
            if (!Utils.IsValidCoordinates(x, y, _width, _height))
                return null;

            return _casillas[x, y];
        }

        public int GetFigureCount()
        {
            return _figures.Length + 1;
        }

        public int GetHeight()
        {
            return _height;
        }

        public int GetWidth()
        {
            return _width;
        }

        public void Clear()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _casillas[x, y].Figure = null;
                }
            }
            _figureCount = 0;
        }

        //NO ME FIO
        public bool IsPositionEmpty(Coord coord)
        {
            if (!IsValidPosition(coord)) return false;

            bool isEmpty = true;
            VisitFigures(figure =>
            {
                if (figure.GetCoord().X == coord.X && figure.GetCoord().Y == coord.Y)
                    isEmpty = false;
            });
            return isEmpty;
        }

        //NO ME FIO
        public bool HasEnemyPiece(Coord coord, FigureColor color)
        {
            if (!Utils.IsValidCoordinates(coord.X, coord.Y, _width, _height))
                return false; // Fuera del tablero.

            IFigure? figura = _casillas[coord.X, coord.Y].Figure;
            return figura != null && figura.GetColor() != color;
        }

        //NO ME FIO
        public bool IsKingInCheck(FigureColor color)
        {
            Coord kingPosition = FindKingPosition(color);
            foreach (var figura in _figures)
            {
                if (figura != null && figura.Color != color)
                {
                    var availablePositions = figura.GetAvailablePosition(this);
                    foreach (var pos in availablePositions)
                    {
                        if (pos.X == kingPosition.X && pos.Y == kingPosition.Y)
                            return true;
                    }
                }
            }
            return false;
        }

        //NO ME FIO
        private Coord FindKingPosition(FigureColor color)
        {
            foreach (var figura in _figures)
            {
                if (figura != null && figura.Type == FigureType.KING && figura.Color == color)
                    return figura.Coords;
            }
            throw new Exception("Rey no encontrado");
        }

        //NO ME FIO
        //esto puede ir en utils
        public bool IsCheckmate(FigureColor color)
        {
            if (!IsKingInCheck(color)) return false;

            foreach (var figura in _figures)
            {
                if (figura != null && figura.Color == color)
                {
                    var availablePositions = figura.GetAvailablePosition(this);
                    if (availablePositions.Length > 0)
                        return false;
                }
            }
            return true;
        }

        public List<IFigure> GetAllFigures()
        {
            List<IFigure> figures = new List<IFigure>();

            foreach (var figura in _figures)
            {
                if (figura != null)
                {
                    figures.Add(figura);
                }
            }
            return figures;
        }

        //HA TERMINADO LA PARTIDA??
        public bool IsEndedTheMatch()
        {
            return true;
        }

        public bool IsValidPosition(Coord target)
        {
            return (Utils.IsValidCoordinates(target.X, target.Y, _width, _height)) ? true : false;
        }

        public void VisitFigures(FigureVisitor visitor)
        {
            for (int i = 0; i < _figures.Length; i++)
            {
                if (_figures[i] != null)
                    visitor(_figures[i]);
            }
        }

        public void VisitCapturedFigures(FigureColor color, FigureVisitor visitor)
        {
            var lista = color == FigureColor.WHITE ? _capturedWhiteFigures : _capturedBlackFigures;
            foreach (var figure in lista)
                visitor(figure);
        }

        public void VisitCoords(CoordVisitor visitor)
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    visitor(new Coord(x, y));
                }
            }
        }

        public void VisitCasillas(CasillaVisitor visitor)
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    Casilla? casilla = _casillas[x, y];
                    if (casilla != null)
                    {
                        visitor(casilla);
                    }
                }
            }
        }
        public List<IFigure> FilterFigures(FigureFilter filter)
        {
            var result = new List<IFigure>();

            for(int i = 0; i < _figures.Length; i++)
            {
                var figura = _figures[i];
                if (figura != null && filter(figura))
                {
                    result.Add(figura);
                }
            }
            return result;
        }

        public List<Casilla> FilterCasillas(CasillaFilter filter)
        {
            throw new NotImplementedException();
        }

        public List<Coord> FilterCoords(CoordFilter filter)
        {
            throw new NotImplementedException();
        }



        //tengo que hacer metodos para: enroque del rey y las torres, ahogar al rey, jaque, jaque mate
        //estos metodos deberian de ir en el rey, y en los movimientos hay que ver como se mueven y marcar a donde pueda mover la casilla
        //objetivo a mover, es decir la que le he pasado al programa



        //posible inciso

        //esto deberia ir en utils
        //comprobar el width y height, porque no puedo pasarle un chessboard en la clase chessboard
        //public static void DrawBoard(ChessBoard board)
        //{
        //    Console.WriteLine("  a b c d e f g h");
        //    Console.WriteLine(" ");
        //    for (int y = 0; y < board.GetHeight(); y++)
        //    {
        //        Console.Write(8 - y + " ");
        //        for (int x = 0; x < board.GetWidth(); x++)
        //        {
        //            IFigure? figura = board.GetFigureAt(x, y);
        //            Casilla? casilla = board.GetCasillaAt(x, y);
        //            if (figura != null)
        //            {
        //                DrawFigure(figura);
        //            }
        //            else if (casilla != null)
        //            {
        //                DrawCasilla(casilla);
        //            }
        //            //Console.Write(figura != null ? GetSymbol(figura) : "· ");
        //        }
        //        Console.ResetColor();
        //        Console.WriteLine();
        //    }
        //    Console.WriteLine(" ");
        //    Console.WriteLine("  a b c d e f g h");
        //}

        //private static void DrawCasilla(Casilla? casilla)
        //{
        //    var fondo = casilla?.Color == CasillaColor.WHITE ? ConsoleColor.White : ConsoleColor.Red;
        //    var texto = casilla?.Color == CasillaColor.WHITE ? ConsoleColor.Black : ConsoleColor.White;

        //    Console.BackgroundColor = fondo;
        //    Console.ForegroundColor = texto;
        //    Console.Write("   "); // <-- 3 espacios en blanco
        //    Console.ResetColor();
        //}

        //private static void DrawFigure(IFigure figure)
        //{
        //    var background = ((figure.GetCoord().X + figure.GetCoord().Y) % 2 == 0) ? ConsoleColor.White : ConsoleColor.Red;
        //    Console.BackgroundColor = background;
        //    Console.ForegroundColor = figure.GetColor() == FigureColor.WHITE ? ConsoleColor.Black : ConsoleColor.DarkYellow;
        //    Console.Write(Utils.GetSymbol(figure));
        //    Console.ResetColor();
        //}

        //static string GetSymbol(IFigure figura)
        //{
        //    if (figura is Pawn) return " P ";
        //    if (figura is Tower) return " T ";
        //    if (figura is Knight) return " N ";
        //    if (figura is Bishop) return " B ";
        //    if (figura is Queen) return " Q ";
        //    if (figura is King) return " K ";
        //    else 
        //        return "  ";
        //}


    }
}


//public void PrintBoard()
//{
//    for (int y = Height - 1; y >= 0; y--)
//    {
//        Console.Write(y + 1 + " "); // Números de filas
//        for (int x = 0; x < Width; x++)
//        {
//            var figure = GetFigureAt(x, y);
//            char symbol = figure switch
//            {
//                Pawn => 'P',
//                Tower => 'T',
//                Knight => 'N',
//                Bishop => 'B',
//                Queen => 'Q',
//                King => 'K',
//                _ => ' ' // Casilla vacía
//            };

//            // Determinar el color de la casilla
//            Console.BackgroundColor = (x + y) % 2 == 0 ? ConsoleColor.DarkGray : ConsoleColor.White;
//            Console.ForegroundColor = figure != null && figure.GetColor() == FigureColor.BLACK ? ConsoleColor.Black : ConsoleColor.DarkRed;

//            Console.Write($" {symbol} ");
//            Console.ResetColor();
//        }
//        Console.WriteLine();
//    }

//    Console.Write("  ");
//    for (char c = 'A'; c < 'A' + Width; c++)
//    {
//        Console.Write(" " + c + " "); // Letras de columnas
//    }
//    Console.WriteLine();
//}


//class ChessBoard : IChessBoard
//         *
//{
//         *      IChessBoard b = new ChessBoard();
//         * }




//TODO: EL CREATEFIGURESWITHCOLOR DE ANTES
//public void CreateFiguresWithColor(FigureColor color)
//{
//    if (color == FigureColor.BLACK)
//    {
//        // Colocar las piezas negras
//        CreateFigure(FigureType.TOWER, FigureColor.BLACK, new Coord(0, 7));
//        CreateFigure(FigureType.KNIGHT, FigureColor.BLACK, new Coord(1, 7));
//        CreateFigure(FigureType.BISHOP, FigureColor.BLACK, new Coord(2, 7));
//        CreateFigure(FigureType.QUEEN, FigureColor.BLACK, new Coord(3, 7));
//        CreateFigure(FigureType.KING, FigureColor.BLACK, new Coord(4, 7));
//        CreateFigure(FigureType.BISHOP, FigureColor.BLACK, new Coord(5, 7));
//        CreateFigure(FigureType.KNIGHT, FigureColor.BLACK, new Coord(6, 7));
//        CreateFigure(FigureType.TOWER, FigureColor.BLACK, new Coord(7, 7));

//        for (int x = 0; x < 8; x++)
//        {
//            CreateFigure(FigureType.PAWN, FigureColor.BLACK, new Coord(x, 6));
//        }
//    }
//    else if (color == FigureColor.WHITE)
//    {
//        CreateFigure(FigureType.TOWER, FigureColor.WHITE, new Coord(0, 0));
//        CreateFigure(FigureType.KNIGHT, FigureColor.WHITE, new Coord(1, 0));
//        CreateFigure(FigureType.BISHOP, FigureColor.WHITE, new Coord(2, 0));
//        CreateFigure(FigureType.QUEEN, FigureColor.WHITE, new Coord(3, 0));
//        CreateFigure(FigureType.KING, FigureColor.WHITE, new Coord(4, 0));
//        CreateFigure(FigureType.BISHOP, FigureColor.WHITE, new Coord(5, 0));
//        CreateFigure(FigureType.KNIGHT, FigureColor.WHITE, new Coord(6, 0));
//        CreateFigure(FigureType.TOWER, FigureColor.WHITE, new Coord(7, 0));

//        for (int x = 0; x < 8; x++)
//        {
//            CreateFigure(FigureType.PAWN, FigureColor.WHITE, new Coord(x, 1));
//        }
//    }
//}