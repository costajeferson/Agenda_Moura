using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace WindowsFormsApp
{

    class Conecta_DB
    {
        public SqlConnection conexao;


        public Conecta_DB()
        {

            string constring = "Server = DESKTOP - 8UEAH6A; Database = AGENDA_MOURA; Integrated Security = true;";
            conexao = new SqlConnection(constring);

        }

        class CRUD : Conecta_DB
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
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "INSERT INTO AGENDA(ID, NOME, SOBRENOME, TELEFONE_RESIDENCIAL, CELULAR_PRINCIPAL, CELULAR_RECADOS, ENDERECO, NUMERO, BAIRRO, CIDADE, ESTADO)" +
                       " VALUES(@ID,@NOME,@SOBRENOME,@TELEFONE_RESIDENCIAL,@CELULAR_PRINCIPAL,@CELULAR_RECADOS,@ENDERECO,@NUMERO,@BAIRRO,@CIDADE,@ESTADO)";

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conexao;

                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
                    cmd.Parameters.Add("@NOME", SqlDbType.VarChar).Value = NOME;
                    cmd.Parameters.Add("@SOBRENOME", SqlDbType.VarChar).Value = SOBRENOME;
                    cmd.Parameters.Add("@TELEFONE_RESIDENCIAL", SqlDbType.VarChar).Value = TELEFONE_RESIDENCIAL;
                    cmd.Parameters.Add("@CELULAR_PRINCIPAL", SqlDbType.VarChar).Value = CELULAR_PRINCIPAL;
                    cmd.Parameters.Add("@CELULAR_RECADOS", SqlDbType.VarChar).Value = CELULAR_RECADOS;
                    cmd.Parameters.Add("@ENDERECO", SqlDbType.VarChar).Value = ENDERECO;
                    cmd.Parameters.Add("@NUMERO", SqlDbType.VarChar).Value = NUMERO;
                    cmd.Parameters.Add("@BAIRRO", SqlDbType.VarChar).Value = BAIRRO;
                    cmd.Parameters.Add("@CIDADE", SqlDbType.VarChar).Value = CIDADE;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = ESTADO;


                    cmd.ExecuteNonQuery();
                    conexao.Close();

                }

            }

            //FUNÇAÕ UPDATE DB

            public void Update_Agenda()
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UPDATE AGENDA SET  ID = @ID, NOME = @NOME, SOBRENOME = @SOBRENOME , TELEFONE_RESIDENCIAL = @TELEFONE_RESIDENCIAL,CELULAR_PRINCIPAL=@CELULAR_PRINCIPAL," +
                    "CELULAR_RECADOS=@CELULAR_RECADOS, ENDERECO=@ENDERECO,NUMERO=@NUMERO, BAIRRO=@BAIRRO, CIDADE=@CIDADE, ESTADO=@ESTADO WHERE ID = @ID";

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conexao;

                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
                    cmd.Parameters.Add("@NOME", SqlDbType.VarChar).Value = NOME;
                    cmd.Parameters.Add("@SOBRENOME", SqlDbType.VarChar).Value = SOBRENOME;
                    cmd.Parameters.Add("@TELEFONE_RESIDENCIAL", SqlDbType.VarChar).Value = TELEFONE_RESIDENCIAL;
                    cmd.Parameters.Add("@CELULAR_PRINCIPAL", SqlDbType.VarChar).Value = CELULAR_PRINCIPAL;
                    cmd.Parameters.Add("@CELULAR_RECADOS", SqlDbType.VarChar).Value = CELULAR_RECADOS;
                    cmd.Parameters.Add("@ENDERECO", SqlDbType.VarChar).Value = ENDERECO;
                    cmd.Parameters.Add("@NUMERO", SqlDbType.VarChar).Value = NUMERO;
                    cmd.Parameters.Add("@BAIRRO", SqlDbType.VarChar).Value = BAIRRO;
                    cmd.Parameters.Add("@CIDADE", SqlDbType.VarChar).Value = CIDADE;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = ESTADO;


                    cmd.ExecuteNonQuery();
                    conexao.Close();

                }

            }

            //FUNÇÃO DELETE 

            public void Delete_Agenda()
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "DELETE FROM AGENDA WHERE  ID = @ID";

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conexao;

                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
                    cmd.Parameters.Add("@NOME", SqlDbType.VarChar).Value = NOME;
                    cmd.Parameters.Add("@SOBRENOME", SqlDbType.VarChar).Value = SOBRENOME;
                    cmd.Parameters.Add("@TELEFONE_RESIDENCIAL", SqlDbType.VarChar).Value = TELEFONE_RESIDENCIAL;
                    cmd.Parameters.Add("@CELULAR_PRINCIPAL", SqlDbType.VarChar).Value = CELULAR_PRINCIPAL;
                    cmd.Parameters.Add("@CELULAR_RECADOS", SqlDbType.VarChar).Value = CELULAR_RECADOS;
                    cmd.Parameters.Add("@ENDERECO", SqlDbType.VarChar).Value = ENDERECO;
                    cmd.Parameters.Add("@NUMERO", SqlDbType.VarChar).Value = NUMERO;
                    cmd.Parameters.Add("@BAIRRO", SqlDbType.VarChar).Value = BAIRRO;
                    cmd.Parameters.Add("@CIDADE", SqlDbType.VarChar).Value = CIDADE;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = ESTADO;


                    cmd.ExecuteNonQuery();
                    conexao.Close();

                }

            }

            //FUNÇÃO SELECT PARA CARREGAR DADOS
            public void Carregar_dados()
            {
                dt.Clear();
                string query = "SELECT * FROM AGENDA";
                SqlDataAdapter MDA = new SqlDataAdapter(query, conexao);
                MDA.Fill(ds);
                dt = ds.Tables[0];

            }
        }

    }
}

