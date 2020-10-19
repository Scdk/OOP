using System;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace waLocadoraDeJogos
{

	public partial class Form1 : Form
	{
		private NpgsqlConnection conn;   // variavel para conctar com banco
		private NpgsqlCommand command;   // variavel para maniular comandos
		private NpgsqlDataReader result; // variavel para guardar dados consultados
		
		public Form1()
		{
			InitializeComponent();
			fillListView();
			fillJogosAlugados();
			fillGenero();
		}
		
		private void fillJogosAlugados()
		{
			connectionTest();
			try
			{
				cbJogo1.Items.Clear();
				cbJogo1.Items.Add(" ");
				cbJogo2.Items.Clear();
				cbJogo2.Items.Add(" ");
				cbJogo3.Items.Clear();
				cbJogo3.Items.Add(" ");
				string sql = ("SELECT * FROM jogos ORDER BY nome");
				using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
				{
					NpgsqlDataReader reader = command.ExecuteReader();
					for (int i = 0; reader.Read(); i++)
					{
						cbJogo1.Items.Add(reader[1].ToString());
						cbJogo2.Items.Add(reader[1].ToString());
						cbJogo3.Items.Add(reader[1].ToString());
					}	
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		} 

		private void btnTestConnection()
		{
			connectionTest();
			MessageBox.Show("Conexão realizada");
		}

		private void connectionTest()
		{
			try
			{
				conn = new NpgsqlConnection("Server=127.0.0.1; User Id=postgres; Password=581586; Database=postgres;");
				conn.Open();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		}

		private void fillListView()
		{
			fillListViewCliente();
			fillListViewJogo();
			fillListViewGenero();
			fillListViewFuncionario();
		}
		private bool alreadyExists(string table, string PK)
		{
			connectionTest();
			string sql = ("SELECT * FROM " + table + " ORDER BY nome");
			using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
			{
				NpgsqlDataReader reader = command.ExecuteReader();
				for (int i = 0; reader.Read(); i++)
					if (lvJogo.Items[i].Text == PK)
					{
						conn.Close();
						return true;
					}
				conn.Close();
				return false;
			}
		}
		private bool alreadyExistsCliente(string table, string PK)
		{
			connectionTest();
			string sql = ("SELECT * FROM " + table + " ORDER BY nome");
			using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
			{
				NpgsqlDataReader reader = command.ExecuteReader();
				for (int i = 0; reader.Read(); i++)
					if (lvCliente.Items[i].SubItems[1].Text == PK)
					{
						conn.Close();
						return true;
					}
				conn.Close();
				return false;
			}
		}
		private bool alreadyExistsGenero(string table, string PK)
		{
			connectionTest();
			string sql = ("SELECT * FROM " + table + " ORDER BY genero");
			using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
			{
				NpgsqlDataReader reader = command.ExecuteReader();
				for (int i = 0; reader.Read(); i++)
					if (lvGenero.Items[i].Text == PK)
					{
						conn.Close();
						return true;
					}
				conn.Close();
				return false;
			}
		}
		private bool alreadyExistsFuncionario(string table, string PK)
		{
			connectionTest();
			string sql = ("SELECT * FROM " + table + " ORDER BY nome");
			using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
			{
				NpgsqlDataReader reader = command.ExecuteReader();
				for (int i = 0; reader.Read(); i++)
					if (lvFuncionario.Items[i].Text == PK)
					{
						conn.Close();
						return true;
					}
				conn.Close();
				return false;
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			connectionTest();
			try
			{
				if (alreadyExistsCliente("cliente", tbClienteCPF.Text))
				{
					if (cbJogo1.Text != lvCliente.SelectedItems[0].SubItems[2].Text)
					{
						isInStock(cbJogo1.Text);
					}
					if (cbJogo2.Text != lvCliente.SelectedItems[0].SubItems[3].Text)
					{
						isInStock(cbJogo2.Text);
					}
					if (cbJogo3.Text != lvCliente.SelectedItems[0].SubItems[4].Text)
					{
						isInStock(cbJogo3.Text);
					}
					connectionTest();
						command = new NpgsqlCommand("UPDATE cliente SET nome='" + tbClienteNome.Text + "',cpf='" + tbClienteCPF.Text +
							"',jogo1='" + cbJogo1.Text + "',jogo2='" + cbJogo2.Text + "',jogo3='" + cbJogo3.Text +
							"' WHERE cpf='" + tbClienteCPF.Text + "'", conn);
						command.ExecuteReader();
						MessageBox.Show("Registro Atualizado!");
						conn.Close();
						tbClienteNome.Text = "";
						tbClienteCPF.Text = "";
						cbJogo1.Text = "";
						cbJogo2.Text = "";
						cbJogo3.Text = "";
						btClienteInserir.Text = "Inserir";
						fillListViewCliente();
				}
				else
				{
					if (isInStock(cbJogo1.Text) && isInStock(cbJogo2.Text) && isInStock(cbJogo3.Text))
					{
						connectionTest();
						//Definindo o comando para inserir registros
						command = new NpgsqlCommand("INSERT into Cliente (nome,cpf,jogo1,jogo2,jogo3) VALUES ('" +
							tbClienteNome.Text + "','" + tbClienteCPF.Text + "','" + cbJogo1.Text + "','" +
							cbJogo2.Text + "','" + cbJogo2.Text + "')", conn);
						command.ExecuteReader();
						MessageBox.Show("Registro Inserido!");
						//Fechando a conexão
						conn.Close();
						//Limpando os campos apos a inclusão
						tbClienteNome.Text = "";
						tbClienteCPF.Text = "";
						cbJogo1.Text = "";
						cbJogo2.Text = "";
						cbJogo3.Text = "";
						fillListViewCliente();
					}
					else
					{
						MessageBox.Show("Jogo fora de estoque");
						tbClienteNome.Text = "";
						tbClienteCPF.Text = "";
						cbJogo1.Text = "";
						cbJogo2.Text = "";
						cbJogo3.Text = "";
						btClienteInserir.Text = "Inserir";
						fillListViewCliente();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		}
		private void fillListViewCliente()
		{
			connectionTest();
			try
			{
				lvCliente.Items.Clear();
				string sql = ("SELECT * FROM cliente ORDER BY nome");
				using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
				{
					NpgsqlDataReader reader = command.ExecuteReader();
					for (int i = 0; reader.Read(); i++)
					{
						lvCliente.Items.Add(reader[0].ToString());
						lvCliente.Items[i].SubItems.Add(reader[1].ToString());
						lvCliente.Items[i].SubItems.Add(reader[2].ToString());
						lvCliente.Items[i].SubItems.Add(reader[3].ToString());
						lvCliente.Items[i].SubItems.Add(reader[4].ToString());
						lvCliente.Update();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		}
		private void tpCliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				fillListView();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		}
		private void btJogoInserir_Click(object sender, EventArgs e)
		{
			connectionTest();
			try
			{
				if (alreadyExists("jogos", tbJogoId.Text))
				{
					connectionTest();
					command = new NpgsqlCommand("UPDATE jogos SET id='" + tbJogoId.Text + "',nome='" + tbJogoNome.Text +
						"',quantidade='" + tbJogoQuantidade.Text + "',ano='" + tbJogoAno.Text + "',plataforma='" + tbJogoPlataforma.Text +
						"',desenvolvedora='" + tbJogoDesenvolvedora.Text + "',genero='" + cbGenero.Text + "' WHERE id='" + tbJogoId.Text + "'", conn);
					command.ExecuteReader();
					MessageBox.Show("Registro Atualizado!");
					conn.Close();
					//if (alreadyExists("cliente", tbJogoNome.Text))
					//{
					//	connectionTest();
					//	command = new NpgsqlCommand("UPDATE cliente SET name='"+ tbJogoNome.Text + "' WHERE name='" + tbJogoId.Text + "'", conn);
					//	command.ExecuteReader();
					//	MessageBox.Show("Registro Atualizado!");
					//	conn.Close();
					//}
					tbJogoId.Text = "";
					tbJogoNome.Text = "";
					tbJogoAno.Text = "";
					tbJogoPlataforma.Text = "";
					tbJogoDesenvolvedora.Text = "";
					tbJogoQuantidade.Text = "";
					cbGenero.Text = "";
					btJogoInserir.Text = "Inserir";
					fillListViewJogo();
					fillJogosAlugados();
				}
				else
				{
					connectionTest();
					//Definindo o comando para inserir registros
					command = new NpgsqlCommand("INSERT into jogos (id,nome,quantidade,ano,plataforma,desenvolvedora,genero) VALUES ('" +
						tbJogoId.Text + "','" + tbJogoNome.Text + "','" + tbJogoQuantidade.Text + "','" + tbJogoAno.Text + "','" + tbJogoPlataforma.Text +
						"','" + tbJogoDesenvolvedora.Text + "','" + cbGenero.Text + "')", conn);
					command.ExecuteReader();
					MessageBox.Show("Registro Inserido!");
					//Fechando a conexão
					conn.Close();
					//Limpando os campos apos a inclusão
					tbJogoId.Text = "";
					tbJogoNome.Text = "";
					tbJogoAno.Text = "";
					tbJogoPlataforma.Text = "";
					tbJogoDesenvolvedora.Text = "";
					tbJogoQuantidade.Text = "";
					cbGenero.Text = "";
					btJogoInserir.Text = "Inserir";
					fillListViewJogo();
					fillJogosAlugados();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		}

		private void fillListViewJogo()
		{
			connectionTest();
			try
			{
				lvJogo.Items.Clear();
				string sql = ("SELECT * FROM jogos ORDER BY nome");
				using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
				{
					NpgsqlDataReader reader = command.ExecuteReader();
					for (int i = 0; reader.Read(); i++)
					{
						lvJogo.Items.Add(reader[0].ToString());
						lvJogo.Items[i].SubItems.Add(reader[1].ToString());
						lvJogo.Items[i].SubItems.Add(reader[2].ToString());
						lvJogo.Items[i].SubItems.Add(reader[3].ToString());
						lvJogo.Items[i].SubItems.Add(reader[4].ToString());
						lvJogo.Items[i].SubItems.Add(reader[5].ToString());
						lvJogo.Items[i].SubItems.Add(reader[6].ToString());
						lvJogo.Update();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		}
		private void lvCliente_ItemActivate(object sender, EventArgs e)
		{
			try
			{
				tbClienteNome.Text = lvCliente.SelectedItems[0].Text;
				tbClienteCPF.Text = lvCliente.SelectedItems[0].SubItems[1].Text;
				cbJogo1.Text = lvCliente.SelectedItems[0].SubItems[2].Text;
				cbJogo2.Text = lvCliente.SelectedItems[0].SubItems[3].Text;
				cbJogo3.Text = lvCliente.SelectedItems[0].SubItems[4].Text;
				btClienteInserir.Text = "Update";
				btClienteDeletar.Visible = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		}
		private void lvJogo_ItemActivate(object sender, EventArgs e)
		{
			try
			{
				tbJogoId.Text = lvJogo.SelectedItems[0].Text;
				tbJogoNome.Text = lvJogo.SelectedItems[0].SubItems[1].Text;
				tbJogoQuantidade.Text = lvJogo.SelectedItems[0].SubItems[2].Text;
				tbJogoAno.Text = lvJogo.SelectedItems[0].SubItems[3].Text;
				tbJogoPlataforma.Text = lvJogo.SelectedItems[0].SubItems[4].Text;
				tbJogoDesenvolvedora.Text = lvJogo.SelectedItems[0].SubItems[5].Text;
				cbGenero.Text = lvJogo.SelectedItems[0].SubItems[6].Text;
				btJogoInserir.Text = "Update";
				btJogoDeletar.Visible = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		}

		private void btGeneroInserir_Click(object sender, EventArgs e)
		{
			connectionTest();
			try
			{
				if (alreadyExistsGenero("genero", tbGeneroId.Text))
				{
					connectionTest();
					command = new NpgsqlCommand("UPDATE genero SET id='" + tbGeneroId.Text + "',genero='" + tbGeneroGenero.Text +
						"' WHERE id='" + tbGeneroId.Text + "'", conn);
					command.ExecuteReader();
					MessageBox.Show("Registro Atualizado!");
					conn.Close();
					tbGeneroId.Text = "";
					tbGeneroGenero.Text = "";
					btGeneroInserir.Text = "Inserir";
					fillListViewGenero();
					fillGenero();
				}
				else
				{
					connectionTest();
					//Definindo o comando para inserir registros
					command = new NpgsqlCommand("INSERT into genero (id,genero) VALUES ('" +
						tbGeneroId.Text + "','" + tbGeneroGenero.Text + "')", conn);
					command.ExecuteReader();
					MessageBox.Show("Registro Inserido!");
					//Fechando a conexão
					conn.Close();
					//Limpando os campos apos a inclusão
					tbGeneroId.Text = "";
					tbGeneroGenero.Text = "";
					btGeneroInserir.Text = "Inserir";
					fillListViewGenero();
					fillGenero();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		}
		private void fillListViewGenero()
		{
			connectionTest();
			try
			{
				lvGenero.Items.Clear();
				string sql = ("SELECT * FROM genero ORDER BY genero");
				using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
				{
					NpgsqlDataReader reader = command.ExecuteReader();
					for (int i = 0; reader.Read(); i++)
					{
						lvGenero.Items.Add(reader[0].ToString());
						lvGenero.Items[i].SubItems.Add(reader[1].ToString());
						lvGenero.Update();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		}
		private void fillGenero()
		{
			connectionTest();
			try
			{
				cbGenero.Items.Clear();
				cbGenero.Items.Add(" ");
				string sql = ("SELECT * FROM genero ORDER BY genero");
				using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
				{
					NpgsqlDataReader reader = command.ExecuteReader();
					for (int i = 0; reader.Read(); i++)
					{
						cbGenero.Items.Add(reader[1].ToString());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		}

		private void lvGenero_ItemActivate(object sender, EventArgs e)
		{
			try
			{
				tbGeneroId.Text = lvGenero.SelectedItems[0].Text;
				tbGeneroGenero.Text = lvGenero.SelectedItems[0].SubItems[1].Text;
				btGeneroInserir.Text = "Update";
				btGeneroDeletar.Visible = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		}

		private void btFuncionarioInserir_Click(object sender, EventArgs e)
		{
			connectionTest();
			try
			{
				if (alreadyExistsFuncionario("funcionario", tbFuncionarioCf.Text))
				{
					connectionTest();
					command = new NpgsqlCommand("UPDATE funcionario SET cf='" + tbFuncionarioCf.Text + "',nome='" + tbFuncionarioNome.Text +
						"',cpf='" + tbFuncionarioCPF.Text + "',nascimento='" + tbFuncionarioNascimento.Text + 
						"',salario='" + tbFuncionarioSalario.Text + "' WHERE cf='" + tbFuncionarioCf.Text + "'", conn);
					command.ExecuteReader();
					MessageBox.Show("Registro Atualizado!");
					conn.Close();
					tbFuncionarioCf.Text = "";
					tbFuncionarioNome.Text = "";
					tbFuncionarioCPF.Text = "";
					tbFuncionarioNascimento.Text = "";
					tbFuncionarioSalario.Text = "";
					btFuncionarioInserir.Text = "Inserir";
					fillListViewFuncionario();
				}
				else
				{
					connectionTest();
					//Definindo o comando para inserir registros
					command = new NpgsqlCommand("INSERT into funcionario (cf,nome,cpf,nascimento,salario) VALUES ('" +
						tbFuncionarioCf.Text + "','" + tbFuncionarioNome.Text + "','" + tbFuncionarioCPF.Text + "','" +
						tbFuncionarioNascimento.Text + "','" + tbFuncionarioSalario.Text + "')", conn);
					command.ExecuteReader();
					MessageBox.Show("Registro Inserido!");
					//Fechando a conexão
					conn.Close();
					//Limpando os campos apos a inclusão
					tbFuncionarioCf.Text = "";
					tbFuncionarioNome.Text = "";
					tbFuncionarioCPF.Text = "";
					tbFuncionarioNascimento.Text = "";
					tbFuncionarioSalario.Text = "";
					fillListViewFuncionario();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		}
		private void fillListViewFuncionario()
		{
			connectionTest();
			try
			{
				lvFuncionario.Items.Clear();
				string sql = ("SELECT * FROM funcionario ORDER BY nome");
				using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
				{
					NpgsqlDataReader reader = command.ExecuteReader();
					for (int i = 0; reader.Read(); i++)
					{
						lvFuncionario.Items.Add(reader[0].ToString());
						lvFuncionario.Items[i].SubItems.Add(reader[1].ToString());
						lvFuncionario.Items[i].SubItems.Add(reader[2].ToString());
						lvFuncionario.Items[i].SubItems.Add(reader[3].ToString());
						lvFuncionario.Items[i].SubItems.Add(reader[4].ToString());
						lvFuncionario.Update();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		}

		private void lvFuncionario_ItemActivate(object sender, EventArgs e)
		{
			try
			{
				tbFuncionarioCf.Text = lvFuncionario.SelectedItems[0].Text;
				tbFuncionarioNome.Text = lvFuncionario.SelectedItems[0].SubItems[1].Text;
				tbFuncionarioCPF.Text = lvFuncionario.SelectedItems[0].SubItems[2].Text;
				tbFuncionarioNascimento.Text = lvFuncionario.SelectedItems[0].SubItems[3].Text;
				tbFuncionarioSalario.Text = lvFuncionario.SelectedItems[0].SubItems[4].Text;
				btFuncionarioInserir.Text = "Update";
				btFuncionarioDeletar.Visible = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
			
		}

		private void btClienteDeletar_Click(object sender, EventArgs e)
		{
			connectionTest();
			try
				{
				//Definindo o comando para exclusão do registro
				command = new NpgsqlCommand("DELETE from cliente where cpf=" + lvCliente.SelectedItems[0].SubItems[1].Text, conn);
				//Executando o comando
				command.ExecuteReader();
				MessageBox.Show("Regitro excluido com sucesso!");
				btClienteDeletar.Visible = false;
				//Atualizando o dataGrid
				fillListViewCliente();
				tbClienteNome.Text = "";
				tbClienteCPF.Text = "";
				cbJogo1.Text = "";
				cbJogo2.Text = "";
				cbJogo3.Text = "";
				btClienteInserir.Text = "Inserir";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		}

		private void btJogoDeletar_Click(object sender, EventArgs e)
		{
			connectionTest();
			try
			{
				//Definindo o comando para exclusão do registro
				command = new NpgsqlCommand("DELETE from jogos where id='" + lvJogo.SelectedItems[0].Text + "'", conn);
				//Executando o comando
				command.ExecuteReader();
				MessageBox.Show("Regitro excluido com sucesso!");
				btJogoDeletar.Visible = false;
				//Atualizando o dataGrid
				fillListViewJogo();
				tbJogoId.Text = "";
				tbJogoNome.Text = "";
				tbJogoAno.Text = "";
				tbJogoPlataforma.Text = "";
				tbJogoDesenvolvedora.Text = "";
				tbJogoQuantidade.Text = "";
				cbGenero.Text = "";
				btJogoInserir.Text = "Inserir";
				fillListViewJogo();
				fillJogosAlugados();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		}

		private void btGeneroDeletar_Click(object sender, EventArgs e)
		{
			connectionTest();
			try
			{
				//Definindo o comando para exclusão do registro
				command = new NpgsqlCommand("DELETE from genero where id='" + lvGenero.SelectedItems[0].Text + "'", conn);
				//Executando o comando
				command.ExecuteReader();
				MessageBox.Show("Regitro excluido com sucesso!");
				btGeneroDeletar.Visible = false;
				//Atualizando o dataGrid
				fillListViewJogo();
				tbGeneroId.Text = "";
				tbGeneroGenero.Text = "";
				btGeneroInserir.Text = "Inserir";
				fillListViewGenero();
				fillGenero();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		}

		private void btFuncionarioDeletar_Click(object sender, EventArgs e)
		{
			connectionTest();
			try
			{
				//Definindo o comando para exclusão do registro
				command = new NpgsqlCommand("DELETE from funcionario where cf='" + lvFuncionario.SelectedItems[0].Text + "'", conn);
				//Executando o comando
				command.ExecuteReader();
				MessageBox.Show("Regitro excluido com sucesso!");
				btFuncionarioDeletar.Visible = false;
				//Atualizando o dataGrid
				fillListViewJogo();
				tbFuncionarioCf.Text = "";
				tbFuncionarioNome.Text = "";
				tbFuncionarioCPF.Text = "";
				tbFuncionarioNascimento.Text = "";
				tbFuncionarioSalario.Text = "";
				btFuncionarioInserir.Text = "Inserir";
				fillListViewFuncionario();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro encontrado:" + ex);
			}
		}
		private bool isInStock(string name)
		{
			if (name == "" || name == " ")
			{
				return true;
			}
			connectionTest();
			string sql = ("SELECT * FROM jogos ORDER BY nome");
			using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
			{
				NpgsqlDataReader reader = command.ExecuteReader();
				for (int i = 0; reader.Read(); i++)
					if (lvJogo.Items[i].SubItems[1].Text == name)
					{
						if (Convert.ToInt32(lvJogo.Items[i].SubItems[2].Text) > 0)
						{
							conn.Close();
							decreasesStock(i);
							return true;
						}
					}
				conn.Close();
				return false;
			}
		}
		private void decreasesStock(int i)
		{
			connectionTest();
			command = new NpgsqlCommand("UPDATE jogos SET quantidade='" + (Convert.ToInt32(lvJogo.Items[i].SubItems[2].Text) - 1) + 
				"' WHERE id='" + lvJogo.Items[i].SubItems[0].Text + "'", conn);
			command.ExecuteReader();
			conn.Close();
			fillListViewJogo();
		}
	}
}
