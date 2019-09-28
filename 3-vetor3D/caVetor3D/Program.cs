using System;

namespace caVetor3D
{
	class Program
	{
		static void Main(string[] args)
		{
			// Criando e preenchendo os atributos
			int x;
			int y;
			int z;
			Console.WriteLine("Preencha o x do primeiro vetor: ");
			x = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Preencha o y do primeiro vetor: ");
			y = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Preencha o z do primeiro vetor: ");
			z = Convert.ToInt32(Console.ReadLine());
			Vetor3D r1 = new Vetor3D(x, y, z);
			Console.WriteLine("\nPreencha o x do segundo vetor: ");
			x = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Preencha o y do segundo vetor: ");
			y = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Preencha o z do segundo vetor: ");
			z = Convert.ToInt32(Console.ReadLine());
			Vetor3D r2 = new Vetor3D(x, y, z);

			// Usando os métodos
			Console.WriteLine("\nModulo do vetor 3D: " + Math.Round(r1.modulo3D(), 2));
			Console.WriteLine("Multiplicação de dois vetores:\n" + "X: " + (r1.multiplicaVetor(r2).getX()) + "\nY: " + r1.multiplicaVetor(r2).getY() + "\nZ: "
				+ r1.multiplicaVetor(r2).getZ());
		}
	}
}
