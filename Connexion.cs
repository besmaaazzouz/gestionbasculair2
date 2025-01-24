using System;
using System.Drawing;
using System.Windows.Forms;

namespace basculeManger
{
    public partial class Connexion : UserControl
    {
        public Connexion()
        {
            InitializeComponent();
            // Assurez-vous que le mot de passe est caché
            textBox2.UseSystemPasswordChar = true;
            this.AutoSize = true; // Permet au contrôle de se redimensionner automatiquement selon le contenu
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
           
            

        }
            

        // Lorsque l'utilisateur clique sur le bouton de connexion
        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Vérifier si les champs sont vides
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return; // Arrête l'exécution si un champ est vide
            }

            // Exemple de vérification des identifiants
            if (username == "admin" && password == "password123")
            {
                MessageBox.Show("Connexion réussie !");
                // Vous pouvez ouvrir un autre formulaire ici si nécessaire ou afficher un message de succès.
                // Par exemple :
                // Accueil accueil = new Accueil(); // Remplacez par le formulaire souhaité
                // accueil.Show();
                // this.Hide(); // Masque le formulaire de connexion
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.");
            }
        }
        
        // Lorsque l'utilisateur clique sur le bouton "X" pour fermer
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Ferme l'application
        }
    }
}
