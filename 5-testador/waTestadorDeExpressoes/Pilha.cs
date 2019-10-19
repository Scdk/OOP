using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waTestadorDeExpressoes
{
	class Pilha
	{
		private NohPilha topo = null;
		public Pilha()
		{
		}
		private bool isVazia(NohPilha noh)
		{
			if (noh == null)
				return true;
			else
				return false;
		}
		public void empilhar(char novoInfo)
		{
			NohPilha novoNoh = new NohPilha(novoInfo, topo);
			topo = novoNoh;
		}
		public void desempilhar()
		{
			if (isVazia(topo))
				Console.WriteLine("A pilha está vazia.");
			else
			{
				topo = topo.getNext();
				Console.WriteLine("Desempilhado com sucesso.");
			}
		}
		public void imprimir()
		{
			if (isVazia(topo))
				Console.WriteLine("A pilha está vazia.");
			else
			{
				NohPilha topoAux = new NohPilha();
				topoAux = topo;
				Console.WriteLine("Pilha: ");
				for (int i = 0; topoAux != null; i++)
				{
					Console.WriteLine(i + 1 + "°: " + topoAux.getInfo() + "\n");
					topoAux = topoAux.getNext();
				}
			}
		}
		public NohPilha getTopo()
		{
			return topo;
		}
	}
}
