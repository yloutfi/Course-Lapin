using Model;
using MySql.Data.MySqlClient;
using Projet;
using System;
using System.Collections.Generic;


namespace Utdl.Dao {
    public class DaoLapin {
        public void SaveChanges(List<Lapin> lapins) {
            for(int i=0;i<lapins.Count; i++) {
                Lapin lapin = lapins[i];
                switch(lapin.State) {
                    case State.added:
                        this.insert(lapin);
                        break;
                    case State.modified:
                        this.update(lapin);
                        break;
                    case State.deleted:
                        this.delete(lapin);
                        lapins.Remove(lapin);
                        break;
                }
            }
        }

        private void delete(Lapin lapin) {
            using(MySqlConnection cnx = DaoConnectionSingleton.GetMySqlConnection()) {
                cnx.Open();
                using(MySqlCommand cmd = new MySqlCommand("delete from Lapin where id=@id",cnx)) {
                    cmd.Parameters.Add(new MySqlParameter("@id",MySqlDbType.Int32));
                    cmd.Parameters["@id"].Value = lapin.Id;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void update(Lapin lapin) {
            using(MySqlConnection cnx = DaoConnectionSingleton.GetMySqlConnection()) {
                cnx.Open();
                using(MySqlCommand cmd = new MySqlCommand("update Lapin set surnom=@surnom,age=@age,position=@position,dossard=@dossard idCourse=@idCourse where id=@id",cnx)) {
                    cmd.Parameters.Add(new MySqlParameter("@id",MySqlDbType.Int32));
                    cmd.Parameters.Add(new MySqlParameter("@age",MySqlDbType.Int32));
                    cmd.Parameters.Add(new MySqlParameter("@position",MySqlDbType.Int32));
                    cmd.Parameters.Add(new MySqlParameter("@dossard",MySqlDbType.Int32));
                    cmd.Parameters.Add(new MySqlParameter("@surnom",MySqlDbType.VarChar));
                    cmd.Parameters["@id"].Value = lapin.Id;
                    cmd.Parameters["@age"].Value = lapin.Age;
                    cmd.Parameters["@position"].Value = lapin.GetPosition();
                    cmd.Parameters["@dossard"].Value = lapin.Dossard;
                    cmd.Parameters["@surnom"].Value = lapin.GetSurnom();
                    cmd.ExecuteNonQuery();
                }
            }
            lapin.State = State.unChanged;
        }

        private void insert(Lapin lapin) {
            using(MySqlConnection cnx = DaoConnectionSingleton.GetMySqlConnection()) {
                cnx.Open();
                using(MySqlCommand cmd = new MySqlCommand("insert into Lapin(surnom,age,position,dossard,idCourse) values(@surnom,@age,@position,@dossard,@idCourse)",cnx)) {
                    cmd.Parameters.Add(new MySqlParameter("@idCourse",MySqlDbType.Int32));
                    cmd.Parameters.Add(new MySqlParameter("@age",MySqlDbType.Int32));
                    cmd.Parameters.Add(new MySqlParameter("@position",MySqlDbType.Int32));
                    cmd.Parameters.Add(new MySqlParameter("@dossard",MySqlDbType.Int32));
                    cmd.Parameters.Add(new MySqlParameter("@surnom",MySqlDbType.VarChar));
                    cmd.Parameters["@id"].Value = lapin.Id;
                    cmd.Parameters["@age"].Value = lapin.Age;
                    cmd.Parameters["@position"].Value = lapin.GetPosition();
                    cmd.Parameters["@dossard"].Value = lapin.Dossard;
                    cmd.Parameters["@surnom"].Value = lapin.Surnom;
                    cmd.ExecuteNonQuery();
                    // Todo coder la récupération de LastId                     
                }
            }
            lapin.State = State.unChanged;
        }

        public List<Lapin> GetAll(int idCourse) {
            List<Lapin> lapins = new List<Lapin>();
            using(MySqlConnection cnx = DaoConnectionSingleton.GetMySqlConnection()) {
                cnx.Open();
                using(MySqlCommand cmd = new MySqlCommand("select id,surnom,age,position,dossard from Lapin where idCourse=@idCourse",cnx)) {
                    using(MySqlDataReader rdr = cmd.ExecuteReader()) {
                        while(rdr.Read()) {
                            lapins.Add(new Lapin(Convert.ToInt32(rdr["id"]),rdr["surnom"].ToString(),Convert.ToInt32(rdr["age"]),Convert.ToInt32(rdr["dossard"]),Convert.ToInt32(rdr["position"]),State.unChanged));
                        }
                    }
                }
            }
            return lapins;
        }

        public Lapin GetById(int id) {
            using(MySqlConnection cnx = DaoConnectionSingleton.GetMySqlConnection()) {
                cnx.Open();
                using(MySqlCommand cmd = new MySqlCommand("select id,surnom,age,position,dossard from Lapin where id=@id",cnx)) {
                    cmd.Parameters.Add(new MySqlParameter("@id",MySqlDbType.Int32));
                    cmd.Parameters["@id"].Value = id;
                    using(MySqlDataReader rdr = cmd.ExecuteReader()) {
                        while(rdr.Read()) {
                            return new Lapin(Convert.ToInt32(rdr["id"]),rdr["surnom"].ToString(),Convert.ToInt32(rdr["age"]),Convert.ToInt32(rdr["dossard"]),Convert.ToInt32(rdr["position"]),State.unChanged);
                        }
                    }
                }
            }
            throw new Exception("id non défini pour la table Lapin");
        }
    }
}
