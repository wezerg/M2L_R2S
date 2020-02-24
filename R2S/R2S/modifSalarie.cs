﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R2S
{
    public partial class modifSalarie : Form
    {
        database db = new database();
        private string[,] verifLogin;
        private string[,] listLigue;
        private string[,] listSalle;
        private bool loginUnique = false;
        public string [,] returnValue;
        public modifSalarie(string [,] tabDonnees)
        {
            InitializeComponent();
            txt_add_nom.Text = tabDonnees[0, 1];
            txt_add_prenom.Text = tabDonnees[0, 2];
            txt_add_login.Text = tabDonnees[0, 3];
            txt_add_password.Text = tabDonnees[0, 4];
            cho_add_ligue.SelectedItem = tabDonnees[0, 5];
            cho_add_salle.SelectedItem = tabDonnees[0, 6];

            this.returnValue[0, 0] = tabDonnees[0, 0];
        }

        private void btn_add_confirm_Click(object sender, EventArgs e)
        {
            this.returnValue[0, 1] = txt_add_nom.Text;
            this.returnValue[0, 2] = txt_add_prenom.Text;
            this.returnValue[0, 3] = txt_add_login.Text;
            this.returnValue[0, 4] = db.GetHashPassword(txt_add_password.Text);
            this.returnValue[0, 5] = ();
            this.returnValue[0, 6] = txt_add_nom.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        //    db.dbConnect();
        //    if (txt_add_password.Text != "" && txt_add_nom.Text != "" && txt_add_prenom.Text != "" && txt_add_password.Text != "")
        //    {
        //        // Vérification des logins existants par une double boucle 
        //        verifLogin = db.dbQuery("SELECT u.login FROM utilisateur u;");
        //        for (int i = 0; i < verifLogin.GetLength(0); i++)
        //        {
        //            for (int j = 0; j < verifLogin.GetLength(1); j++)
        //            {
        //                if (txt_add_login.Text == verifLogin[i, j])
        //                {
        //                    loginUnique = true;
        //                }
        //            }
        //        }
        //        // Si le login est unique alors :
        //        if (!loginUnique)
        //        {
        //            string idLigue = "";
        //            string idSalle = "";
        //            // Aller chercher l'id de la ligue et de la salle pour les rajouter a l'employé :
        //            if (cho_add_salle.SelectedItem != null)
        //            {
        //                for (int i = 0; i < listSalle.GetLength(0); i++)
        //                {
        //                    if (cho_add_salle.SelectedItem.ToString() == listSalle[i, 1])
        //                    {
        //                        idSalle = listSalle[i, 0];
        //                    }
        //                }
        //            }
        //            if (cho_add_ligue.SelectedItem != null)
        //            {
        //                for (int i = 0; i < listLigue.GetLength(0); i++)
        //                {
        //                    if (cho_add_ligue.SelectedItem.ToString() == listLigue[i, 1])
        //                    {
        //                        idLigue = listLigue[i, 0];
        //                    }
        //                }
        //            }
        //            // Ajouter le salarié a la base de donnée
        //            // REFAIRE et mettre un UPDATE A LA PLACE
        //            db.insertDB("INSERT INTO utilisateur(nom, prenom, login, password, id_groupe_utilisateur, id_salle, id_ligue) " +
        //                        "VALUES(" + '"' + txt_add_nom.Text + '"' + "," + '"' +txt_add_prenom.Text + '"' + "," + '"' + txt_add_login.Text + '"' + "," +
        //                        '"' + db.GetHashPassword(txt_add_password.Text) + '"' + ", 2," + 
        //                        ((idSalle != "") ? idSalle : "DEFAULT")  + "," + ((idLigue != "") ? idLigue : "DEFAULT") + ")");
        //            // Fermeture du formulaire avec envoi
        //            this.Close();
        //            this.Dispose();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Ce login existe déja.", "Attention");
        //            loginUnique = false;
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Les valeurs des champs Nom, Prénom, Login et Password ne peuvent être vides.", "Attention");
        //    }
        //    db.dbDisconnect();
        }

        private void btn_add_annule_Click(object sender, EventArgs e)
        {
            // Fermeture sans envoi en bdd
            this.Close();
            this.Dispose();
        }

        private void modifSalarie_Load(object sender, EventArgs e)
        {
            db.dbConnect();
            // Création des listes des ligues et des salles en listBox
            cho_add_ligue.Items.Clear();
            cho_add_salle.Items.Clear();
            listLigue = db.dbQuery("SELECT l.id, l.intitule FROM ligue l;");
            listSalle = db.dbQuery("SELECT s.id, s.localisation FROM salle s;");
            for (int i = 0; i < listLigue.GetLength(0); i++)
            {
                cho_add_ligue.Items.Add(listLigue[i, 1]);
            }
            for (int i = 0; i < listSalle.GetLength(0); i++)
            {
                cho_add_salle.Items.Add(listSalle[i, 1]);
            }
            db.dbDisconnect();
        }
    }
}