//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace basculeManger
{
    using System;
    using System.Collections.Generic;
    
    public partial class vente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vente()
        {
            this.bons = new HashSet<bon>();
        }
    
        public int id { get; set; }
        public Nullable<int> id_client { get; set; }
        public Nullable<int> id_camion { get; set; }
        public Nullable<System.DateTime> temp { get; set; }
        public Nullable<decimal> tonage { get; set; }
        public Nullable<decimal> tonage_net { get; set; }
        public Nullable<decimal> tonage_total { get; set; }
        public Nullable<decimal> prix { get; set; }
        public string type_produit { get; set; }
        public string type_vent { get; set; }
        public Nullable<int> id_chiffeur { get; set; }
        public string mode_pay { get; set; }
        public Nullable<int> id_produit { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bon> bons { get; set; }
        public virtual camion camion { get; set; }
        public virtual chiffeur chiffeur { get; set; }
        public virtual client client { get; set; }
        public virtual produit produit { get; set; }
    }
}
