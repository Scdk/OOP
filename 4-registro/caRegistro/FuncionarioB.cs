using System;
using System.Collections.Generic;
using System.Text;

namespace caRegistro
{
	class FuncionarioB : Funcionario
	{
		// Atributos
		protected string nome;
		protected string codigoFuncional;
		protected double rendaBasica = 1000;

		// Construtor
		public FuncionarioB(string novoNome, string novoCodigoFuncional)
		{
			nome = novoNome;
			codigoFuncional = novoCodigoFuncional;
		}

		//Getters
		public override string getNome()
		{
			return nome;
		}
		public override string getCodigoFuncional()
		{
			return codigoFuncional;
		}
		public override double getRendaTotal()
		{
			return rendaBasica;
		}
		public override string getEscolaridade()
		{
			return "nenhuma";
		}
		public override string getEscolaB()
		{
			return "nenhuma";
		}
		public override string getEscolaM()
		{
			return "nenhuma";
		}
		public override string getUniversidade()
		{
			return "nenhuma";
		}
		public override string getCurso()
		{
			return "nenhuma";
		}
	}
}
