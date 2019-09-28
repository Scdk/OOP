using System;

namespace caVetor2D
{
	class Program
	{
		static void Main(string[] args)
		{
			Vetor2D v1 = new Vetor2D();
			Vetor2D v2 = new Vetor2D();
			v1.constroeVetor();
			v2.constroeVetor();
			Console.WriteLine("Vetor 1 = (" + v1.getX() + " " + v1.getY() + ")");
			Console.WriteLine("Vetor 2 = (" + v2.getX() + " " + v2.getY() + ")");
			v1.set(1, 2);
			v2.set(4, 3);
			Console.WriteLine("Novo vetor 1 = (" + v1.getX() + " " + v1.getY() + ")");
			Console.WriteLine("Novo vetor 2 = (" + v2.getX() + " " + v2.getY() + ")");
			Console.WriteLine("Escalar = " + v1.escalar(v2));
			Console.WriteLine("Modulo = " + Math.Round(v1.modulo(), 2));
			Console.WriteLine("Angulo = " + Math.Round(v1.angulo(v2), 2) + "°");
			v1.projecao(v2);
		}
	}
}
