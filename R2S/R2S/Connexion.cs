﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace R2S
{
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
        }

        // Appel de la classe database pour le traitement en BDD
        database db = new database();

        private void btn_connexion_Click(object sender, EventArgs e)
        {
            string strQuery;

            // Conditions pour vérifier l'entrée de donnée dans les champs
            if (txt_login.Text != "" && txt_password.Text != "")
            {
                db.dbConnect();
                // Chaine de requete pour la vérification des utilisateurs
                strQuery = "SELECT utilisateur.login, utilisateur.password, utilisateur.id, utilisateur.id_groupe_utilisateur FROM utilisateur";
                if (db.userCertif(strQuery, txt_login, txt_password) == 2)
                {
                    Acceuil acceuil = new Acceuil();
                    this.Hide();
                    acceuil.Show();
                    
                }
                if (db.userCertif(strQuery, txt_login, txt_password) == 1)
                {
                    Administrateur administrateur = new Administrateur();
                    this.Hide();
                    administrateur.Show();

                }
                if(db.userCertif(strQuery, txt_login, txt_password) == 0)
                {
                    MessageBox.Show("Informations de connexion incorrecte.", "Attention");
                }
                db.dbDisconnect();
            }
            else
            {
                MessageBox.Show("Veuillez renseigner votre nom de compte ou votre mot de passe.", "Attention");
            }
        }
    }
}
