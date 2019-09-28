using System;
using System.Collections.Generic;
using System.Text;

namespace caRegistro
{
	abstract class Funcionario
	{
		// Métodos polimorficos
		public abstract string getEscolaB();
		public abstract string getEscolaM();
		public abstract string getUniversidade();
		public abstract string getCurso();
		public abstract string getEscolaridade();
		public abstract string getNome();
		public abstract string getCodigoFuncional();
		public abstract double getRendaTotal();
	}
}
