using System;
using System.Collections.Generic;
using System.Text;

namespace caVetor3D
{
	class Vetor3D : Vetor2D
	{
		// Atributo
		public double z;

		//Construtores
		public Vetor3D()
		{
			x = 0;
			y = 0;
			z = 0;
		}
		public Vetor3D(double novoX,double novoY ,double novoZ)
		{
			x = novoX;
			y = novoY;
			z = novoZ;
		}
		
		//Getter e setters
		public double getZ()
		{
			return z;
		}
		public void setX(double novoX)
		{
			x = novoX;
		}
		public void setY(double novoY)
		{
			y = novoY;
		}
		public void setZ(double novoZ)
		{
			z = novoZ;
		}

		//Módulos
		public double modulo3D()
		{
			return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
		}
		public Vetor3D multiplicaVetor(Vetor3D r2)
		{
			Vetor3D r3 = new Vetor3D();
			r3.setX((y * r2.getZ()) - (r2.getY() * z));
			r3.setY((r2.getX() * z) - (x * r2.getZ()));
			r3.setZ((x * r2.getY()) - (r2.getX() * y));
			return r3;
		}
	}
}
