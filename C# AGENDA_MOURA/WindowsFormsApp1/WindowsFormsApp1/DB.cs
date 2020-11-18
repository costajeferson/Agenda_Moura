using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace WindowsFormsApp1
{
    class DB
    {
        public SqlConnection conexao;
        public SqlCommand comando;
        public SqlDataAdapter da;
        public SqlDataReader dr;


        public string strSql;


        public DB()
        {
            conexao = new SqlConnection("Server=DESKTOP-8UEAH6A;Database=AGENDA_MOURA;Integrated Security=true;");

        }
    }

    class CRUD : DB
    {


        public string NOME { set; get; }
        public string SOBRENOME { set; get; }
        public string TELEFONE_RESIDENCIAL { set; get; }
        public string CELULAR_PRINCIPAL { set; get; }
        public string CELULAR_RECADOS { set; get; }
        public string ENDERECO { set; get; }
        public string NUMERO { set; get; }
        public string BAIRRO { set; get; }
        public string CIDADE { set; get; }
        public string ESTADO { set; get; }

        // FOR ID

        public string ID { set; get; }

        //LEITURA DE PROPRIEDADES DATAGRID
        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        // CRIA A FUNÇÃO INSERT INTO (CADASTRO)
        public void Cadastra_Agenda()
        {

            try
            {
                conexao = new SqlConnection("Server=DESKTOP-8UEAH6A;Database=AGENDA_MOURA;Integrated Security=true;");

                strSql = "INSERT INTO AGENDA (NOME, SOBRENOME, TELEFONE_RESIDENCIAL,CELULAR_PRINCIPAL,CELULAR_RECADOS,ENDERECO,NUMERO,BAIRRO,CIDADE,ESTADO)" +
                    " VALUES(@NOME,@SOBRENOME,@TELEFONE_RESIDENCIAL,@CELULAR_PRINCIPAL,@CELULAR_RECADOS,@ENDERECO,@NUMERO,@BAIRRO,@CIDADE,@ESTADO)";
                comando = new SqlCommand(strSql, conexao);

                comando.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
                comando.Parameters.Add("@NOME", SqlDbType.VarChar).Value = NOME;
                comando.Parameters.Add("@SOBRENOME", SqlDbType.VarChar).Value = SOBRENOME;
                comando.Parameters.Add("@TELEFONE_RESIDENCIAL", SqlDbType.VarChar).Value = TELEFONE_RESIDENCIAL;
                comando.Parameters.Add("@CELULAR_PRINCIPAL", SqlDbType.VarChar).Value = CELULAR_PRINCIPAL;
                comando.Parameters.Add("@CELULAR_RECADOS", SqlDbType.VarChar).Value = CELULAR_RECADOS;
                comando.Parameters.Add("@ENDERECO", SqlDbType.VarChar).Value = ENDERECO;
                comando.Parameters.Add("@NUMERO", SqlDbType.VarChar).Value = NUMERO;
                comando.Parameters.Add("@BAIRRO", SqlDbType.VarChar).Value = BAIRRO;
                comando.Parameters.Add("@CIDADE", SqlDbType.VarChar).Value = CIDADE;
                comando.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = ESTADO;
                conexao.Open();
                comando.ExecuteNonQuery();
            }


            catch (Exception ex)
            {


            }
            finally
            {
                conexao.Close();

                conexao = null;
                comando = null;
            }


        }

        //FUNÇAÕ UPDATE DB

        public void Update_Agenda()
        {

            try
            {
                conexao = new SqlConnection("Server=DESKTOP-8UEAH6A;Database=AGENDA_MOURA;Integrated Security=true;");
                strSql = "UPDATE AGENDA SET  ID = @ID, NOME = @NOME, SOBRENOME = @SOBRENOME , TELEFONE_RESIDENCIAL = @TELEFONE_RESIDENCIAL,CELULAR_PRINCIPAL=@CELULAR_PRINCIPAL," +
                "CELULAR_RECADOS=@CELULAR_RECADOS, ENDERECO=@ENDERECO,NUMERO=@NUMERO, BAIRRO=@BAIRRO, CIDADE=@CIDADE, ESTADO=@ESTADO WHERE ID = @ID";

                comando = new SqlCommand(strSql, conexao);


                comando.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
                comando.Parameters.Add("@NOME", SqlDbType.VarChar).Value = NOME;
                comando.Parameters.Add("@SOBRENOME", SqlDbType.VarChar).Value = SOBRENOME;
                comando.Parameters.Add("@TELEFONE_RESIDENCIAL", SqlDbType.VarChar).Value = TELEFONE_RESIDENCIAL;
                comando.Parameters.Add("@CELULAR_PRINCIPAL", SqlDbType.VarChar).Value = CELULAR_PRINCIPAL;
                comando.Parameters.Add("@CELULAR_RECADOS", SqlDbType.VarChar).Value = CELULAR_RECADOS;
                comando.Parameters.Add("@ENDERECO", SqlDbType.VarChar).Value = ENDERECO;
                comando.Parameters.Add("@NUMERO", SqlDbType.VarChar).Value = NUMERO;
                comando.Parameters.Add("@BAIRRO", SqlDbType.VarChar).Value = BAIRRO;
                comando.Parameters.Add("@CIDADE", SqlDbType.VarChar).Value = CIDADE;
                comando.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = ESTADO;


                comando.ExecuteNonQuery();
                conexao.Close();

            }
            catch (Exception ex)
            {


            }
            finally
            {
                conexao.Close();

                conexao = null;
                comando = null;
            }



        }

        //FUNÇÃO DELETE 

        public void Delete_Agenda()
        {
           
            {
                conexao = new SqlConnection("Server=DESKTOP-8UEAH6A;Database=AGENDA_MOURA;Integrated Security=true;");
                conexao = "DELETE FROM AGENDA WHERE  ID = @ID";
                comando = new SqlCommand(strSql, conexao);

                comando.CommandType = CommandType.Text;
                comando.Connection = conexao;

                comando.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
                comando.Parameters.Add("@NOME", SqlDbType.VarChar).Value = NOME;
                comando.Parameters.Add("@SOBRENOME", SqlDbType.VarChar).Value = SOBRENOME;
                comando.Parameters.Add("@TELEFONE_RESIDENCIAL", SqlDbType.VarChar).Value = TELEFONE_RESIDENCIAL;
                comando.Parameters.Add("@CELULAR_PRINCIPAL", SqlDbType.VarChar).Value = CELULAR_PRINCIPAL;
                comando.Parameters.Add("@CELULAR_RECADOS", SqlDbType.VarChar).Value = CELULAR_RECADOS;
                comando.Parameters.Add("@ENDERECO", SqlDbType.VarChar).Value = ENDERECO;
                comando.Parameters.Add("@NUMERO", SqlDbType.VarChar).Value = NUMERO;
                comando.Parameters.Add("@BAIRRO", SqlDbType.VarChar).Value = BAIRRO;
                comando.Parameters.Add("@CIDADE", SqlDbType.VarChar).Value = CIDADE;
                comando.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = ESTADO;


                comando.ExecuteNonQuery();
                conexao.Close();

            }

        }

        //FUNÇÃO SELECT PARA CARREGAR DADOS
        public void Carregar_dados()
        {

            conexao = new SqlConnection("Server=DESKTOP-8UEAH6A;Database=AGENDA_MOURA;Integrated Security=true;");
            strSql = "SELECT * FROM AGENDA";
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(strSql, conexao);

            conexao.Open();
            da.Fill(ds);

            // dt.DataSource = ds.Tables[0];




            comando.ExecuteNonQuery();
            conexao.Close();

            conexao = null;
            comando = null;
        }


    }
}
    
    


