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
    public partial class supprLigueSalleSalarie : Form
    {
        string[,] returnValue;
        public supprLigueSalleSalarie(string [,] tabDonnee)
        {
            InitializeComponent();
            returnValue = new string[1, 4];
            returnValue[0, 1] = tabDonnee[0, 0];
            returnValue[0, 2] = tabDonnee[0, 1];
            if (tabDonnee.GetLength(0) == 3)
            {
                returnValue[0, 3] = tabDonnee[0, 2];
            }
        }

        private void supprLigueSalleSalarie_Load(object sender, EventArgs e)
        {
            if (this.Text == "Supprimer Salarié")
            {
                
                returnValue[0, 0] = "supprSalarie";
                lbl_suppr.Text = "Voulez vous vraiment supprimer l'utilisateur : " + returnValue[0, 2] + " " + returnValue[0, 3];
            }
            if (this.Text == "Supprimer Ligue")
            {
                returnValue[0, 0] = "supprLigue";
                lbl_suppr.Text = "Voulez vous vraiment supprimer la ligue : " + returnValue[0, 2];
            }
            if (this.Text == "Supprimer Salle")
            {
                returnValue[0, 0] = "supprSalle";
                lbl_suppr.Text = "Voulez vous vraiment supprimer la salle : " + returnValue[0, 2];
            }
        }
    }
}
