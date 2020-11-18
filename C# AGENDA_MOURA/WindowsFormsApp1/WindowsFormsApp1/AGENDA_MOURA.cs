using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp;

namespace WindowsFormsApp1
{
    public partial class AGENDA_MOURA : Form 
  {

        CRUD crud = new CRUD();
        
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;
        

        string strSql;

        

        public AGENDA_MOURA()
        {
         
            InitializeComponent();
        }

        private void AGENDA_MOURA_Load(object sender, EventArgs e)
        {

        }
        

        private void btnNovo_Click(object sender, EventArgs e)
        {

            //abaixo realizo o insert into dentro do Banco de dados AGENDa.
            try
            {

               

                strSql = "INSERT INTO AGENDA (NOME, SOBRENOME, TELEFONE_RESIDENCIAL,CELULAR_PRINCIPAL,CELULAR_RECADOS,ENDERECO,NUMERO,BAIRRO,CIDADE,ESTADO)" +
                    " VALUES(@NOME,@SOBRENOME,@TELEFONE_RESIDENCIAL,@CELULAR_PRINCIPAL,@CELULAR_RECADOS,@ENDERECO,@NUMERO,@BAIRRO,@CIDADE,@ESTADO)";
                comando = new SqlCommand(strSql, conexao);


                // aqui verifico se algum campo está vázio para não avançar o cadastro

                if (txtNOME.Text.Equals("") || txtSobrenome.Text.Equals("") || txtTelResidencial.Text.Equals("")
                    || txtCelPrincipal.Text.Equals("") || txtCelRecados.Text.Equals("") || txtEnderco.Text.Equals("") ||
                    txtnumero.Text.Equals("") || txtBairro.Text.Equals("") || txtCidade.Text.Equals("") ||
                    txtEstadio.Text.Equals("") )
                {
                    MessageBox.Show("Favor verificar os campos");
                }

                else
                {
                    //abaixo insert no banco após a verificação
                   
                    comando.Parameters.AddWithValue("@NOME", txtNOME.Text);
                    comando.Parameters.AddWithValue("@SOBRENOME", txtSobrenome.Text);
                    comando.Parameters.AddWithValue("@TELEFONE_RESIDENCIAL", txtTelResidencial.Text);
                    comando.Parameters.AddWithValue("@CELULAR_PRINCIPAL", txtCelPrincipal.Text);
                    comando.Parameters.AddWithValue("@CELULAR_RECADOS", txtCelRecados.Text);
                    comando.Parameters.AddWithValue("@ENDERECO", txtEnderco.Text);
                    comando.Parameters.AddWithValue("@NUMERO", txtnumero.Text);
                    comando.Parameters.AddWithValue("@BAIRRO", txtBairro.Text);
                    comando.Parameters.AddWithValue("@CIDADE", txtCidade.Text);
                    comando.Parameters.AddWithValue("@ESTADO", txtEstadio.Text);



                    conexao.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cadastro Realizado Com Sucesso.");


                    //aqui limpo os campos após cadastro
                    txtNOME.Text = string.Empty;
                    txtSobrenome.Text = string.Empty;
                    txtTelResidencial.Text = string.Empty;
                    txtCelPrincipal.Text = string.Empty;
                    txtCelRecados.Text = string.Empty;
                    txtEnderco.Text = string.Empty;
                    txtnumero.Text = string.Empty;
                    txtBairro.Text = string.Empty;
                    txtCidade.Text = string.Empty;
                    txtEstadio.Text = string.Empty;

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();

                conexao = null;
                comando = null;
            }
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {

            try
            {


                conexao = new SqlConnection("Server=DESKTOP-8UEAH6A;Database=AGENDA_MOURA;Integrated Security=true;");
                strSql = "SELECT * FROM AGENDA";
                DataSet ds = new DataSet();
                da = new SqlDataAdapter(strSql, conexao);

                conexao.Open();
                da.Fill(ds);

                dt.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();


                conexao = null;
                comando = null;
            }


        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {

            //abaixo realizo a consulta via ID
            try
            {

                conexao = new SqlConnection("Server=DESKTOP-8UEAH6A;Database=AGENDA_MOURA;Integrated Security=true;");

                strSql = "SELECT * FROM AGENDA WHERE ID=@ID";
                comando = new SqlCommand(strSql, conexao);

                comando.Parameters.AddWithValue("@ID", txtID.Text);
                comando.Parameters.AddWithValue("@NOME", txtNOME.Text);


                conexao.Open();

                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    txtNOME.Text = (string)dr["NOME"];
                    txtSobrenome.Text = (string)dr["SOBRENOME"];
                    txtTelResidencial.Text = (string)dr["TELEFONE_RESIDENCIAL"];
                    txtCelPrincipal.Text = (string)dr["CELULAR_PRINCIPAL"];
                    txtCelRecados.Text = (string)dr["CELULAR_RECADOS"];
                    txtEnderco.Text = (string)dr["ENDERECO"];
                    txtnumero.Text = (string)dr["NUMERO"];
                    txtBairro.Text = (string)dr["BAIRRO"];
                    txtCidade.Text = (string)dr["CIDADE"];
                    txtEstadio.Text = (string)dr["ESTADO"];


                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();

                conexao = null;
                comando = null;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            string message = "Você tem certeza que deseja EXCLUIR?";
            string title = "EXCLUIR AGENDA";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                try
                {
                    conexao = new SqlConnection("Server=DESKTOP-8UEAH6A;Database=AGENDA_MOURA;Integrated Security=true;");


                    strSql = "DELETE AGENDA WHERE ID = @ID";
                    comando = new SqlCommand(strSql, conexao);

                    comando.Parameters.AddWithValue("@ID", txtID.Text);


                    conexao.Open();

                    comando.ExecuteNonQuery();
                    MessageBox.Show("Exclusão Realizada Com Sucesso.");


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexao.Close();

                    conexao = null;
                    comando = null;
                }

            }
            else
            {
              
            }

          

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
           
            try
            {


                conexao = new SqlConnection("Server=DESKTOP-8UEAH6A;Database=AGENDA_MOURA;Integrated Security=true;");
                strSql = "UPDATE AGENDA SET  ID = @ID, NOME = @NOME, SOBRENOME = @SOBRENOME , TELEFONE_RESIDENCIAL = @TELEFONE_RESIDENCIAL,CELULAR_PRINCIPAL=@CELULAR_PRINCIPAL," +
                    "CELULAR_RECADOS=@CELULAR_RECADOS, ENDERECO=@ENDERECO,NUMERO=@NUMERO, BAIRRO=@BAIRRO, CIDADE=@CIDADE, ESTADO=@ESTADO WHERE ID = @ID";
                comando = new SqlCommand(strSql, conexao);

                comando.Parameters.AddWithValue("@ID", txtID.Text);
                comando.Parameters.AddWithValue("@NOME", txtNOME.Text);
                comando.Parameters.AddWithValue("@SOBRENOME", txtSobrenome.Text);
                comando.Parameters.AddWithValue("@TELEFONE_RESIDENCIAL", txtTelResidencial.Text);
                comando.Parameters.AddWithValue("@CELULAR_PRINCIPAL", txtCelPrincipal.Text);
                comando.Parameters.AddWithValue("@CELULAR_RECADOS", txtCelRecados.Text);
                comando.Parameters.AddWithValue("@ENDERECO", txtEnderco.Text);
                comando.Parameters.AddWithValue("@NUMERO", txtnumero.Text);
                comando.Parameters.AddWithValue("@BAIRRO", txtBairro.Text);
                comando.Parameters.AddWithValue("@CIDADE", txtCidade.Text);
                comando.Parameters.AddWithValue("@ESTADO", txtEstadio.Text);

                conexao.Open();

                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro Editado Com Sucesso.");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();

                conexao = null;
                comando = null;
            }
            
        }

        public void Cadastra_Agenda()
        {
            crud.ID = txtID.Text;
            crud.NOME = txtNOME.Text;
            crud.SOBRENOME = txtSobrenome.Text;
            crud.TELEFONE_RESIDENCIAL = txtTelResidencial.Text;
            crud.CELULAR_PRINCIPAL = txtCelPrincipal.Text;
            crud.CELULAR_RECADOS = txtCelRecados.Text;
            crud.ENDERECO = txtEnderco.Text;
            crud.NUMERO = txtnumero.Text;
            crud.BAIRRO = txtBairro.Text;
            crud.CIDADE = txtCidade.Text;
            crud.ESTADO = txtEstadio.Text;
        }

        public void Update_Agenda()
        {
            crud.ID = txtID.Text;
            crud.NOME = txtNOME.Text;
            crud.SOBRENOME = txtSobrenome.Text;
            crud.TELEFONE_RESIDENCIAL = txtTelResidencial.Text;
            crud.CELULAR_PRINCIPAL = txtCelPrincipal.Text;
            crud.CELULAR_RECADOS = txtCelRecados.Text;
            crud.ENDERECO = txtEnderco.Text;
            crud.NUMERO = txtnumero.Text;
            crud.BAIRRO = txtBairro.Text;
            crud.CIDADE = txtCidade.Text;
            crud.ESTADO = txtEstadio.Text;

        }

        public void Delete_Agenda()
        {
            crud.ID = txtID.Text;
            crud.NOME = txtNOME.Text;
            crud.SOBRENOME = txtSobrenome.Text;
            crud.TELEFONE_RESIDENCIAL = txtTelResidencial.Text;
            crud.CELULAR_PRINCIPAL = txtCelPrincipal.Text;
            crud.CELULAR_RECADOS = txtCelRecados.Text;
            crud.ENDERECO = txtEnderco.Text;
            crud.NUMERO = txtnumero.Text;
            crud.BAIRRO = txtBairro.Text;
            crud.CIDADE = txtCidade.Text;
            crud.ESTADO = txtEstadio.Text;
        }

        private void dt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            try
            {
                if (dt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    txtID.Text=(dt.Rows[e.RowIndex].Cells[0].Value.ToString());
                    txtNOME.Text=(dt.Rows[e.RowIndex].Cells[1].Value.ToString());
                    txtSobrenome.Text=(dt.Rows[e.RowIndex].Cells[2].Value.ToString());
                    txtTelResidencial.Text=(dt.Rows[e.RowIndex].Cells[3].Value.ToString());
                    txtCelPrincipal.Text=(dt.Rows[e.RowIndex].Cells[4].Value.ToString());
                    txtCelRecados.Text=(dt.Rows[e.RowIndex].Cells[5].Value.ToString());
                    txtEnderco.Text=(dt.Rows[e.RowIndex].Cells[6].Value.ToString());
                    txtnumero.Text=(dt.Rows[e.RowIndex].Cells[7].Value.ToString());
                    txtBairro.Text = (dt.Rows[e.RowIndex].Cells[8].Value.ToString());
                    txtCidade.Text = (dt.Rows[e.RowIndex].Cells[9].Value.ToString());
                    txtEstadio.Text = (dt.Rows[e.RowIndex].Cells[10].Value.ToString());

                }
            }

            catch
            {
               
            }
        }
        

        
    }

}
