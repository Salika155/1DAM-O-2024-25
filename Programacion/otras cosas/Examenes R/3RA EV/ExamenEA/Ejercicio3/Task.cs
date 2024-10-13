namespace Ejercicio3
{
    public enum TaskState
    {
        Realizada,
        PorEmpezar,
        Amedias,
        Desconocido
    }
    internal class Task
    {
        private int _id;
        private string? _name = "";
        private string? _description = "";
        private DateTime _realizationDate;
        private int _priority;
        private TaskState _taskState;

        public int ID 
        { 
            get 
            { return _id; } 
            set 
            {  _id = value; }
        }

        public string Name
        { 
            get 
            { return _name; }
            set 
            { _name = value; }
        } 

        public string Description
        {
            get
            { return _description; }
            set
            { _description = value; }
        }

        public DateTime RealizationDate
        {
            get 
            { return _realizationDate; }
            set
            { _realizationDate = value; }
        }

        public int Priority
        {
            get 
            { return _priority; }
            set
            { _priority = value; }
        }

        public TaskState TaskState
        {
            get 
            { return _taskState; }
            set
            { _taskState = value; }
        }

        public Task(int id, string nombre, string descripcion, DateTime fecharealizacion, int prioridad)
        {
            _id = id;
            _name = nombre;
            _description = descripcion;
            _realizationDate = fecharealizacion;
            _priority = prioridad;
            _taskState = TaskState.PorEmpezar; 
        }
    }
}