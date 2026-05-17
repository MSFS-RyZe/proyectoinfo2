using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlanList
    {
        //Atributos//

        List<FlightPlan> lista = new List<FlightPlan>();
        double distanciaSeguridad;
        double ciclo;

        //Métodos//

        public void AddFlightPlan(FlightPlan p)
        {
            lista.Add(p);
        }
        public FlightPlan GetFlightPlan(int i)
        {
            FlightPlan p = lista[i];
            return p;
        }
        public void Mover(double tiempo)
        {
            for(int i = 0; i < lista.Count; i++)
            {
                lista[i].Mover(tiempo);
            }
        }
        public void EscribeConsola()
        {
            for( int i = 0;i < lista.Count; i++)
            {
                lista[i].EscribeConsola();
            }
        }

        public void SetDistanciaSeguridad(double d)
        {
            distanciaSeguridad = d;
        }

        public double GetDistanciaSeguridad()
        {
            return distanciaSeguridad;
        }

        public void SetCiclo(double t)
        {
            ciclo = t;
        }

        public double GetCiclo()
        {
            return ciclo;
        }

        public void Reset()
        {
            lista.Clear();
        }

        public int GetNumber()
        {
            return lista.Count;
        }
        public bool MultipleConflicto(double distancia)
        {
            int i = 0;
            int j;
            bool conflicto = false;
            while (i < lista.Count)
            {
                j = i + 1;
                while (j < lista.Count)
                {
                    if (lista[i].Conflicto(lista[j], distancia))
                    {
                        conflicto = true;
                    }
                    j++;
                }
                i++;
            }
            if (conflicto)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool HabraMultipleConflicto(double distancia)
        {
            int i = 0;
            int j;
            bool conflicto = false;
            while( i < lista.Count )
            {
                j = i + 1;
                while( j < lista.Count )
                {
                    if (lista[i].HabraConflicto(lista[j], distancia))
                    {
                         conflicto = true;
                    }
                    j++;
                }
                i++;
            }
            if (conflicto)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
