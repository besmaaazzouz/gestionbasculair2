using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

            // Permet au contrôle de se redimensionner automatiquement selon le contenu
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Lorsque l'utilisateur clique sur le bouton de connexion
        // Lorsque l'utilisateur clique sur le bouton de connexion
        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim(); // Nom d'utilisateur
            string password = textBox2.Text.Trim(); // Mot de passe

            // Vérifier si les champs sont vides
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            try
            {
                using (var context = new dbbasculesContext())
                {
                    // Rechercher le gérant correspondant dans la base de données
                    var gerant = context.gerants.FirstOrDefault(g => g.nom == username);

                    if (gerant != null)
                    {
                        // Hacher le mot de passe entré par l'utilisateur
                        string hashedPassword = HashPassword(password);

                        // Comparer le mot de passe haché avec celui de la base
                        if (gerant.motpass == hashedPassword)
                        {
                            MessageBox.Show("Connexion réussie !");
                            // Redirigez vers un autre formulaire ou une page d'accueil si nécessaire
                            // Exemple :
                            // Accueil accueil = new Accueil();
                            // accueil.Show();
                            // this.Hide(); // Masque le formulaire actuel
                        }
                        else
                        {
                            MessageBox.Show("Mot de passe incorrect.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nom d'utilisateur introuvable.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Gérer les exceptions et afficher un message à l'utilisateur
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}");
            }
        }
    }
}