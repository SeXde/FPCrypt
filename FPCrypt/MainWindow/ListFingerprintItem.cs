﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPCrypt.MainWindow
{
    public partial class ListFingerprintItem : UserControl
    {

        private Fingerprint fingerprint;
        private MainWindow mainWindow;
        public ListFingerprintItem(Fingerprint fingerprint, MainWindow mainWindow)
        {
            InitializeComponent();
            this.fingerprint = fingerprint;
            labelFP.Text = fingerprint.getName();
            this.mainWindow = mainWindow;
        }

        public void updateItem(Fingerprint fingerprint)
        {
            this.fingerprint = fingerprint;
            labelFP.Text = fingerprint.getName();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void editNameButton_Click(object sender, EventArgs e)
        {
            new ModifyFingerPrintNameWindow.ModifyfingerprintnameForm(fingerprint, mainWindow).ShowDialog();

        }

        private void deleteFingerButton_Click(object sender, EventArgs e)
        {
            var manager = FingerprintManager.getInstance();
            manager.deleteFP(fingerprint);
        }
    }
}
