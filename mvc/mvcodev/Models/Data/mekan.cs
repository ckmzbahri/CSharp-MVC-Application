//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvcodev.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class mekan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mekan()
        {
            this.rezervasyon = new HashSet<rezervasyon>();
        }
   
        public int mekan_id { get; set; }
        [Required(ErrorMessage ="bu alan bo� ge�ilemez")]
        public string mekan_adi { get; set; }
        [Required(ErrorMessage = "bu alan bo� ge�ilemez")]
        public string mekan_adres { get; set; }
        [Required(ErrorMessage = "bu alan bo� ge�ilemez")]
        public string kapasite { get; set; }
       
        public string mekan_foto1 { get; set; }
      
        public string mekan_foto2 { get; set; }
     
        public string mekan_foto3 { get; set; }
        [Required(ErrorMessage = "bu alan bo� ge�ilemez")]
        public Nullable<int> mekan_ucret { get; set; }
      

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rezervasyon> rezervasyon { get; set; }
    }
}