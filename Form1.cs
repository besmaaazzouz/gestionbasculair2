using System;
using System.Drawing;
using System.Windows.Forms;

namespace basculeManger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialiser les propriétés de la barre de progression
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            // Démarrer le Timer
            timer1.Interval = 100; // 100 ms
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value >= progressBar1.Maximum)
            {
                timer1.Stop();

                // Afficher un MessageBox pour vérifier la fin du chargement
                MessageBox.Show("Chargement terminé. Ouvrir la page de connexion.");

                // Masquer les éléments de l'ancienne interface (barre de progression et label)
                progressBar1.Visible = false;
                label3.Visible = false;

                // Créer et afficher le contrôle de connexion
                Connexion connexionControl = new Connexion();

                // Retirer tous les autres contrôles de la fenêtre pour éviter la superposition
                foreach (Control ctrl in this.Controls)
                {
                    ctrl.Hide(); // Masquer tous les contrôles du formulaire
                }

                // Ajouter le contrôle de connexion au formulaire
                this.Controls.Add(connexionControl);

                // Définir une taille personnalisée pour Connexion si nécessaire
                connexionControl.Size = new Size(500, 400);  // Ajustez cette taille si nécessaire

                // Calculer la position centrée du contrôle dans le formulaire
                connexionControl.Location = new Point(
                    (this.ClientSize.Width - connexionControl.Width) / 2,
                    (this.ClientSize.Height - connexionControl.Height) / 2
                );

                // Pour un redimensionnement dynamique du contrôle lorsque la fenêtre change de taille
                connexionControl.Anchor = AnchorStyles.None;

                // Si vous préférez un redimensionnement automatique basé sur la taille du formulaire
                //connexionControl.Dock = DockStyle.Fill; // Vous pouvez utiliser cette ligne si vous voulez que le contrôle prenne toute la place
            }
            else
            {
                progressBar1.Value += 1;
                label3.Text = progressBar1.Value + "%"; // Mettre à jour l'étiquette
            }
        }
    }
}
