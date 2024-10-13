using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    internal class TaskManager
    {
        List<Task> tareas = new List<Task>();

        private int _taskCount;
        private DateTime _maxDate;


        public int TaskCount
        { 
            get { return _taskCount; }
            set { _taskCount = value; }
        }

        public DateTime MaxDate
        {
            get {return _maxDate;}
        }

        public TaskManager(int taskcount)
        {
           TaskCount = taskcount; 
        }

        public void AddTask(Task task)
        {
            if (task == null)
                throw new Exception("Task no puede ser null");
            tareas.Add(task);
        }

        public static int IndexOf(List<Task> tareas, int n)
        {
            if (tareas == null || tareas.Count < 0 || n < 0)
                throw new Exception("tareas no puede ser null ni n menor de 0, tampoco el tareas.Count puede ser menor de 0");
            for (int i = 0; i < tareas.Count; i++) 
            {
                //if (tareas[i] == n)
                    return i;
            }
            return -1;
        }

        public bool Contains(Task task, int n)
        {
            if (task == null || n < 0)
                throw new Exception("no puede ser task null o n menor de 0");
            return IndexOf(tareas, n) != 0;
        }

        public void RemoveAllTask(string tasks)
        {
            if (tasks == null)
                throw new Exception("Task no pudo removerse por ser nulo");
            foreach (Task task in tareas) 
            {
                //if (task)
                //if (task.Name == tasks)
                //tareas.Remove(task);
            }
        }

        public void ClearTask()
        {
            tareas.Clear();
        }
    }
}
