using System;
using System.Collections.Generic;
using System.Text;

namespace caVetor3D
{
	class Vetor2D
	{
		// Atributos
		public double x;
		public double y;

		// Construtores
		public void constroeVetor()
		{
			x = 0;
			y = 0;
		}
		public void constroeVetor(double novo_x, double novo_y)
		{
			x = novo_x;
			y = novo_y;
		}

		// Getters
		public double getX()
		{
			return x;
		}
		public double getY()
		{
			return y;
		}
		// Setters
		public void set(double novoX, double novoY)
		{
			x = novoX;
			y = novoY;
		}

		// Calcula escalar
		// Dado o segundo vetor retorna o escalar entre o primeiro e o segundo vetor.
		public double escalar(Vetor2D vec2)
		{
			return ((x * vec2.getX()) + (y * vec2.getY()));
		}

		// Calcula modulo
		public double modulo()
		{
			return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
		}
		public double modulo(Vetor2D vec2)
		{
			return Math.Sqrt(Math.Pow(vec2.getX(), 2) + Math.Pow(vec2.getY(), 2));
		}

		// Calcula angulo
		// Dado o segundo vetor retorna o angulo entre o primeiro e o segundo vetor.
		public double angulo(Vetor2D vec2)
		{
			return ((Math.Acos(escalar(vec2) / (modulo() * modulo(vec2))) * 180) / Math.PI);
		}

		// Calcula projeção
		// Dado o segundo vetor retorna a projeção do primeiro no segundo.
		public void projecao(Vetor2D vec2)
		{
			double projX = (vec2.getX() * (((x * vec2.getX()) + (y * vec2.getY())) / ((Math.Pow(vec2.getX(), 2)) + (Math.Pow(vec2.getY(), 2)))));
			double projY = (vec2.getY() * (((x * vec2.getX()) + (y * vec2.getY())) / ((Math.Pow(vec2.getX(), 2)) + (Math.Pow(vec2.getY(), 2)))));
			Console.WriteLine("Projeção vetorial = (" + Math.Round(projX, 2) + " " + Math.Round(projY, 2) + ")");
		}
	}
}
