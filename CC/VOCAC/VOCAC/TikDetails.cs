﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOCAC
{
    public partial class TikDetails : Form
    {
        private static TikDetails frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static TikDetails gettikdetlsfrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new TikDetails();
                    frm.FormClosed += new FormClosedEventHandler(frm_Closed);
                }
                return frm;
            }
        }
        public TikDetails()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
        }

        private void TikDetails_Load(object sender, EventArgs e)
        {

        }
    }
}