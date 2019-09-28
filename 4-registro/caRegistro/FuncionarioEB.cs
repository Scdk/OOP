using System;
using System.Collections.Generic;
using System.Text;

namespace caRegistro
{
	class FuncionarioEB : FuncionarioB
	{
		// Atributo
		protected string escola;

		//Construtor
		public FuncionarioEB(string novoNome, string novoCodigoFuncional, string novaEscola) : base(novoNome, novoCodigoFuncional)
		{
			escola = novaEscola;
		}

		// Getters
		public override string getEscolaB()
		{
			return escola;
		}
		public override double getRendaTotal()
		{
			return (rendaBasica + (rendaBasica * (10.0 / 100.0)));
		}
		public override string getEscolaridade()
		{
			return "basico";
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
