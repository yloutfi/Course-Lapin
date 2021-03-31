using MySql.Data.MySqlClient;
using Projet;
using System;
using System.Collections.Generic;
using Model;


namespace Utdl.Dao {
    public class DaoCourse {
        public void SaveChanges(List<Course> courses) {
            for(int i=0;i<courses.Count;i++) {
                Course course = courses[i];
                switch(course.State) {
                    case State.added:
                        this.insert(course);
                        break;
                    case State.modified:
                        this.update(course);
                        break;
                    case State.deleted:
                        this.delete(course);
                        courses.Remove(course);
                        break;
                }
            }
        }

        private void delete(Course course) {
            using(MySqlConnection cnx = DaoConnectionSingleton.GetMySqlConnection()) {
                cnx.Open();
                using(MySqlCommand cmd = new MySqlCommand("delete from Course where id=@id",cnx)) {
                    cmd.Parameters.Add(new MySqlParameter("@id",MySqlDbType.Int32));
                    cmd.Parameters["@id"].Value = course.Id;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void update(Course course) {
            using(MySqlConnection cnx = DaoConnectionSingleton.GetMySqlConnection()) {
                cnx.Open();
                using(MySqlCommand cmd = new MySqlCommand("update Course set distance=@distance where id=@id",cnx)) {
                    cmd.Parameters.Add(new MySqlParameter("@id",MySqlDbType.Int32));
                    cmd.Parameters.Add(new MySqlParameter("@distance",MySqlDbType.Int32));
                    cmd.Parameters["@id"].Value = course.Id;
                    cmd.Parameters["@distance"].Value = course.Distance;
                    cmd.ExecuteNonQuery();
                }
            }
            course.State = State.unChanged;
        }

        private void insert(Course course) {
            using(MySqlConnection cnx = DaoConnectionSingleton.GetMySqlConnection()) {
                cnx.Open();
                using(MySqlCommand cmd = new MySqlCommand("insert into Course(distance) values(@distance)",cnx)) {
                    cmd.Parameters.Add(new MySqlParameter("@distance",MySqlDbType.Int32));
                    cmd.Parameters["@distance"].Value = course.Distance;
                    cmd.ExecuteNonQuery();
                    // Todo gérer LastInsertId
                }
            }
            course.State = State.unChanged;
        }

        public List<Course> GetAll() {
            List<Course> courses = new List<Course>();
            using(MySqlConnection cnx = DaoConnectionSingleton.GetMySqlConnection()) {
                cnx.Open();
                using(MySqlCommand cmd = new MySqlCommand("select id,distance from Course",cnx)) {
                    using(MySqlDataReader rdr = cmd.ExecuteReader()) {
                        while(rdr.Read()) {
                            courses.Add(new Course(Convert.ToInt32(rdr["id"]),Convert.ToInt32(rdr["distance"]),State.unChanged));
                        }
                    }
                }
            }
            return courses;
        }

        public Course GetById(int id) {
            using(MySqlConnection cnx = DaoConnectionSingleton.GetMySqlConnection()) {
                cnx.Open();
                using(MySqlCommand cmd = new MySqlCommand("select id,distance from Course where id=@id",cnx)) {
                    cmd.Parameters.Add(new MySqlParameter("@id",MySqlDbType.Int32));
                    cmd.Parameters["@id"].Value = id;
                    using(MySqlDataReader rdr = cmd.ExecuteReader()) {
                        while(rdr.Read()) {
                            return new Course(Convert.ToInt32(rdr["id"]),Convert.ToInt32(rdr["distance"]),State.unChanged);
                        }
                    }
                }
            }
            throw new Exception("id non défini pour la table Course");
        }
    }
}
