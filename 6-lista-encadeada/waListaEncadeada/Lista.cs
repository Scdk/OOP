using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waListaEncadeada
{
	class Lista
	{
		NohLista start;
		NohLista end;
		public Lista()
		{
			start = null;
			end = null;
		}
		public bool isEmpthy()
		{
			if (start == null)
				return true;
			else
				return false;
		}
		public void insetAtStart(int value)
		{
			if (isEmpthy())
			{
				start = new NohLista(value);
				end = start;
			}
			else
			{
				NohLista temp = new NohLista(value);
				temp.setNext(start);
				start.setPrevious(temp);
				start = temp;
			}
		}
		public void insetAtEnd(int value)
		{
			if (isEmpthy())
			{
				end = new NohLista(value);
				start = end;
			}
			else
			{
				NohLista temp = new NohLista(value);
				end.setNext(temp);
				temp.setPrevious(end);
				end = temp;
			}
		}
		public void print()
		{
			if (isEmpthy())
			{
				Console.WriteLine("A lista está vazia");
			}
			else
			{
				NohLista temp = new NohLista();
				temp = start;
				for (int i = 1; temp != null; i++)
				{
					Console.WriteLine(i + "°: " + temp.getInfo());
					temp = temp.getNext();
				}
			}
		}
		public void remove(int value)
		{
			bool isInTheList = false;
			if (start.getInfo() == value)
			{
				if (start.getNext() == null)
				{
					start = null;
					isInTheList = true;
				}
				else
				{
					NohLista temp = new NohLista();
					temp = start.getNext();
					temp.setPrevious(null);
					start = temp;
					isInTheList = true;
				}
			}
			else
			{
				NohLista temp = new NohLista();
				temp = start.getNext();
				for (int i = 0; temp != null; i++)
				{
					if (temp.getNext() == null && value == end.getInfo())
					{
						temp = temp.getPrevious();
						temp.setNext(null);
						end = temp;
						isInTheList = true;
						break;
					}
					else if (temp.getInfo() == value)
					{
						temp.getNext().setPrevious(temp.getPrevious());
						temp.getPrevious().setNext(temp.getNext());
						temp = null;
						isInTheList = true;
					}
					else
					{
						temp = temp.getNext();
					}
				}
			}
			if (!(isInTheList))
			{
				System.Windows.Forms.MessageBox.Show("Digite um número que está presente na lista");
			}
		}
		public int maior()
		{
			int maior = start.getInfo();
			NohLista temp = new NohLista();
			temp = start;
			for (int i = 0; temp != null; i++)
			{
				if (temp.getInfo() > maior)
				{
					maior = temp.getInfo();
					temp = temp.getNext();
				}
				else
					temp = temp.getNext();
			}
			return maior;
		}
		public int menor()
		{
			int menor = start.getInfo();
			NohLista temp = new NohLista();
			temp = start;
			for (int i = 0; temp != null; i++)
			{
				if (temp.getInfo() < menor)
				{
					menor = temp.getInfo();
					temp = temp.getNext();
				}
				else
					temp = temp.getNext();
			}
			return menor;
		}
		public NohLista getStart()
		{
			return start;
		}
		public NohLista getEnd()
		{
			return end;
		}
		public void setStart(NohLista newStart)
		{
			start = newStart;
		}
		public void setEnd(NohLista newEnd)
		{
			start = newEnd;
		}
	}
}
