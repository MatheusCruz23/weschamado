using System.Data.SqlClient;

namespace ControleChamado.DAO
{    
    public class Conexao
    {
        SqlConnection con = new SqlConnection();

        public Conexao()
        {
            con.ConnectionString = "Data Source=DESKTOP-GLDGOIK; " +
                "Initial Catalog=FastTicket;" +
                "User ID=developer; Password=1234567";
        }

        public SqlConnection Conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        public void Desconectar()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
}
