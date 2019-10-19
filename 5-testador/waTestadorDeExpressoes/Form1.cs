using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace waTestadorDeExpressoes
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void testador()
		{
			bool flag = false;
			Pilha p1 = new Pilha();
			for (int i = 0; i < textBox1.TextLength; i++)
			{
				if (textBox1.Text[i] == '{' || textBox1.Text[i] == '[' || textBox1.Text[i] == '(')
				{
					p1.empilhar(textBox1.Text[i]);
				}
				else if (textBox1.Text[i] == '}')
				{
					if (p1.getTopo() != null && p1.getTopo().getInfo() == '{')
					{
						p1.desempilhar();
					}
					else
					{
						flag = true;
						break;
					}
				}
				else if (textBox1.Text[i] == ']')
				{
					if (p1.getTopo() != null && p1.getTopo().getInfo() == '[')
					{
						p1.desempilhar();
					}
					else
					{
						flag = true;
						break;
					}
				}
				else if (textBox1.Text[i] == ')')
				{
					if (p1.getTopo() != null && p1.getTopo().getInfo() == '(')
					{
						p1.desempilhar();
					}
					else
					{
						flag = true;
						break;
					}
				}
				else
					continue;
			}
			NohPilha topoAux = new NohPilha();
			topoAux = p1.getTopo();
			for (int i = 0; topoAux != null; i++)
			{
				if (topoAux.getInfo() == '{' || topoAux.getInfo() == '[' || topoAux.getInfo() == '(')
				{
					flag = true;
				}
				topoAux = topoAux.getNext();
			}
			if (flag)
			{
				MessageBox.Show("A expressão matemática está incorreta");
			}
			else
				MessageBox.Show("A expressão matemática está correta");
		}

		private void button1_MouseClick(object sender, MouseEventArgs e)
		{
			testador();
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if((Keys)e.KeyChar == Keys.Enter)
			{
				testador();
			}
		}
	}
}
