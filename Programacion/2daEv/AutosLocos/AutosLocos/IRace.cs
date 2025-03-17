using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocos
{
    public interface IRace
    {
        delegate void Visitor(RaceObject raceObject);
        void AddObject(RaceObject raceObject, double position);
        void Init(double distance);
        void SimulateStep();
        void VisitDrivers(Visitor visitor);
        void VisitCars(Visitor visitor);
        void VisitObstacles(Visitor visitor);
        void VisitObjects(Visitor visitor);
        int GetObjectCount();
        RaceObject GetObjectAt(int index);
        public List<RaceObject> Simulate();
        public List<RaceObject> GetRacers();
    }
}
