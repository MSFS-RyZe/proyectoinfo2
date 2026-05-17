using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FlightLib
{
    public class FlightPlan
    {
        // Atributos

        string id;
        Position currentPosition; 
        Position finalPosition;
        Position initialPosition;
        double velocidad;
        

        // Constructures
        public FlightPlan(string id, double cpx, double cpy, double fpx, double fpy, double velocidad)
        {
            this.id = id;
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
            this.initialPosition = new Position(cpx, cpy);
            this.currentPosition = new Position(cpx, cpy);  
        }
        

        // Metodos

        public void Mover(double tiempo)
        // Mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro
        {
            //Calculamos la distancia recorrida en el tiempo dado
            double distancia = tiempo * this.velocidad / 60;

            //Calculamos las razones trigonométricas
            double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            //Caculamos la nueva posición del vuelo
            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;

            Position nextPosition = new Position(x, y);
            if (currentPosition.Distancia(nextPosition) < hipotenusa)
            {
                currentPosition = nextPosition;

            }
            else
            {
                currentPosition = finalPosition;
            }
        }
        public bool EstaEnDestino()
        {
            bool resultado = false;

            if (currentPosition == finalPosition)
                resultado = true;

            return resultado;
        }
        public bool Conflicto(FlightPlan b, double DistanciaSeguridad)
        {
            if (this.currentPosition.Distancia(b.currentPosition) < DistanciaSeguridad)
                return true;
            else
                return false;
        }

        public void EscribeConsola()
        // escribe en consola los datos del plan de vuelo
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", id);
            Console.WriteLine("Velocidad: {0:F2}", velocidad);
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());
            if(this.EstaEnDestino())
                Console.WriteLine("Ha lleago al destino.");
            Console.WriteLine("******************************");
        }

        public string GetId()
        {
            return id;
        }
        public void SetId(string id)
        {
            this.id = id; 
        }

        public Position GetCurrentPosition()
        {
            return currentPosition; 
        }
        public void SetCurrentPosition(Position currentPosition)
        {
            this.currentPosition = currentPosition; 
        }

        public Position GetFinalPosition()
        {
            return finalPosition; 
        }
        public void SetFinalPosition(Position finalPosition)
        {
            this.finalPosition = finalPosition;
        }
        
        public double GetVelocidad()
        {
            return velocidad;
        }
        public void SetVelocidad(double velocidad)
        {
            this.velocidad= velocidad;
        }

        public void Restart(Position initialPosition)
        {
            this.currentPosition = initialPosition;
        }

        public double Distance(FlightPlan plan)
        {
            double distance = currentPosition.Distancia(plan.currentPosition);
            return distance;
        }

        public Position GetInitialPosition()
        {
            return initialPosition;
        }
        public bool HabraConflicto(FlightPlan otro, double distanciaSeguridad)
        {
            double Tiempo;
            double DistanciaMenor;

            double Velocidad1 = velocidad / 60;
            double Velocidad2 = (otro.GetVelocidad()) / 60;

            double H = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            double H2 = Math.Sqrt((otro.GetFinalPosition().GetX() - otro.GetCurrentPosition().GetX())* (otro.GetFinalPosition().GetX() - otro.GetCurrentPosition().GetX()) + (otro.GetFinalPosition().GetY() - otro.GetCurrentPosition().GetY()) * (otro.GetFinalPosition().GetY() - otro.GetCurrentPosition().GetY()));

            double C = (finalPosition.GetX() - currentPosition.GetX()) / H;
            double C2 = (otro.GetFinalPosition().GetX() - otro.GetCurrentPosition().GetX()) / H2;

            double S = (finalPosition.GetY() - currentPosition.GetY()) / H;
            double S2 = (otro.GetFinalPosition().GetY() - otro.GetCurrentPosition().GetY()) / H2;

            Tiempo = -((Velocidad1 * C - Velocidad2 * C2) * (currentPosition.GetX() - otro.GetCurrentPosition().GetX()) + (Velocidad1 * S - Velocidad2 * S2) * (currentPosition.GetY() - otro.GetCurrentPosition().GetY())) / ((Velocidad1 * C - Velocidad2 * C2) * (Velocidad1 * C - Velocidad2 * C2) + (Velocidad1 * S - Velocidad2 * S2) * (Velocidad1 * S - Velocidad2 * S2));

            double X1 = currentPosition.GetX() + Velocidad1 * Tiempo * C;
            double Y1 = currentPosition.GetY() + Velocidad1 * Tiempo * S;
            double X2 = otro.GetCurrentPosition().GetX() + Velocidad2 * Tiempo * C2;
            double Y2 = otro.GetCurrentPosition().GetY() + Velocidad2 * Tiempo * S2;

            DistanciaMenor = Math.Sqrt((X1 - X2) * (X1 - X2) + (Y1 - Y2) * (Y1 - Y2));
            if (DistanciaMenor < distanciaSeguridad)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }
        public bool ReducirVelocidad(FlightPlan p, double Seguridad)
        {
            int i = 0;
            while (HabraConflicto(p, Seguridad))
            {
                this.velocidad = this.velocidad - 1;
                i++;
            }
            return true;
        }
    }
}
